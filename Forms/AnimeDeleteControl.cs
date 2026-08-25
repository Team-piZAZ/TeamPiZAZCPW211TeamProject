using System;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using TeamPiZAZCPW211TeamProject.Database;
using TeamPiZAZCPW211TeamProject.Models;

namespace TeamPiZAZCPW211TeamProject.Forms;

public partial class AnimeDeleteControl : UserControl
{
    private readonly AnimeDbContext _context;
    private Anime _animeToDelete;

    public AnimeDeleteControl(AnimeDbContext context)
    {
        InitializeComponent();
        _context = context;

        // Wire up the events
        this.Load += AnimeDeleteControl_Load;
        btnSearch.Click += btnSearch_Click;
        btnDelete.Click += btnDelete_Click;
        btnCancel.Click += btnCancel_Click;
    }

    private async void AnimeDeleteControl_Load(object sender, EventArgs e)
    {
        // Set up predictive text so you don't have to guess the spelling
        var titles = await _context.Animes.Select(a => a.Title).Distinct().ToArrayAsync();
        var autoCompleteData = new AutoCompleteStringCollection();
        autoCompleteData.AddRange(titles);

        txtDeleteSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        txtDeleteSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
        txtDeleteSearch.AutoCompleteCustomSource = autoCompleteData;

        // Hide the preview text until a search happens
        lblPreviewTitle.Text = "";
        lblPreviewGenre.Text = "";
        lblPreviewRating.Text = "";
    }

    private async void btnSearch_Click(object sender, EventArgs e)
    {
        string searchTitle = txtDeleteSearch.Text.Trim();

        // Must include Genres so the preview card doesn't crash!
        Anime? anime = await _context.Animes.Include(a => a.Genres).FirstOrDefaultAsync(a => a.Title == searchTitle);
        _animeToDelete = anime;

        if (_animeToDelete == null)
        {
            MessageBox.Show("Anime not found. Check your spelling.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnDelete.Enabled = false;
            picPreview.Image = null;
            return;
        }

        // Populate the Preview Card Area
        lblPreviewTitle.Text = _animeToDelete.Title;
        lblPreviewRating.Text = $"TV Rating: {_animeToDelete.TvRating}";

        if (_animeToDelete.Genres != null && _animeToDelete.Genres.Any())
        {
            lblPreviewGenre.Text = "Genre: " + string.Join(", ", _animeToDelete.Genres.Select(g => g.Name));
        }
        else
        {
            lblPreviewGenre.Text = "Genre: N/A";
        }

        // Load the image preview
        string imagePath = Path.Combine(Application.StartupPath, "Images", $"{_animeToDelete.Id}.jpg");
        if (File.Exists(imagePath))
        {
            picPreview.ImageLocation = imagePath;
        }
        else
        {
            picPreview.Image = null;
        }

        // Unlock the destructive button
        btnDelete.Enabled = true;
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        if (_animeToDelete == null) return;

        var confirmResult = MessageBox.Show(
            $"Are you absolutely sure you want to permanently delete '{_animeToDelete.Title}'?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (confirmResult == DialogResult.Yes)
        {
            try
            {
                _context.Animes.Remove(_animeToDelete);
                await _context.SaveChangesAsync();

                MessageBox.Show("Anime wiped from the database.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Parent?.Controls.Remove(this);
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting anime: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.Parent?.Controls.Remove(this);
        this.Dispose();
    }
}