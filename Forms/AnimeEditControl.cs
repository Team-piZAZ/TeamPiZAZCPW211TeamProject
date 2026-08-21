using System.Data;
using TeamPiZAZCPW211TeamProject.Services;
using TeamPiZAZCPW211TeamProject.Models;
using TeamPiZAZCPW211TeamProject.Database;
using Microsoft.EntityFrameworkCore;

namespace TeamPiZAZCPW211TeamProject.Forms;

public partial class AnimeEditControl : UserControl
{
    // ErrorProvider to display validation errors
    private readonly ErrorProvider _errorProvider = new();

    // Private field to hold the currently selected anime for editing
    private Anime _animeToEdit;

    // Service for handling anime-related operations, such as updating anime details
    private IAnimeService _animeService;


    // Constructor for the AnimeEditControl, initializing the database context and setting up event handlers
    public AnimeEditControl()
    {
        InitializeComponent();
        btnSearch.Click += btnSearch_Click;
        btnCancelChanges.Click += btnCancelChanges_Click;
        ConfigureErrorProvider();
        RegisteredValidationEvents();
    }

    public void LoadAnimeData(IAnimeService animeService, Anime animeToEdit)
    {
        _animeService = animeService;
        _animeToEdit = animeToEdit;
    }

    /// <summary>
    /// Configures the ErrorProvider to display validation errors 
    /// without blinking and associates it with the current control.
    /// </summary>
    private void ConfigureErrorProvider()
    {
        // Set the blink style to never blink to avoid distracting the user
        _errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

        // Associate the ErrorProvider with the current control to display errors for its child controls
        _errorProvider.ContainerControl = this;

    }


    /// <summary>
    /// Registers validation event handlers for the input fields to ensure
    /// that user input meets the required criteria before allowing changes to be saved.
    /// </summary>
    private void RegisteredValidationEvents()
    {
        // Registering the Validating event handlers for the input fields to perform validation when the user attempts to leave the field
        txtTitle.Validating += txtTitle_Validating;

        // Registering the Validating event handler for the Publication Year field to ensure it is a valid integer and falls within the acceptable range
        dtpPublicationYear.Validating += dtpPublicationYear_Validating;

        // Registering the Validating event handler for the Episodes field to ensure it is a valid whole number greater than 0
        numEpisodes.Validating += numEpisodes_Validating;

        // Registering the Validating event handler for the TV Rating field to ensure it is not empty and provides a valid rating
        cmbEditTvRating.Validating += cmbEditTvRating_Validating;

        // Registering the Validating event handler for the Synopsis field to ensure it is not empty and provides a brief description of the anime
        txtSynopsis.Validating += txtSynopsis_Validating;
    }



    // Event handler for the Load event of the AnimeEditControl, setting up autocomplete for the search textbox
    private async void AnimeEditControl_Load(object sender, EventArgs e)
    {
        if (_animeService == null) return;

        var allAnime = await _animeService.GetAllAnimeAsync();
        var titles = allAnime.Select(a => a.Title).Distinct().ToArray();
        var autoCompleteData = new AutoCompleteStringCollection();
        autoCompleteData.AddRange(titles);

        txtEditSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        txtEditSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
        txtEditSearch.AutoCompleteCustomSource = autoCompleteData;
    }


