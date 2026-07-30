using TeamPiZAZCPW211TeamProject.Models;

namespace TeamPiZAZCPW211TeamProject.Services;

/// <summary>
/// Defines the contract for data operations related to Anime entities and genres.
/// Acts as an abstraction layer between the UI and Entity Framework Core database context.
/// </summary>
public interface IAnimeService
{
    /// <summary>
    /// Asynchronously retrieves a list of all Anime entities from the database.
    /// Along with the Anime entities, it also includes their associated genres and studios.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a list of all Anime entities.
    /// </returns>
    Task<List<Anime>> GetAllAnimeAsync();

    /// <summary>
    /// Asynchronously retrieves a specific Anime entity by its unique identifier (id).
    /// </summary>
    /// <param name="id">
    /// The unique identifier of the Anime to retrieve.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the requested Anime entity, or null if not found.
    /// </returns>
    Task<Anime?> GetAnimeByIdAsync(int id);

    /// <summary>
    /// Asynchronously retrieves a list of all Genre entities from the database.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a list of all Genre entities.
    /// </returns>
    Task<List<Genre>> GetAllGenresAsync();

    /// <summary>
    /// Asynchronously adds a new Anime entity to the database along with its associated genres.
    /// </summary>
    /// <param name="anime">
    /// The Anime entity to add.
    /// </param>
    /// <param name="selectedGenreIds">
    /// The IDs of the genres associated with the Anime.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    Task AddAnimeAsync(Anime anime, List<int> selectedGenreIds);

    /// <summary>
    /// Asynchronously updates an existing Anime entity in the database along with its associated genres.
    /// </summary>
    /// <param name="anime">
    /// The Anime entity containing modified properties to update in the database.
    /// </param>
    /// <param name="selectedGenreIds">
    /// The updated list of genre IDs associated with the Anime.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    Task UpdateAnimeAsync(Anime anime, List<int> selectedGenreIds);

    /// <summary>
    /// Asynchronously deletes an Anime entity from the database based on its unique identifier (id).
    /// </summary>
    /// <param name="id">
    /// The unique identifier of the Anime to delete.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    Task DeleteAnimeAsync(int id);
}
