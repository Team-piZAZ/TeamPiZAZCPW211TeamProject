using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;
using TeamPiZAZCPW211TeamProject.Forms;
using TeamPiZAZCPW211TeamProject.Models;
using TeamPiZAZCPW211TeamProject.Services;
using TeamPiZAZCPW211TeamProject.Database;
using System.Windows.Forms;


namespace TeamPiZAZCPW211TeamProject;

/// <summary>
/// Represents a form that displays a list of anime 
/// and allows filtering by title, studio, and genre.
/// </summary>
public partial class AnimeListForm : Form
{
    // The database context used to access anime, studio, and genre data.
    private readonly AnimeDbContext _context;

    // MultiCheckDropdown controls for selecting studios and genres.
    private MultiCheckDropdown<Studio> _clbStudio;

    // MultiCheckDropdown control for selecting genres.
    private MultiCheckDropdown<Genre> _clbGenre;

    // Filters for studios, genres, and title search.
    private List<Studio> _studioFilter = new();

    // Filter for genres.
    private List<Genre> _genreFilter = new();

    // Filter for title search.
    private string _titleFilter = "";

    /// <summary>
    /// Initializes a new instance of the <see cref="AnimeListForm"/> class with the specified database context.
    /// </summary>
    /// <param name="context">The database context to use.</param>
    public AnimeListForm(AnimeDbContext context)
    {
        InitializeComponent();
        _context = context;
        this.mainLargeCard = mainLargeCard;
    }

    /// <summary>
    /// Handles the Load event of the AnimeListForm control. 
    /// Initializes the MultiCheckDropdown controls for Studio and Genre,
    /// populates them with data from the database context, 
    /// and sets up event handlers for selection changes.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private async void AnimeListForm_Load(object sender, EventArgs e)
    {
        // 1. Setup Predictive Text for the Title Search
        var titles = await _context.Animes.Select(a => a.Title).ToArrayAsync();
        var autoCompleteData = new AutoCompleteStringCollection();
        autoCompleteData.AddRange(titles);

        txtAnimeName.AutoCompleteMode = AutoCompleteMode.SuggestAppend; // Predicts and drops down a list
        txtAnimeName.AutoCompleteSource = AutoCompleteSource.CustomSource;
        txtAnimeName.AutoCompleteCustomSource = autoCompleteData;

        // 2. Populate the Studio Dropdown (Add an "All Studios" default)
        var studios = await _context.Studios.OrderBy(s => s.Name).ToListAsync();
        studios.Insert(0, new Studio { Id = 0, Name = "All Studios" }); // Dummy record for 'All'

        cmbStudio.DataSource = studios;
        cmbStudio.DisplayMember = "Name";
        cmbStudio.ValueMember = "Id";

        // 3. Populate the Genre Dropdown (Add an "All Genres" default)
        var genres = await _context.Genres.OrderBy(g => g.Name).ToListAsync();
        genres.Insert(0, new Genre { Id = 0, Name = "All Genres" }); // Dummy record for 'All'

        cmbGenre.DataSource = genres;
        cmbGenre.DisplayMember = "Name";
        cmbGenre.ValueMember = "Id";
    }

    private void btnAddToList_Click(object sender, EventArgs e)
    {
        AnimeService service = new AnimeService(_context);

        using (AnimeDetailsForm detailsForm = new AnimeDetailsForm(_context, service, null))
        {
            detailsForm.ShowDialog();
        }

        ApplyFilters();
    }

    private void txtAnimeName_TextChanged(object sender, EventArgs e)
    {
        _titleFilter = txtAnimeName.Text.Trim();
        ApplyFilters();
    }

    private void GenreChanged(object sender, EventArgs e)
    {
        _genreFilter = _clbGenre.CheckedItems.ToList();
        ApplyFilters();
    }

    private void StudioChanged(object sender, EventArgs e)
    {
        _studioFilter = _clbStudio.CheckedItems.ToList();
        ApplyFilters();
    }

    private void ApplyFilters()
    {
        var filtered = _context.Animes.AsEnumerable();

        if (!string.IsNullOrEmpty(_titleFilter))
        {
            filtered = filtered.Where(a => a.Title.Contains(_titleFilter, StringComparison.OrdinalIgnoreCase));
        }
        if (_studioFilter.Any())
        {
            filtered = filtered.Where(a => _studioFilter.Contains(a.Studio));
        }
        if (_genreFilter.Any())
        {
            filtered = filtered.Where(a => _genreFilter.All(g => a.Genres.Contains(g)));
        }
        DisplayAnime(filtered.ToList());
    }

    
    private void DisplayAnime(List<Anime> animeList)
    {
        // Clear out the old UI elements
        flpAnimeList.Controls.Clear();

        foreach (var anime in animeList)
        {
            // Instantiate your custom UserControl
            SmallAnimeCard card = new SmallAnimeCard();

            // Pass the anime data to the card (you may need to create a public method 
            // inside SmallAnimeCard.cs to accept this data and update its labels/images)
            card.SetupCard(anime);

            card.OnCardClicked += SmallCard_Clicked;

            // Add the finished card to your flow layout panel
            flpAnimeList.Controls.Add(card);
        }
    }

    private async void btnSearch_Click(object sender, EventArgs e)
    {
        flpAnimeList.Controls.Clear();

        // Start with the base query as IQueryable (don't execute it yet!)
        // We Include Genres here so we can filter by them.
        var query = _context.Animes
            .Include(a => a.Genres)
            .AsQueryable();

        // Filter by Title (if they typed something)
        string? searchText = txtAnimeName.Text.Trim().ToLowerInvariant();
        if (!string.IsNullOrWhiteSpace(searchText))
        {
            query = query.Where(a => a.Title.ToLower().Contains(searchText));
        }

        // Filter by Studio (if they didn't select "All Studios" which is Id 0)
        if (cmbStudio.SelectedValue is int studioId && studioId > 0)
        {
            query = query.Where(a => a.StudioId == studioId);
        }

        // Filter by Genre (if they didn't select "All Genres" which is Id 0)
        // Because it's a many-to-many relationship, we use .Any()
        if (cmbGenre.SelectedValue is int genreId && genreId > 0)
        {
            query = query.Where(a => a.Genres.Any(g => g.Id == genreId));
        }

        // NOW execute the query against the database
        var searchResults = await query.ToListAsync();

        // Generate the small cards (Same as before)
        foreach (var anime in searchResults)
        {
            var newCard = new SmallAnimeCard();
            newCard.SetupCard(anime);
            newCard.OnCardClicked += SmallCard_Clicked;
            flpAnimeList.Controls.Add(newCard);
        }

        // Auto-load the first result if we found anything
        if (searchResults.Any())
        {
            mainLargeCard.LoadFullDetails(searchResults.First());
        }
        else
        {
            // clear the large card if no results are found
            mainLargeCard.Hide(); // Or create a Clear() method on your large card

        }

    }

    private void SmallCard_Clicked(int clickedAnimeId)
    {

        var fullAnime = _context.Animes.Include(a => a.Genres).FirstOrDefault(a => a.Id == clickedAnimeId);

        if (fullAnime != null)
        {

            mainLargeCard.LoadFullDetails(fullAnime);

            // Force the card to become visible in case it was hidden!
            mainLargeCard.Show();
        }
    }



    private void lblTvRating_Click(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void lblGenre_Click(object sender, EventArgs e)
    {

    }
}
