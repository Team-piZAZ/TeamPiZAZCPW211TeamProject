using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using TeamPiZAZCPW211TeamProject.Database;
using TeamPiZAZCPW211TeamProject.Models;

namespace TeamPiZAZCPW211TeamProject.Forms;

public partial class AnimeEditControl : UserControl
{

    // Dependency Injection: Accepting the DbContext in the constructor
    private readonly AnimeDbContext _context;
    private readonly ErrorProvider _errorProvider = new();
    private Anime _animeToEdit;


    /// <summary>
    /// Initializes a new instance of the <see cref="AnimeEditControl"/> 
    /// class with the specified database context.
    /// </summary>
    /// <param name="context">The database context to use.</param>
    public AnimeEditControl(AnimeDbContext context)
    {
        InitializeComponent();
        _context = context;

        // Wire up the main events
        this.Load += AnimeEditControl_Load;
        btnSearch.Click += btnSearch_Click;
        btnSaveChanges.Click += btnSaveChanges_Click;
        btnCancelChanges.Click += btnCancelChanges_Click;

        ConfigureErrorProvider();
        RegisteredValidationEvents();
    }


    /// <summary>
    /// Configures the ErrorProvider to never blink and sets the container control to this user control.
    /// </summary>
    private void ConfigureErrorProvider()
    {
        _errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        _errorProvider.ContainerControl = this;
    }


    /// <summary>
    /// Registers the Validating event handlers for the input controls
    /// to perform validation when the user attempts to leave the control.
    /// </summary>
    private void RegisteredValidationEvents()
    {
        txtTitle.Validating += txtTitle_Validating;
        dtpPublicationYear.Validating += dtpPublicationYear_Validating;
        numEpisodes.Validating += numEpisodes_Validating;
        cmbEditTvRating.Validating += cmbEditTvRating_Validating;
        txtSynopsis.Validating += txtSynopsis_Validating;
    }


    /// <summary>
    /// Handles the Load event of the AnimeEditControl. This method 
    /// sets up predictive search for anime titles directly from the database context.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private async void AnimeEditControl_Load(object sender, EventArgs e)
    {
        // Setup predictive search directly from the DB Context
        var titles = await _context.Animes.Select(a => a.Title).Distinct().ToArrayAsync();
        var autoCompleteData = new AutoCompleteStringCollection();
        autoCompleteData.AddRange(titles);

        txtEditSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        txtEditSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
        txtEditSearch.AutoCompleteCustomSource = autoCompleteData;
    }


