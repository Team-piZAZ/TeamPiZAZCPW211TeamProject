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
        btnDeleteAnime.Click += btnLaunchDeleteControl_Click;
    }

    private void btnLaunchDeleteControl_Click(object sender, EventArgs e)
    {
        AnimeDeleteControl deleteControl = new AnimeDeleteControl(_context);

        // Center it on the screen
        deleteControl.Left = (this.ClientSize.Width - deleteControl.Width) / 2;
        deleteControl.Top = (this.ClientSize.Height - deleteControl.Height) / 2;

        this.Controls.Add(deleteControl);
        deleteControl.BringToFront();
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
        // 1. Grab the exact text with proper capitalization for saving
        string properCaseTitle = txtTitle.Text.Trim();

        // 2. The Duplicate Check (Compare them both in lowercase)
        bool titleExists = await _context.Animes.AnyAsync(a => a.Title.ToLower() == properCaseTitle.ToLower());

        if (titleExists)
        {
            MessageBox.Show("This anime already exists in the database!", "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // 3. Create the new Anime using the PROPER CASE title
        Anime newAnime = new Anime
        {
            Title = properCaseTitle,
            Synopsis = txtSynopsis.Text.Trim(),
            PublicationYear = (int)numPublicationYear.Value,
            ReleaseYear = dtpReleaseDate.Value.Year,
            Episodes = (int)numEpisodes.Value,
            TvRating = cmbTvRating.Text,
            // If you have a Studio ID dropdown, map it here too: StudioId = (int)cmbStudio.SelectedValue,

            Genres = new List<Genre>() //Initialize the list so it's not null!
        };

        // Safely attach the genres
        // Grab the IDs of whatever the user checked in your custom dropdown
        var selectedGenreIds = clbGenres.CheckedItems.Cast<Genre>().Select(g => g.Id).ToList();

        if (selectedGenreIds.Any())
        {
            // Ask the database for the official tracking versions of those genres
            var trackedGenres = await _context.Genres.Where(g => selectedGenreIds.Contains(g.Id)).ToListAsync();

            // Add the officially tracked genres to our new anime the EF Core way (so it knows to save the relationship)
            foreach (var genre in trackedGenres)
            {
                newAnime.Genres.Add(genre);
            }
        }

        // 5. Save everything to SQL Server
        try
        {
            _context.Animes.Add(newAnime);
            await _context.SaveChangesAsync();

            MessageBox.Show("Anime added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); // Or whatever logic you use to reset the form
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        AnimeEditControl editControl = new AnimeEditControl(_context);

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

    private async Task btnDeleteAnime_ClickAsync(object sender, EventArgs e)
    {
        
    }
}

