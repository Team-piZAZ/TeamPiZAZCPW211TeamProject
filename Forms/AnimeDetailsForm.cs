using System.Data;
using TeamPiZAZCPW211TeamProject.Services;
using TeamPiZAZCPW211TeamProject.Models;

namespace TeamPiZAZCPW211TeamProject.Forms;

/// <summary>
/// Represents a form for displaying and editing anime details.
/// </summary>
public partial class AnimeDetailsForm : Form
{
    // Reference to the AnimeService for managing anime data.
    private readonly AnimeService _animeService;

    // Holds the current anime being edited or viewed.
    private Anime _currentAnime;

    // Indicates whether the form is in update mode (editing an existing anime) or create mode (adding a new anime).
    private bool IsUpdateMode => _currentAnime != null;

    public AnimeDetailsForm(AnimeService service, Anime animeToEdit)
    {
        InitializeComponent();
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
        // Load all genres from the AnimeService and populate the CheckedListBox.
        await LoadGenres();

        if (IsUpdateMode)
        {
            PopulateFields();
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

        // Create a new Anime object or use the existing one based on the mode
        var animeToSave = IsUpdateMode ? _currentAnime : new Anime();

        animeToSave.Title = txtTitle.Text.Trim();
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
}

