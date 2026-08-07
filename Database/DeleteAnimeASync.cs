namespace TeamPiZAZCPW211TeamProject.Database;

/// <summary>
/// Represents a service for deleting Anime records from the database asynchronously.
/// </summary>
public class DeleteAnimeASync
{
    private readonly AnimeDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteAnimeASync"/> class with the specified database context.
    /// </summary>
    /// <param name="context">The database context.</param>
    public DeleteAnimeASync(AnimeDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Deletes an Anime record from the database based on its primary key (id).
    /// </summary>
    /// <param name="id">The primary key of the Anime to delete.</param>
    /// <returns>Returns a Task representing the asynchronous operation.</returns>
    public async Task DeleteAnimeAsync(int id)
    {
        // Locate the Anime by its primary key.
        var anime = await _context.Animes.FindAsync(id);

        // Exit if the Anime does not exist.
        if (anime == null)
        {
            return;
        }

        // Remove the Anime from the database.
        _context.Animes.Remove(anime);

        // Save the changes.
        await _context.SaveChangesAsync();
    }

}

