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
    private Anime _animeToEdit;

    // Indicates whether the form is in update mode (editing an existing anime) or create mode (adding a new anime).
    private bool IsUpdateMode => _animeToEdit != null;

    public AnimeDetailsForm(AnimeDbContext context, AnimeService service, Anime animeToEdit = null)
    {
        InitializeComponent();
        btnSave.Click += btnSave_Click;
        this.Load += AnimeDetailsForm_Load;
        _context = context;
        _animeService = service;
        _animeToEdit = animeToEdit;

    }

    /// <summary>
    /// Handles the Load event of the AnimeDetailsForm.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private async void AnimeDetailsForm_Load(object sender, EventArgs e)
    {
        // Fetch available genres asynchronously
        var availableGenres = await _context.Genres.OrderBy(g => g.Name).ToListAsync();

        // Clear the box and add the objects (Done exactly once!)
        clbGenres.Items.Clear();
        foreach (var genre in availableGenres)
        {
            clbGenres.Items.Add(genre);
        }

        // Set the display and value members
        clbGenres.DisplayMember = "Name";
        clbGenres.ValueMember = "Id";

        // If we are updating an existing anime, load it
        if (IsUpdateMode && _animeToEdit != null)
        {
            await LoadExistingAnimeDataAsync();
        }
    }

    /// <summary>
    /// Loads the data for an existing anime into the form.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    private async Task LoadExistingAnimeDataAsync()
    {
        if (_animeToEdit == null) return;

        // Pre-fill the standard text boxes immediately
        txtTitle.Text = _animeToEdit.Title;
        txtSynopsis.Text = _animeToEdit.Synopsis;
        cmbTvRating.SelectedValue = _animeToEdit.TvRating;
        numEpisodes.Value = (int)_animeToEdit.Episodes;
        numPublicationYear.Value = (int)_animeToEdit.PublicationYear;
        int safeYear = _animeToEdit.ReleaseYear > 0 ? _animeToEdit.ReleaseYear : DateTime.Now.Year;
        dtpReleaseDate.Value = new DateTime(safeYear, 1, 1);


        // Fetch the attached genres asynchronously
        var animeWithGenres = await _context.Animes
                                        .Where(a => a.Id == _animeToEdit.Id)
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
        string titleToCheckInvariant = titleToCheck.ToLowerInvariant();

        // Only check for duplicates if we are adding a new anime not updating an existing one
        if (!IsUpdateMode)
        {
            bool isDuplicate = await _context.Animes.AnyAsync(a => a.Title.ToLowerInvariant() == titleToCheck.ToLowerInvariant());
            if (isDuplicate)
            {
                MessageBox.Show($"'{titleToCheck}' is already in the database.", "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Stops the save operation if a duplicate is found
                return;
            }
        }

        // Create a new Anime object or use the existing one based on the mode
        var animeToSave = IsUpdateMode ? _animeToEdit : new Anime();

        animeToSave.Title = titleToCheck;
        animeToSave.Synopsis = txtSynopsis.Text.Trim();
        animeToSave.TvRating = cmbTvRating.Text;
        animeToSave.Episodes = (int)numEpisodes.Value;
        animeToSave.PublicationYear = (int)numPublicationYear.Value;
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

    /// <summary>
    /// Handles the click event of the Manage Genres button. 
    /// It opens the GenreManagementForm as a modal dialog, 
    /// allowing the user to manage genres.
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
    /// Handles the click event of the Edit Anime button. It hides the button, 
    /// creates a new AnimeEditControl, centers it on the form, 
    /// and adds it to the form's controls. When the edit control is disposed, 
    /// the button is made visible again.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private void btnEditAnime_Click(object sender, EventArgs e)
    {
        
        // Hide the edit button so they can't click it twice
        btnEditAnime.Visible = false;

        // Instantiate the new edit control
        AnimeEditControl editControl = new AnimeEditControl();

        editControl.LoadAnimeData(_animeService, _animeToEdit);

        // Set the size and appearance of the edit control
        editControl.BorderStyle = BorderStyle.FixedSingle;
        editControl.BackColor = Color.FromArgb(45, 45, 45);

        // Center the control on the form
        editControl.Location = new Point(
            (this.ClientSize.Width - editControl.Width) / 10,
            (this.ClientSize.Height - editControl.Height) / 2
        );

        // Tell the form to bring the button back when the edit control closes!
        editControl.Disposed += (s, args) =>
        {
            btnEditAnime.Visible = true;
        };

        // Add it to the form and bring it to the front
        this.Controls.Add(editControl);
        editControl.BringToFront();
    }
}

