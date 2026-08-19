using Microsoft.EntityFrameworkCore;
using TeamPiZAZCPW211TeamProject.Models;

namespace TeamPiZAZCPW211TeamProject.Database;

/// <summary>
/// Represents a service for adding new Anime records to the database asynchronously.
/// </summary>
public class AddAnimeASync
{
    private readonly AnimeDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddAnimeASync"/> class with the specified database context.
    /// </summary>
    /// <param name="context">The database context.</param>
    public AddAnimeASync(AnimeDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Adds a new Anime record to the database asynchronously.
    /// </summary>
    /// <param name="anime">The Anime to add.</param>
    /// <returns>Returns a Task representing the asynchronous operation.</returns>
    public async Task AddAnimeAsync(Anime anime)
    {
        // Create a new Anime entity.
        var newAnime = new Anime
        {
            Title = anime.Title,
            Synopsis = anime.Synopsis,
            ReleaseYear = anime.ReleaseYear,
            TvRating = anime.TvRating,
            Episodes = anime.Episodes,
            PublicationYear = anime.PublicationYear,
            StudioId = anime.StudioId
        };

        // Associate any selected Genres.
        foreach (var genre in anime.Genres)
        {
            var dbGenre = await _context.Genres.FindAsync(genre.Id);

            if (dbGenre != null)
            {
                newAnime.Genres.Add(dbGenre);
            }
        }

        // Add the Anime to the database.
        _context.Animes.Add(newAnime);

        // Save the changes.
        await _context.SaveChangesAsync();
    }
}

