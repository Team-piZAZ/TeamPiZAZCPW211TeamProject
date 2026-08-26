using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using TeamPiZAZCPW211TeamProject.Database;
using TeamPiZAZCPW211TeamProject.Models;
using TeamPiZAZCPW211TeamProject.Services;

namespace TeamPiZAZCPW211TeamProject.Forms;

public partial class AnimeDetailsForm : Form
{
    // Dependency Injection: Accepting the DbContext and Service in the constructor
    private readonly AnimeService _animeService;
    private readonly AnimeDbContext _context;


    /// <summary>
    /// Initializes a new instance of the <see cref="AnimeDetailsForm"/> 
    /// class with the specified database context and anime service.
    /// </summary>
    /// <param name="context">The database context to use.</param>
    /// <param name="service">The anime service to use.</param>
    public AnimeDetailsForm(AnimeDbContext context, AnimeService service)
    {
        InitializeComponent();

        _context = context;
        _animeService = service;

        // Wiring up the buttons and load event
        btnSave.Click += btnSave_Click;
        btnDeleteAnime.Click += btnLaunchDeleteControl_Click;
        this.Load += AnimeDetailsForm_Load;
    }


    /// <summary>
    /// Handles the Load event of the AnimeDetailsForm control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private void AnimeDetailsForm_Load(object sender, EventArgs e)
    {
        // Fetch available genres synchronously
        var availableGenres = _context.Genres.OrderBy(g => g.Name).ToList(); // Sync

        clbGenres.Sorted = false;
        clbGenres.DataSource = availableGenres;

        clbGenres.DisplayMember = "Name";
        clbGenres.ValueMember = "Id";
    }


    /// <summary>
    /// Handles the Click event of the btnSave control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private async void btnSave_Click(object sender, EventArgs e)
    {
        // The Validation Bouncer
        if (!ValidateForm()) return;

        string properCaseTitle = txtTitle.Text.Trim();

        // Duplicate Check
        bool titleExists = await _context.Animes.AnyAsync(a => a.Title.ToLower() == properCaseTitle.ToLower());

        if (titleExists)
        {
            MessageBox.Show("This anime already exists in the database!", "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Create the new Anime
        Anime newAnime = new Anime
        {
            Title = properCaseTitle,
            Synopsis = txtSynopsis.Text.Trim(),
            PublicationYear = (int)numPublicationYear.Value,
            ReleaseYear = dtpReleaseDate.Value.Year,
            Episodes = (int)numEpisodes.Value,
            TvRating = cmbTvRating.Text,
            Genres = new List<Genre>()
        };

        // Safely attach the tracked genres
        var selectedGenreIds = clbGenres.CheckedItems.Cast<Genre>().Select(g => g.Id).ToList();

        if (selectedGenreIds.Any())
        {
            var trackedGenres = await _context.Genres.Where(g => selectedGenreIds.Contains(g.Id)).ToListAsync();
            foreach (var genre in trackedGenres)
            {
                newAnime.Genres.Add(genre);
            }
        }

        // Save everything
        try
        {
            _context.Animes.Add(newAnime);
            await _context.SaveChangesAsync();

            MessageBox.Show("Anime added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


    /// <summary>
    /// Validates the form inputs to ensure all required fields are filled and valid.
    /// </summary>
    /// <returns>True if the form is valid, false otherwise.</returns>
    private bool ValidateForm()
    {

        // Check if the title is empty or whitespace
        if (string.IsNullOrWhiteSpace(txtTitle.Text))
        {
            MessageBox.Show("Please provide a title.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTitle.Focus();
            return false;
        }

        // Check if the synopsis is empty or whitespace
        if (clbGenres.CheckedItems.Count == 0)
        {
            MessageBox.Show("Please select at least one genre.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            clbGenres.Focus();
            return false;
        }

        // Check if the publication year is valid
        if (dtpReleaseDate.Value == DateTime.MinValue)
        {
            MessageBox.Show("Please select a release date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dtpReleaseDate.Focus();
            return false;
        }

        return true;
    }


    /// <summary>
    /// Handles the Click event of the btnManageGenres control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private void btnManageGenres_Click(object sender, EventArgs e)
    {
        using (var genreForm = new GenreManagementForm(_context))
        {
            genreForm.ShowDialog();
        }
    }


    /// <summary>
    /// Handles the Click event of the btnEditAnime control. 
    /// This method creates and displays an AnimeEditControl for editing anime details.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private void btnEditAnime_Click(object sender, EventArgs e)
    {
        btnEditAnime.Visible = false;

        AnimeEditControl editControl = new AnimeEditControl(_context);

        editControl.BorderStyle = BorderStyle.FixedSingle;
        editControl.BackColor = Color.FromArgb(45, 45, 45);

        editControl.Location = new Point(
            (this.ClientSize.Width - editControl.Width) / 10,
            (this.ClientSize.Height - editControl.Height) / 2
        );

        editControl.Disposed += (s, args) =>
        {
            btnEditAnime.Visible = true;
        };

        this.Controls.Add(editControl);
        editControl.BringToFront();
    }


    /// <summary>
    /// Handles the Click event of the btnLaunchDeleteControl control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private void btnLaunchDeleteControl_Click(object sender, EventArgs e)
    {
        // Hide the delete button to prevent multiple instances of the delete control
        btnDeleteAnime.Visible = false;

        AnimeDeleteControl deleteControl = new AnimeDeleteControl(_context);

        deleteControl.Left = (this.ClientSize.Width - deleteControl.Width) / 2;
        deleteControl.Top = (this.ClientSize.Height - deleteControl.Height) / 2;

        // When the delete control is disposed, make the delete button visible again
        deleteControl.Disposed += (s, args) =>
        {
            btnDeleteAnime.Visible = true;
        };

        // Add the delete control to the form and bring it to the front
        this.Controls.Add(deleteControl);
        deleteControl.BringToFront();
    }
}