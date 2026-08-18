using System.Data;
using TeamPiZAZCPW211TeamProject.Services;
using TeamPiZAZCPW211TeamProject.Models;
using TeamPiZAZCPW211TeamProject.Database;
using Microsoft.EntityFrameworkCore;

namespace TeamPiZAZCPW211TeamProject.Forms;

/// <summary>
/// Represents a form for displaying and editing anime details.
/// </summary>
public partial class AnimeDetailsForm : Form
{
    // Reference to the AnimeService for managing anime data.
    private readonly AnimeService _animeService;
    private readonly AnimeDbContext _context;

    // Holds the current anime being edited or viewed.
    private Anime _currentAnime;

    // Indicates whether the form is in update mode (editing an existing anime) or create mode (adding a new anime).
    private bool IsUpdateMode => _currentAnime != null;

    public AnimeDetailsForm(AnimeDbContext context, AnimeService service, Anime animeToEdit = null)
    {
        InitializeComponent();
        btnSave.Click += btnSave_Click;
        this.Load += AnimeDetailsForm_Load;
        _context = context;
        _animeService = service;
        _currentAnime = animeToEdit;
        
    }

    /// <summary>
    /// Handles the Load event of the AnimeDetailsForm.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private async void AnimeDetailsForm_Load(object sender, EventArgs e)
    {
        // 1. Fetch all available genres from the database, sorted alphabetically
        var allGenres = _context.Genres.OrderBy(g => g.Name).ToList();

        // 2. Clear the box (just in case) and add the objects
        clbGenres.Items.Clear();
        foreach (var genre in allGenres)
        {
            clbGenres.Items.Add(genre);
        }

        // 3. Tell the CheckedListBox to dispprivate async void AnimeDetailsForm_Load(object sender, EventArgs e)
        // Clear the box and add the objects
        clbGenres.Items.Clear();
        foreach (var genre in allGenres)
        {
            clbGenres.Items.Add(genre);
        }

        // Tell the CheckedListBox to display the genre's Name
        clbGenres.DisplayMember = "Name";
        clbGenres.ValueMember = "Id";

        // If we are updating an existing anime, load it asynchronously
        if (IsUpdateMode && _currentAnime != null)
        {
            await LoadExistingAnimeDataAsync();
        }
    }

    private async Task LoadExistingAnimeDataAsync()
        {
            // Pre-fill the standard text boxes immediately
            txtTitle.Text = _currentAnime.Title;
            txtSynopsis.Text = _currentAnime.Synopsis;
            numRating.Value = (decimal)_currentAnime.Rating;
            dtpReleaseDate.Value = new DateTime(_currentAnime.ReleaseYear, 1, 1);

            // CRITICAL: Fetch the attached genres asynchronously
            var animeWithGenres = await _context.Animes
                                          .Where(a => a.Id == _currentAnime.Id)
                                          .SelectMany(a => a.Genres)
                                          .Select(g => g.Id)
                                          .ToListAsync();

            // Loop through every checkbox in the list and check matches
            for (int i = 0; i < clbGenres.Items.Count; i++)
            {
                var genreItem = (Genre)clbGenres.Items[i];

                if (animeWithGenres.Contains(genreItem.Id))
                {
                    clbGenres.SetItemChecked(i, true);
                }
            }
    }

    /// <summary>
    /// Loads all genres from the AnimeService and populates the CheckedListBox with them.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    private async Task LoadGenres()
    {
        var allGenres = await _animeService.GetAllGenresAsync();

        clbGenres.DataSource = allGenres;
        clbGenres.DisplayMember = "Name";
        clbGenres.ValueMember = "Id";
    }

    /// <summary>
    /// Populates the form fields with the details of the current anime being edited.
    /// </summary>
    private void PopulateFields()
    {
        txtTitle.Text = _currentAnime.Title;
        txtSynopsis.Text = _currentAnime.Synopsis;
        numRating.Value = (decimal)_currentAnime.Rating;

        // Set the DateTimePicker to the first day of the release year,
        // defaulting to January 1st of that year since only the year is stored.
        dtpReleaseDate.Value = new DateTime(_currentAnime.ReleaseYear, 1, 1);

        for (int i = 0; i < clbGenres.Items.Count; i++)
        {
            var genre = (Genre)clbGenres.Items[i];
            if (_currentAnime.Genres.Any(g => g.Id == genre.Id))
            {
                clbGenres.SetItemChecked(i, true);
            }
        }
    }

    /// <summary>
    /// Handles the click event of the Save button.
    /// Validates the form, creates or updates the Anime entity,
    /// and saves it to the database along with its associated genres.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private async void btnSave_Click(object sender, EventArgs e)
    {
        if (!ValidateForm()) return;

        string titleToCheck = txtTitle.Text.Trim();

        // Only check for duplicates if we are adding a new anime not updating an existing one
        if (!IsUpdateMode)
        {
            bool isDuplicate = _context.Animes.Any(a => a.Title.ToLower() == titleToCheck.ToLower());
            if (isDuplicate)
            {
                MessageBox.Show($"'{titleToCheck}' is already in the database.", "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Stops the save operation if a duplicate is found
                return;
            }
        }

        // Create a new Anime object or use the existing one based on the mode
        var animeToSave = IsUpdateMode ? _currentAnime : new Anime();

        animeToSave.Title = titleToCheck;
        animeToSave.Synopsis = txtSynopsis.Text.Trim();
        animeToSave.Rating = (double)numRating.Value;
        animeToSave.ReleaseYear = dtpReleaseDate.Value.Year;

        // Get the selected genre IDs from the CheckedListBox
        var selectedGenreIds = clbGenres.CheckedItems
                                                .Cast<Genre>()
                                                .Select(g => g.Id)
                                                .ToList();

        try
        {
            if (IsUpdateMode)
                await _animeService.UpdateAnimeAsync(animeToSave, selectedGenreIds);
            else
                await _animeService.AddAnimeAsync(animeToSave, selectedGenreIds);

            MessageBox.Show("Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving anime: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Validates the form inputs to ensure that all required fields are filled out correctly.
    /// </summary>
    /// <returns>True if the form is valid, false otherwise.</returns>
    private bool ValidateForm()
    {

        // Validate Title
        if (string.IsNullOrWhiteSpace(txtTitle.Text))
        {
            MessageBox.Show("Please provide a title.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTitle.Focus();
            return false;
        }

        // Validate Genres
        if (clbGenres.CheckedItems.Count == 0)
        {
            MessageBox.Show("Please select at least one genre.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            clbGenres.Focus();
            return false;
        }

        // Validate Release Date
        if (dtpReleaseDate.Value == DateTime.MinValue)
        {
            MessageBox.Show("Please select a release date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dtpReleaseDate.Focus();
            return false;
        }

        return true;
    }

    private void btnManageGenres_Click(object sender, EventArgs e)
    {
        using (var genreForm = new GenreManagementForm(_context))
        {
            genreForm.ShowDialog();
        }
    }
}

