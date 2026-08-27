using Microsoft.EntityFrameworkCore;
using System.Data;
using TeamPiZAZCPW211TeamProject.Database;
using TeamPiZAZCPW211TeamProject.Forms;
using TeamPiZAZCPW211TeamProject.Models;
using TeamPiZAZCPW211TeamProject.Services;

namespace TeamPiZAZCPW211TeamProject;

/// <summary>
/// Represents a form that displays a list of anime 
/// and allows filtering by title, studio, and genre.
/// </summary>
public partial class AnimeListForm : Form
{
    // The database context used to access anime, studio, and genre data.
    private readonly AnimeDbContext _context;

    public AnimeListForm(AnimeDbContext context)
    {
        InitializeComponent();
        _context = context;
    }


    /// <summary>
    /// Handles the Load event of the AnimeListForm.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private async void AnimeListForm_Load(object sender, EventArgs e)
    {
        // Setup Predictive Text 
        var titles = await _context.Animes.Select(a => a.Title).ToArrayAsync(); // Sync
        var autoCompleteData = new AutoCompleteStringCollection();
        autoCompleteData.AddRange(titles);

        txtAnimeName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        txtAnimeName.AutoCompleteSource = AutoCompleteSource.CustomSource;
        txtAnimeName.AutoCompleteCustomSource = autoCompleteData;

        // Populate the Studio Dropdown
        var studios = await _context.Studios.OrderBy(s => s.Name).ToListAsync(); // Sync
        studios.Insert(0, new Studio { Id = 0, Name = "All Studios" });

        cmbStudio.DataSource = studios;
        cmbStudio.DisplayMember = "Name";
        cmbStudio.ValueMember = "Id";

        // Populate the Genre Dropdown
        var genres = await _context.Genres.OrderBy(g => g.Name).ToListAsync(); // Sync
        genres.Insert(0, new Genre { Id = 0, Name = "All Genres" });

        cmbGenre.DataSource = genres;
        cmbGenre.DisplayMember = "Name";
        cmbGenre.ValueMember = "Id";
    }


    /// <summary>
    /// Handles the click event for the "Add to List" button.
    /// Opens the AnimeDetailsForm for adding a new anime.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private void btnAddToList_Click(object sender, EventArgs e)
    {
        AnimeService service = new AnimeService(_context);

        // FIX: Removed the 'null' parameter because AnimeDetailsForm no longer accepts it!
        using (AnimeDetailsForm detailsForm = new AnimeDetailsForm(_context, service))
        {
            detailsForm.ShowDialog();
        }

    }


    /// <summary>
    /// Handles the click event for the "Search" button.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private async void btnSearch_Click(object sender, EventArgs e)
    {
        flpAnimeList.Controls.Clear();

        // Start with the base query as IQueryable (don't execute it yet!)
        var query = _context.Animes
            .Include(a => a.Genres)
            .AsQueryable();

        // Filter by Title
        string searchText = txtAnimeName.Text.Trim().ToLower();
        if (!string.IsNullOrWhiteSpace(searchText))
        {
            // Let SQL server handle the case-insensitivity natively
            query = query.Where(a => a.Title.Contains(txtAnimeName.Text.Trim()));
        }

        // Filter by Studio (if they didn't select "All Studios" which is Id 0)
        if (cmbStudio.SelectedValue is int studioId && studioId > 0)
        {
            query = query.Where(a => a.StudioId == studioId);
        }

        // Filter by Genre (if they didn't select "All Genres" which is Id 0)
        if (cmbGenre.SelectedValue is int genreId && genreId > 0)
        {
            query = query.Where(a => a.Genres.Any(g => g.Id == genreId));
        }

        // NOW execute the query against the database
        var searchResults = await query.ToListAsync();

        // Generate the small cards
        DisplayAnime(searchResults);

        // Auto-load the first result if we found anything
        if (searchResults.Any())
        {
            mainLargeCard.LoadFullDetails(searchResults.First());
        }
        else
        {
            // clear the large card if no results are found
            mainLargeCard.Hide();
        }
    }


    /// <summary>
    /// Handles the click event for a small anime card.
    /// </summary>
    /// <param name="clickedAnimeId">The ID of the clicked anime.</param>
    private void SmallCard_Clicked(int clickedAnimeId)
    {
        var fullAnime = _context.Animes.Include(a => a.Genres).FirstOrDefault(a => a.Id == clickedAnimeId);

        if (fullAnime != null)
        {
            mainLargeCard.LoadFullDetails(fullAnime);
            mainLargeCard.Show();
        }
    }


    /// <summary>
    /// Displays a list of anime in the FlowLayoutPanel as small cards.
    /// </summary>
    /// <param name="animeList">The list of anime to display.</param>
    private void DisplayAnime(List<Anime> animeList)
    {
        flpAnimeList.Controls.Clear();

        foreach (var anime in animeList)
        {
            SmallAnimeCard card = new SmallAnimeCard();
            card.SetupCard(anime);
            card.OnCardClicked += SmallCard_Clicked;
            flpAnimeList.Controls.Add(card);
        }
    }
}