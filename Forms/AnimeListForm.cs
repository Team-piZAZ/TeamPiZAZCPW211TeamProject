using System.Drawing.Text;
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
    private readonly Database.AnimeDbContext _context;

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
    public AnimeListForm(Database.AnimeDbContext context)
    {
        InitializeComponent();
        _context = context;
    }

    /// <summary>
    /// Handles the Load event of the AnimeListForm control. 
    /// Initializes the MultiCheckDropdown controls for Studio and Genre,
    /// populates them with data from the database context, 
    /// and sets up event handlers for selection changes.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private void AnimeListForm_Load(object sender, EventArgs e)
    {
        _clbStudio = new MultiCheckDropdown<Studio>();
        _clbStudio.Location = new Point(lblStudio.Right + 10, lblStudio.Top);

        foreach (var studio in _context.Studios)
        {
            _clbStudio.AddItem(studio);
        }

        // Subscribe to the SelectionChanged event of the _clbStudio control
        _clbStudio.SelectionChanged += StudioChanged;

        Controls.Add(_clbStudio);

        _clbGenre = new MultiCheckDropdown<Genre>();
        _clbGenre.Location = new Point(lblGenre.Right + 10, lblGenre.Top);

        foreach (var genre in _context.Genres)
        {
            _clbGenre.AddItem(genre);
        }

        // Subscribe to the SelectionChanged event of the _clbGenre control
        _clbGenre.SelectionChanged += GenreChanged;

        Controls.Add(_clbGenre);
        ApplyFilters();
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
        // Clear existing controls in the FlowLayoutPanel
        flpAnimeList.Controls.Clear();

        // Loop through the filtered anime list and create a button for each anime
        foreach (Anime anime in animeList)
        {
            // Create a new button for the anime
            Button animeCard = new Button();
            animeCard.Text = anime.Title;
            animeCard.Size = new Size(150, 50);
            animeCard.BackColor = Color.FromArgb(30, 30, 30);
            animeCard.ForeColor = Color.White;
            animeCard.FlatStyle = FlatStyle.Flat;
            animeCard.FlatAppearance.BorderColor = Color.Magenta;
            animeCard.Margin = new Padding(5);

            flpAnimeList.Controls.Add(animeCard);
        }

    }

    private void lblTvRating_Click(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }
}
