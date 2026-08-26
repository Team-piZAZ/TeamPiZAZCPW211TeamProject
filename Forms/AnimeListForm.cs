using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
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

    private async void AnimeListForm_Load(object sender, EventArgs e)
    {
        // 1. Setup Predictive Text for the Title Search
        var titles = await _context.Animes.Select(a => a.Title).ToArrayAsync();
        var autoCompleteData = new AutoCompleteStringCollection();
        autoCompleteData.AddRange(titles);

        txtAnimeName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        txtAnimeName.AutoCompleteSource = AutoCompleteSource.CustomSource;
        txtAnimeName.AutoCompleteCustomSource = autoCompleteData;

        // 2. Populate the Studio Dropdown (Add an "All Studios" default)
        var studios = await _context.Studios.OrderBy(s => s.Name).ToListAsync();
        studios.Insert(0, new Studio { Id = 0, Name = "All Studios" });

        cmbStudio.DataSource = studios;
        cmbStudio.DisplayMember = "Name";
        cmbStudio.ValueMember = "Id";

        // 3. Populate the Genre Dropdown (Add an "All Genres" default)
        var genres = await _context.Genres.OrderBy(g => g.Name).ToListAsync();
        genres.Insert(0, new Genre { Id = 0, Name = "All Genres" });

        cmbGenre.DataSource = genres;
        cmbGenre.DisplayMember = "Name";
        cmbGenre.ValueMember = "Id";
    }

    private void btnAddToList_Click(object sender, EventArgs e)
    {
        AnimeService service = new AnimeService(_context);

        // FIX: Removed the 'null' parameter because AnimeDetailsForm no longer accepts it!
        using (AnimeDetailsForm detailsForm = new AnimeDetailsForm(_context, service))
        {
            detailsForm.ShowDialog();
        }

    }

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
            mainLargeCard.Hide();
        }
    }

    private void SmallCard_Clicked(int clickedAnimeId)
    {
        var fullAnime = _context.Animes.Include(a => a.Genres).FirstOrDefault(a => a.Id == clickedAnimeId);

        if (fullAnime != null)
        {
            mainLargeCard.LoadFullDetails(fullAnime);
            mainLargeCard.Show();
        }
    }

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