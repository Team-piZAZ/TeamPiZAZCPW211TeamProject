using Microsoft.EntityFrameworkCore;
using TeamPiZAZCPW211TeamProject.Models;


namespace TeamPiZAZCPW211TeamProject.Database;

/// <summary>
/// Represents a service for updating Anime records in the database asynchronously.
/// </summary>
public class UpdateAnimeAsync
{

    private readonly AnimeDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateAnimeAsync"/> class.
    /// </summary>
    /// <param name="context">The database context used to interact with the Anime database.</param>
    public UpdateAnimeAsync(AnimeDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Updates an existing Anime record in the database with the provided Anime object.
    /// </summary>
    /// <param name="anime">The Anime object containing the updated information.</param>
    /// <returns>The updated Anime object.</returns>
    public async Task UpdateAnime(Anime anime)
    {
        // Retrieve the existing Anime from the database.
        var existingAnime = await _context.Animes
            .FirstOrDefaultAsync(a => a.Id == anime.Id);

        // Exit if the Anime could not be found.
        if (existingAnime == null)
        {
            return;
        }

        // Explicitly load the Genres collection.
        await _context.Entry(existingAnime)
            .Collection(a => a.Genres)
            .LoadAsync();

        // Update scalar properties.
        existingAnime.Title = anime.Title;
        existingAnime.Synopsis = anime.Synopsis;
        existingAnime.ReleaseYear = anime.ReleaseYear;
        existingAnime.TvRating = anime.TvRating;
        existingAnime.StudioId = anime.StudioId;
        existingAnime.Episodes = anime.Episodes;
        existingAnime.PublicationYear = anime.PublicationYear;

        // Remove all existing Genre relationships.
        existingAnime.Genres.Clear();

        // Reattach the selected Genres from the database.
        foreach (var genre in anime.Genres)
        {
            var dbGenre = await _context.Genres.FindAsync(genre.Id);

            if (dbGenre != null)
            {
                existingAnime.Genres.Add(dbGenre);
            }
        }

        // Save the updated record.
        await _context.SaveChangesAsync();
    }
}

