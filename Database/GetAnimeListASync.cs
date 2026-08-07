using Microsoft.EntityFrameworkCore;
using TeamPiZAZCPW211TeamProject.Models;

namespace TeamPiZAZCPW211TeamProject.Database;

/// <summary>
/// Represents a service for retrieving a list of Anime records from the database asynchronously, with support for filtering, sorting, and pagination.
/// </summary>
public class GetAnimeListASync
{
    private readonly AnimeDbContext _context;

    public GetAnimeListASync(AnimeDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves a list of Anime records from the database asynchronously based on the provided filter parameters, including pagination and optional search term filtering.
    /// </summary>
    /// <param name="filterParams">The filter parameters to apply.</param>
    /// <returns>Returns a Task representing the asynchronous operation.</returns>
    public async Task<List<Anime>> GetAnimeList(AnimeFilterParams filterParams)
    {
        // Ensure valid pagination values so that if 0 or negative gets passed,
        // everything will still work
        filterParams.PageNumber = Math.Max(filterParams.PageNumber, 1);
        filterParams.PageSize = Math.Max(filterParams.PageSize, 1);

        // Alternate to limit the records request (Uncomment if you want to use it)
        // filterParams.PageSize = Math.Clamp(filterParams.PageSize, 1, 100);

        // Begin building the query.
        IQueryable<Anime> query = _context.Animes
            .Include(a => a.Studio);

        // Filter by title if a search term was provided.
        if (!string.IsNullOrWhiteSpace(filterParams.SearchTerm))
        {
            string searchTerm = filterParams.SearchTerm.Trim();
            query = query.Where(a => a.Title.Contains(searchTerm));
        }

        // Apply sorting before pagination.
        query = query.OrderBy(a => a.Title);

        // Apply pagination.
        query = query
            .Skip((filterParams.PageNumber - 1) * filterParams.PageSize)
            .Take(filterParams.PageSize);

        // Execute the query.
        return await query
            .AsNoTracking()
            .ToListAsync();
    }
}