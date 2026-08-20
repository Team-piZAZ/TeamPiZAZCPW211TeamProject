using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TeamPiZAZCPW211TeamProject.Services;
using TeamPiZAZCPW211TeamProject.Models;
using TeamPiZAZCPW211TeamProject.Database;
using Microsoft.EntityFrameworkCore;

namespace TeamPiZAZCPW211TeamProject.Forms;

public partial class AnimeEditControl : UserControl
{

    private readonly AnimeDbContext _context;
    public AnimeEditControl(AnimeDbContext context)
    {
        InitializeComponent();
        _context = context;
        btnSearch.Click += btnSearch_Click;
        btnCancelChanges.Click += btnCancelChanges_Click;
    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {

    }

    private async void AnimeEditControl_Load(object sender, EventArgs e)
    {
        var titles = await _context.Animes.Select(a => a.Title).Distinct().ToArrayAsync();
        var autoCompleteData = new AutoCompleteStringCollection();
        autoCompleteData.AddRange(titles);

        txtEditSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        txtEditSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
        txtEditSearch.AutoCompleteCustomSource = autoCompleteData;
    }

    private Anime _animeToEdit;

    private async void btnSearch_Click(object sender, EventArgs e)
    {
        string searchTitle = txtEditSearch.Text;

        // Search for the anime by title in the database
        _animeToEdit = await _context.Animes.FirstOrDefaultAsync(a => a.Title == searchTitle);

        if (_animeToEdit == null)
        {
            MessageBox.Show("Anime not found. Please try another title.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        // Populate the text boxes with the anime details
        txtTitle.Text = _animeToEdit.Title;
        txtSynopsis.Text = _animeToEdit.Synopsis;


        dtpPublicationYear.Value = new DateTime(_animeToEdit.PublicationYear, 1, 1);


        numEpisodes.Value = Math.Max(numEpisodes.Minimum, _animeToEdit.Episodes);


        cmbEditTvRating.Text = _animeToEdit.TvRating;

    }

    private void btnCancelChanges_Click(object sender, EventArgs e)
    {
        this.Parent?.Controls.Remove(this);
        this.Dispose();

    }

    private async void btnSaveChanges_Click(object sender, EventArgs e)
    {
        // Ensure that an anime has been loaded for editing
        if (_animeToEdit == null)
        {
            MessageBox.Show("Please search for and load an anime to edit first.", "No Anime Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtSynopsis.Text))
        {
            MessageBox.Show("Title and Synopsis cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Update the anime details with the values from the text boxes
        _animeToEdit.Title = txtTitle.Text;
        _animeToEdit.Synopsis = txtSynopsis.Text;

        // Since dtpPublicationYear is a DateTimePicker, we extract just the Year as an integer
        _animeToEdit.PublicationYear = dtpPublicationYear.Value.Year;

        _animeToEdit.Episodes = (int)numEpisodes.Value;
        _animeToEdit.TvRating = cmbEditTvRating.Text;

        try
        {
            await _context.SaveChangesAsync();

            MessageBox.Show("Anime Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Dispose(); // Close the control after saving changes
        }
        catch
        {
            MessageBox.Show("An error occurred while saving changes. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