    /// <summary>
    /// Handles the Click event of the btnSearch control.
    /// Searches for an anime by title and loads its details into
    /// the form for editing, including its associated genres.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private async void btnSearch_Click(object sender, EventArgs e)
    {
        string searchTitle = txtEditSearch.Text.Trim();

        // Search for the anime and MUST include genres
        _animeToEdit = await _context.Animes.Include(a => a.Genres).FirstOrDefaultAsync(a => a.Title == searchTitle);

        if (_animeToEdit == null)
        {
            MessageBox.Show("Anime not found. Please try another title.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        // Populate the standard text boxes
        txtTitle.Text = _animeToEdit.Title;
        txtSynopsis.Text = _animeToEdit.Synopsis;
        cmbEditTvRating.Text = _animeToEdit.TvRating;

        // Handle the bad year data bug
        int safeYear = _animeToEdit.PublicationYear;
        if (safeYear < 1 || safeYear > 9999)
        {
            safeYear = 2000;
        }
        dtpPublicationYear.Value = new DateTime(safeYear, 1, 1);
        numEpisodes.Value = Math.Max(numEpisodes.Minimum, _animeToEdit.Episodes);

        // Populate the checkboxes
        if (_animeToEdit.Genres != null)
        {
            // Reset the board from any previous searches
            for (int i = 0; i < clbEditGenres.Items.Count; i++)
            {
                clbEditGenres.SetItemChecked(i, false);
            }

            // Check the matching genres
            for (int i = 0; i < clbEditGenres.Items.Count; i++)
            {
                Genre item = (Genre)clbEditGenres.Items[i];
                if (_animeToEdit.Genres.Any(g => g.Id == item.Id))
                {
                    clbEditGenres.SetItemChecked(i, true);
                }
            }
        }
    }


    /// <summary>
    /// Handles the Click event of the btnSaveChanges control. This method validates the input,
    /// updates the anime's information, and saves the changes to the database.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private async void btnSaveChanges_Click(object sender, EventArgs e)
    {
        // Check rules BEFORE saving
        if (HasValidationErrors())
        {
            MessageBox.Show("Please fix the highlighted errors before saving.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (_animeToEdit == null)
        {
            MessageBox.Show("Please search for and load an anime to edit first.", "No Anime Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Map the data safely
        _animeToEdit.Title = txtTitle.Text;
        _animeToEdit.Synopsis = txtSynopsis.Text;
        _animeToEdit.PublicationYear = dtpPublicationYear.Value.Year;
        _animeToEdit.Episodes = (int)numEpisodes.Value;
        _animeToEdit.TvRating = cmbEditTvRating.Text;

        // Wipe the existing relationship clean
        _animeToEdit.Genres.Clear();

        // Grab the newly checked IDs from the UI
        var selectedGenreIds = clbEditGenres.CheckedItems
                                            .Cast<Genre>()
                                            .Select(g => g.Id)
                                            .ToList();

        // Fetch the official tracked genres and attach them
        if (selectedGenreIds.Any())
        {
            var trackedGenres = await _context.Genres
                                            .Where(g => selectedGenreIds.Contains(g.Id))
                                            .ToListAsync();

            _animeToEdit.Genres = trackedGenres;
        }

        // Save and safely close
        try
        {
            await _context.SaveChangesAsync();
            MessageBox.Show("Anime updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Parent?.Controls.Remove(this);
            this.Dispose();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while saving: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


    /// <summary>
    /// Handles the Click event of the btnCancelChanges control. This method
    /// removes the user control from its parent and disposes of it, 
    /// effectively canceling any changes made.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private void btnCancelChanges_Click(object sender, EventArgs e)
    {
        this.Parent?.Controls.Remove(this);
        this.Dispose();
    }

    // --- VALIDATION METHODS BELOW ---


    /// <summary>
    /// Validates the title input field to ensure it is not empty and does not exceed 200 characters.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private void txtTitle_Validating(object? sender, CancelEventArgs e)
    {
        // Check for empty or whitespace title
        if (string.IsNullOrWhiteSpace(txtTitle.Text))
        {
            _errorProvider.SetError(txtTitle, "Title cannot be empty.");
        }
        // Check for title length exceeding 200 characters
        else if (txtTitle.Text.Trim().Length > 200)
        {
            _errorProvider.SetError(txtTitle, "Title cannot exceed 200 characters.");
        }
        // Clear the error if validation passes
        else
        {
            _errorProvider.SetError(txtTitle, string.Empty);
        }
    }


    /// <summary>
    /// Validates the publication year input field to ensure 
    /// it is between 1950 and two years beyond the current year.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private void dtpPublicationYear_Validating(object? sender, CancelEventArgs e)
    {
        // Check if the selected year is within the valid range
        int year = dtpPublicationYear.Value.Year;
        if (year < 1950 || year > DateTime.Now.Year + 2)
        {
            _errorProvider.SetError(dtpPublicationYear, $"Release Year must be between 1950 and {DateTime.Now.Year + 2}.");
        }
        // Clear the error if validation passes
        else
        {
            _errorProvider.SetError(dtpPublicationYear, string.Empty);
        }
    }


    /// <summary>
    /// Validates the number of episodes input field to ensure it is greater than 0.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private void numEpisodes_Validating(object? sender, CancelEventArgs e)
    {
        // Check if the number of episodes is greater than 0
        if (numEpisodes.Value <= 0)
        {
            _errorProvider.SetError(numEpisodes, "Episodes must be greater than 0.");
        }
        // Clear the error if validation passes
        else
        {
            _errorProvider.SetError(numEpisodes, string.Empty);
        }
    }


    /// <summary>
    /// Validates the TV rating input field to ensure it is not empty.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private void cmbEditTvRating_Validating(object? sender, CancelEventArgs e)
    {
        // Check if the TV rating is empty
        if (string.IsNullOrWhiteSpace(cmbEditTvRating.Text))
        {
            _errorProvider.SetError(cmbEditTvRating, "TV Rating is required (e.g., TV-14, TV-MA).");
        }
        // Clear the error if validation passes
        else
        {
            _errorProvider.SetError(cmbEditTvRating, string.Empty);
        }
    }


    /// <summary>
    /// Validates the synopsis input field to ensure it is not empty.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private void txtSynopsis_Validating(object? sender, CancelEventArgs e)
    {
        // Check if the synopsis is empty
        if (string.IsNullOrWhiteSpace(txtSynopsis.Text))
        {
            _errorProvider.SetError(txtSynopsis, "Synopsis / Description is required.");
        }
        // Clear the error if validation passes
        else
        {
            _errorProvider.SetError(txtSynopsis, string.Empty);
        }
    }


    /// <summary>
    /// Checks if any of the input controls have validation errors.
    /// </summary>
    /// <returns><c>true</c> if there are validation errors; otherwise, <c>false</c>.</returns>
    private bool HasValidationErrors()
    {
        // Validate all child controls to ensure their validation events are triggered
        if (!ValidateChildren(ValidationConstraints.Enabled))
        {
            return true;
        }

        // Check if any of the controls have an error set in the ErrorProvider
        Control[] controlsToValidate = [txtTitle, dtpPublicationYear, numEpisodes, cmbEditTvRating, txtSynopsis];

        // Iterate through each control and check for validation errors
        foreach (Control control in controlsToValidate)
        {
            // If the ErrorProvider has an error message for the control, return true
            if (!string.IsNullOrEmpty(_errorProvider.GetError(control)))
            {
                return true;
            }
        }

        return false;
    }
}