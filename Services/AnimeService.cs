using Microsoft.EntityFrameworkCore;
using TeamPiZAZCPW211TeamProject.Database;
using TeamPiZAZCPW211TeamProject.Models;

namespace TeamPiZAZCPW211TeamProject.Services;



/// <summary>
/// Service implementation handling database CRUD operations for Anime entities.
/// Uses Entity Framework Core to perform async operations on the database.
/// </summary>
public class AnimeService : IAnimeService
{
    private readonly AnimeDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="AnimeService"/> class.
    /// Injects the database context via Dependency Injection.
    /// </summary>
    /// <param name="context">
    /// The database context instance
    /// </param>
    public AnimeService(AnimeDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves all Anime records from the database,
    /// including their associated Studio and Genres.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a list of Anime entities.
    /// </returns>
    public async Task<List<Anime>> GetAllAnimeAsync()
    {
        return await _context.Animes
            .Include(a => a.Studio)
            .Include(a => a.Genres)
            .AsNoTracking()
            .ToListAsync();
    }


    /// <summary>
    /// Finds a specific Anime by its ID, including its associated Studio and Genres.
    /// </summary>
    /// <param name="id">
    /// The primary key of the Anime to retrieve.
    /// </param>
    /// <returns>
    /// The matching <see cref="Anime"/> instance if found; otherwise, null. 
    /// </returns>
    public async Task<Anime?> GetAnimeByIdAsync(int id)
    {
        return await _context.Animes
            .Include(a => a.Studio)
            .Include(a => a.Genres)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    /// <summary>
    /// Retrieves all Genre records from the database.
    /// </summary>
    /// <returns>
    /// a list of <see cref="Genre"/> entities.
    /// </returns>
    public async Task<List<Genre>> GetAllGenresAsync()
    {
        // Use AsNoTracking for read-only queries to improve performance
        return await _context.Genres.AsNoTracking().ToListAsync();
    }

    /// <summary>
    /// Adds a new Anime record to the database, along with its associated Genres.
    /// </summary>
    /// <param name="anime">
    /// The Anime entity to save.
    /// </param>
    /// <param name="selectedGenreIds">
    /// List of genre IDs selected from the UI to associate with the Anime.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    public async Task AddAnimeAsync(Anime anime, List<int> selectedGenreIds)
    {
        if (selectedGenreIds.Count != 0)
        {
            var genres = await _context.Genres
                .Where(g => selectedGenreIds.Contains(g.Id))
                .ToListAsync();

            anime.Genres = genres;
        }

        _context.Animes.Add(anime);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Updates an existing anime's details and updates its 
    /// many-to-many relationship with genres based on the selected genre IDs.
    /// </summary>
    /// <param name="anime">
    /// The Anime entity with updated details.
    /// </param>
    /// <param name="selectedGenreIds">
    /// List of genre IDs selected from the UI to associate with the Anime.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    public async Task UpdateAnimeAsync(Anime anime, List<int> selectedGenreIds)
    {
        // Retrieve the existing anime from the database, including its associated genres
        var existingAnime = await _context.Animes
            .Include(a => a.Genres)
            .FirstOrDefaultAsync(a => a.Id == anime.Id);

        // If the anime does not exist, exit the method
        if (existingAnime == null) return;

        // Update scalar properties
        existingAnime.Title = anime.Title;
        existingAnime.Synopsis = anime.Synopsis;
        existingAnime.ReleaseYear = anime.ReleaseYear;
        existingAnime.TvRating = anime.TvRating;
        existingAnime.Episodes = anime.Episodes;
        existingAnime.PublicationYear = anime.PublicationYear;
        existingAnime.StudioId = anime.StudioId;

        // Reset the existing genres and add the updated genres based on selectedGenreIds
        existingAnime.Genres.Clear();
        var updatedGenres = await _context.Genres
            .Where(g => selectedGenreIds.Contains(g.Id))
            .ToListAsync();

        foreach (var genre in updatedGenres)
        {
            existingAnime.Genres.Add(genre);
        }

        // Save the changes to the database
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes an Anime record from the database based on its ID.(primary key)
    /// </summary>
    /// <param name="id">
    /// The ID of the Anime to delete.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    public async Task DeleteAnimeAsync(int id)
    {
        // Find the anime by its ID and remove it from the database if it exists
        var anime = await _context.Animes.FindAsync(id);
        if (anime != null)
        {
            _context.Animes.Remove(anime);
            await _context.SaveChangesAsync();
        }
    }
}