    // Event handler for the Click event of the search button, searching for an anime by title and populating the form fields with its details
    private async void btnSearch_Click(object sender, EventArgs e)
    {
        string searchTitle = txtEditSearch.Text.Trim();

        var allAnime = await _animeService.GetAllAnimeAsync();

        // Search for the anime by title in the database
        _animeToEdit = allAnime.FirstOrDefault(a => a.Title.Equals(searchTitle, StringComparison.OrdinalIgnoreCase));

        if (_animeToEdit == null)
        {
            MessageBox.Show("Anime not found. Please try another title.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        // Populate the text boxes with the anime details
        txtTitle.Text = _animeToEdit.Title;
        txtSynopsis.Text = _animeToEdit.Synopsis;
        cmbEditTvRating.Text = _animeToEdit.TvRating;

        // ensure the publication year is valid and set the DateTimePicker value accordingly
        int pubYear = _animeToEdit.PublicationYear > DateTime.MinValue.Year ? _animeToEdit.PublicationYear : DateTime.Now.Year;
        dtpPublicationYear.Value = new DateTime(_animeToEdit.PublicationYear, 1, 1);


        numEpisodes.Value = Math.Max(numEpisodes.Minimum, _animeToEdit.Episodes);

    }



    // Event handler for the Click event of the cancel button, removing the control from its parent and disposing of it
    private void btnCancelChanges_Click(object sender, EventArgs e)
    {
        this.Parent?.Controls.Remove(this);
        this.Dispose();

    }

    // Event handler for the Click event of the save changes button, validating input and saving changes to the database
    // Step 2: Rewrite your btnSaveChanges_Click event handler
    // This consolidates the save logic and uses the strongly-typed control values.

    private async void btnSaveChanges_Click(object sender, EventArgs e)
    {
        // Run Validation
        if (HasValidationErrors())
        {
            MessageBox.Show(
                "Please resolve all validation errors marked with an exclamation icon before saving.",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
            return;
        }

        // Map UI to Entity using strongly typed values
        _animeToEdit.Title = txtTitle.Text.Trim();
        _animeToEdit.Synopsis = txtSynopsis.Text.Trim();
        _animeToEdit.TvRating = cmbEditTvRating.Text.Trim();
        _animeToEdit.Episodes = (int)numEpisodes.Value;

        // Use .Value instead of parsing .Text
        _animeToEdit.PublicationYear = dtpPublicationYear.Value.Year;
        _animeToEdit.Episodes = (int)numEpisodes.Value;

        // Preserve existing genres
        List<int> existingGenreIds = _animeToEdit.Genres.Select(g => g.Id).ToList();

        // Single Persistence Path
        try
        {
            btnSaveChanges.Enabled = false;

            // Remove any raw _context calls here. Only use the service.
            await _animeService.UpdateAnimeAsync(_animeToEdit, existingGenreIds);

            MessageBox.Show("Anime details successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while saving changes: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnSaveChanges.Enabled = true;
        }
    }

    // Below are the Validation event handlers for the various input fields,
    // ensuring that user input meets the required criteria before allowing changes to be saved.




    /// <summary>
    /// Validates the Title field to ensure it is not empty and does not exceed 200 characters.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A System.ComponentModel.CancelEventArgs that contains the event data.</param>
    private void txtTitle_Validating(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        // Check if the Title field is empty or exceeds 200 characters and set the appropriate error message
        if (string.IsNullOrWhiteSpace(txtTitle.Text))
        {
            _errorProvider.SetError(txtTitle, "Title cannot be empty.");
        }
        // Check if the Title field exceeds 200 characters and set the appropriate error message
        else if (txtTitle.Text.Trim().Length > 200)
        {
            _errorProvider.SetError(txtTitle, "Title cannot exceed 200 characters.");

        }
        // If the Title field is valid, clear any existing error messages
        else
        {
            _errorProvider.SetError(txtTitle, string.Empty);
        }
    }


    /// <summary>
    /// Validates the Publication Year field to ensure it is a valid 
    /// integer and falls within the acceptable range (1950 to current year + 2).
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A System.ComponentModel.CancelEventArgs that contains the event data.</param>
    private void dtpPublicationYear_Validating(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        // Check if the Publication Year is within the acceptable range and set the appropriate error message
        int year = dtpPublicationYear.Value.Year;

        // Check if the Publication Year is less than 1950 or greater than the current year + 2 and set the appropriate error message
        if (year < 1950 || year > DateTime.Now.Year + 2)
        {
            _errorProvider.SetError(dtpPublicationYear, $"Release Year must be between 1950 and {DateTime.Now.Year + 2}.");
        }

        // If the Publication Year is valid, clear any existing error messages
        else
        {
            _errorProvider.SetError(dtpPublicationYear, string.Empty);
        }
    }



    /// <summary>
    /// Validates the Episodes field to ensure it is a valid whole number greater than 0.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A System.ComponentModel.CancelEventArgs that contains the event data.</param>
    private void numEpisodes_Validating(object? sender, System.ComponentModel.CancelEventArgs e)
    {

        // Check if the Episodes field is less than or equal to 0 and set the appropriate error message
        if (numEpisodes.Value <= 0)
        {
            _errorProvider.SetError(numEpisodes, "Episodes must be greater than 0.");
        }

        // If the Episodes field is valid, clear any existing error messages
        else
        {
            _errorProvider.SetError(numEpisodes, string.Empty);
        }
    }


    /// <summary>
    /// Validates the TV Rating field to ensure it is not empty and provides a valid rating (e.g., TV-14, TV-MA).
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A System.ComponentModel.CancelEventArgs that contains the event data.</param>
    private void cmbEditTvRating_Validating(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        // Check if the TV Rating field is empty and set the appropriate error message
        if (string.IsNullOrWhiteSpace(cmbEditTvRating.Text))
        {
            _errorProvider.SetError(cmbEditTvRating, "TV Rating is required (e.g., TV-14, TV-MA).");
        }

        // If the TV Rating field is valid, clear any existing error messages
        else
        {
            _errorProvider.SetError(cmbEditTvRating, string.Empty);
        }
    }



    /// <summary>
    /// Validates the Synopsis field to ensure it is not empty and provides a brief description of the anime.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A System.ComponentModel.CancelEventArgs that contains the event data.</param>
    private void txtSynopsis_Validating(object? sender, System.ComponentModel.CancelEventArgs e)
    {

        // Check if the Synopsis field is empty and set the appropriate error message
        if (string.IsNullOrWhiteSpace(txtSynopsis.Text))
        {
            _errorProvider.SetError(txtSynopsis, "Synopsis / Description is required.");
        }

        // If the Synopsis field is valid, clear any existing error messages
        else
        {
            _errorProvider.SetError(txtSynopsis, string.Empty);
        }
    }

    /// <summary>
    /// Checks if there are any validation errors in the input fields by validating each control and checking for error messages.
    /// </summary>
    /// <returns>True if there are validation errors, false otherwise.</returns>
    private bool HasValidationErrors()
    {

        // Validate all child controls to ensure they meet the required criteria
        if (!ValidateChildren(ValidationConstraints.Enabled))
        {
            return true;
        }

        // Create an array of controls to validate for errors
        Control[] controlsToValidate = [txtTitle,  dtpPublicationYear, numEpisodes, cmbEditTvRating, txtSynopsis];

        // Check each control for validation errors by checking if the ErrorProvider has any error messages associated with it
        foreach (Control control in controlsToValidate)
        {

            // If the ErrorProvider has an error message for the control, return true indicating that there are validation errors
            if (!string.IsNullOrEmpty(_errorProvider.GetError(control)))
            {
                return true;
            }
        }

        // If no validation errors are found, return false indicating that all input fields are valid
        return false;
    }


}
