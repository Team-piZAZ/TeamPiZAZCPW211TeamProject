using Microsoft.EntityFrameworkCore;
using TeamPiZAZCPW211TeamProject.Database;
using TeamPiZAZCPW211TeamProject.Models;
using TeamPiZAZCPW211TeamProject.Services;
using Xunit;


namespace TeamPiZAZ.Tests;

public class AnimeServiceTests
{

    /// <summary>
    /// Creates a new instance of AnimeDbContext configured to use an in-memory database for testing purposes.
    /// </summary>
    /// <returns>A new instance of AnimeDbContext</returns>
    private async Task<AnimeDbContext> GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<AnimeDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        var context = new AnimeDbContext(options);
        await context.Database.EnsureCreatedAsync();
        return context;
    }


    /// <summary>
    /// Tests the AddAnimeAsync method of AnimeService to ensure that a valid Anime object is added to the database correctly.
    /// </summary>
    /// <returns>A task representing the asynchronous operation</returns>
    [Fact]
    public async Task AddAnimeAsync_ValidAnime_AddsToDatabase()
    {
        // Arrange
        var dbContext = await GetInMemoryDbContext();
        var service = new AnimeService(dbContext);
        var newAnime = new Anime { Title = "Cowboy Bebop", Episodes = 26 };
        var genreIds = new List<int>();

        // Act
        await service.AddAnimeAsync(newAnime, genreIds);

        // Assert
        var result = await dbContext.Animes.FirstOrDefaultAsync(a => a.Title == "Cowboy Bebop");
        Assert.NotNull(result);
        Assert.Equal(26, result.Episodes);
    }


    /// <summary>
    /// Tests the GetAllAnimeAsync method of AnimeService to ensure that it returns all records from the database.
    /// </summary>
    /// <returns>The list of all Anime objects in the database</returns>
    [Fact]
    public async Task GetAllAnimeAsync_ReturnsAllRecords()
    {
        // Arrange
        var dbContext = await GetInMemoryDbContext();

        // Nuke any seed data EF Core auto-loads during EnsureCreatedAsync()
        dbContext.Animes.RemoveRange(dbContext.Animes);
        await dbContext.SaveChangesAsync();

        dbContext.Animes.Add(new Anime { Title = "Trigun" });
        dbContext.Animes.Add(new Anime { Title = "Outlaw Star" });
        await dbContext.SaveChangesAsync();

        var service = new AnimeService(dbContext);

        // Act
        var result = await service.GetAllAnimeAsync();

        // Assert
        Assert.Equal(2, result.Count);
    }


    /// <summary>
    /// Tests the DeleteAnimeAsync method of AnimeService to ensure that an existing Anime record is removed from the database correctly.
    /// </summary>
    /// <returns>A task representing the asynchronous operation</returns>
    [Fact]
    public async Task DeleteAnimeAsync_ExistingId_RemovesFromDatabase()
    {
        // Arrange
        var dbContext = await GetInMemoryDbContext();
        var animeToDelete = new Anime { Id = 1, Title = "FLCL" };
        dbContext.Animes.Add(animeToDelete);
        await dbContext.SaveChangesAsync();

        var service = new AnimeService(dbContext);

        // Act
        await service.DeleteAnimeAsync(1);

        // Assert
        var result = await dbContext.Animes.FindAsync(1);
        Assert.Null(result);
    }


    /// <summary>
    /// Tests the GetFilteredAnimeAsync method of AnimeService to ensure that it correctly filters Anime records based on the provided title search string.
    /// </summary>
    /// <returns>The list of filtered Anime objects</returns>
    [Fact]
    public async Task FilterAnime_ByTitle_ReturnsOnlyMatchingTitles()
    {
        // Arrange
        var dbContext = await GetInMemoryDbContext();
        dbContext.Animes.RemoveRange(dbContext.Animes); // Nuke seed data
        await dbContext.SaveChangesAsync();

        dbContext.Animes.Add(new Anime { Title = "Attack on Titan" });
        dbContext.Animes.Add(new Anime { Title = "Neon Genesis Evangelion" });
        dbContext.Animes.Add(new Anime { Title = "Ghost in the Shell" });
        await dbContext.SaveChangesAsync();

        var service = new AnimeService(dbContext);

        // Act
        // Note: Change 'GetFilteredAnimeAsync' and its parameters to match your actual method signature
        var result = await service.GetFilteredAnimeAsync(titleSearch: "Titan", studioId: 0, genreId: 0);

        // Assert
        Assert.Single(result); // Stricter than Assert.Equal(1, count) - guarantees exactly one record
        Assert.Equal("Attack on Titan", result.First().Title);
    }


    /// <summary>
    /// Tests the GetFilteredAnimeAsync method of AnimeService to ensure that it correctly filters Anime records based on the provided studio ID.
    /// </summary>
    /// <returns>The list of filtered Anime objects</returns>
    [Fact]
    public async Task FilterAnime_ByStudio_ReturnsOnlyStudioMatches()
    {
        // Arrange
        var dbContext = await GetInMemoryDbContext();
        dbContext.Animes.RemoveRange(dbContext.Animes);
        await dbContext.SaveChangesAsync();

        dbContext.Animes.Add(new Anime { Title = "Spirited Away", StudioId = 1 });
        dbContext.Animes.Add(new Anime { Title = "Princess Mononoke", StudioId = 1 });
        dbContext.Animes.Add(new Anime { Title = "Akira", StudioId = 2 });
        await dbContext.SaveChangesAsync();

        var service = new AnimeService(dbContext);

        // Act
        var result = await service.GetFilteredAnimeAsync(titleSearch: "", studioId: 1, genreId: 0);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.DoesNotContain(result, a => a.Title == "Akira");
    }


    /// <summary>
    /// Tests the GetFilteredAnimeAsync method of AnimeService to ensure that it correctly filters Anime records based on the provided genre ID.
    /// </summary>
    /// <returns>The list of filtered Anime objects</returns>
    [Fact]
    public async Task FilterAnime_ByGenre_ReturnsOnlyGenreMatches()
    {
        // Arrange
        var dbContext = await GetInMemoryDbContext();
        dbContext.Animes.RemoveRange(dbContext.Animes);
        dbContext.Genres.RemoveRange(dbContext.Genres);
        await dbContext.SaveChangesAsync();

        // Mocking the genre relationship
        var actionGenre = new Genre { Id = 1, Name = "Action" };
        var romanceGenre = new Genre { Id = 2, Name = "Romance" };

        dbContext.Animes.Add(new Anime { Title = "Jujutsu Kaisen", Genres = new List<Genre> { actionGenre } });
        dbContext.Animes.Add(new Anime { Title = "Your Name", Genres = new List<Genre> { romanceGenre } });
        await dbContext.SaveChangesAsync();

        var service = new AnimeService(dbContext);

        // Act
        var result = await service.GetFilteredAnimeAsync(titleSearch: "", studioId: 0, genreId: 1);

        // Assert
        Assert.Single(result);
        Assert.Equal("Jujutsu Kaisen", result.First().Title);
    }


    /// <summary>
    /// Tests the GetFilteredAnimeAsync method of AnimeService to ensure that it
    /// returns an empty list when no Anime records match the provided title search string.
    /// </summary>
    /// <returns>The list of filtered Anime objects</returns>
    [Fact]
    public async Task GetFilteredAnimeAsync_NoMatchingTitle_ReturnsEmptyList()
    {
        // Arrange
        var dbContext = await GetInMemoryDbContext();
        dbContext.Animes.RemoveRange(dbContext.Animes);
        await dbContext.SaveChangesAsync();

        dbContext.Animes.Add(new Anime { Title = "Naruto" });
        await dbContext.SaveChangesAsync();

        var service = new AnimeService(dbContext);

        // Act
        var result = await service.GetFilteredAnimeAsync(titleSearch: "Bleach", studioId: 0, genreId: 0);

        // Assert
        Assert.Empty(result);
    }


    /// <summary>
    /// Tests the GetFilteredAnimeAsync method of AnimeService to ensure that it
    /// returns an empty list when the provided filter IDs are invalid.
    /// </summary>
    /// <returns>The list of filtered Anime objects</returns>
    [Fact]
    public async Task GetFilteredAnimeAsync_InvalidFilterIds_ReturnsEmptyList()
    {
        // Arrange
        var dbContext = await GetInMemoryDbContext();
        dbContext.Animes.RemoveRange(dbContext.Animes);
        dbContext.Studios.RemoveRange(dbContext.Studios);
        dbContext.Genres.RemoveRange(dbContext.Genres);
        await dbContext.SaveChangesAsync();

        // One Piece belongs to Studio 1
        dbContext.Animes.Add(new Anime { Title = "One Piece", StudioId = 1 });
        await dbContext.SaveChangesAsync();

        var service = new AnimeService(dbContext);

        // Act
        // Searching for StudioId 99 and GenreId 99, which do not exist
        var result = await service.GetFilteredAnimeAsync(titleSearch: "", studioId: 99, genreId: 99);

        // Assert
        Assert.Empty(result);
    }


    /// <summary>
    /// Tests the AddAnimeAsync method of AnimeService to ensure that it throws
    /// an ArgumentException when attempting to add an Anime with a blank title.
    /// </summary>
    /// <returns>The list of filtered Anime objects</returns>
    [Fact]
    public async Task AddAnimeAsync_BlankTitle_ThrowsArgumentException()
    {
        // Arrange
        var dbContext = await GetInMemoryDbContext();
        var service = new AnimeService(dbContext);
        var badAnime = new Anime { Title = "   ", Episodes = 12 };
        var genreIds = new List<int>();

        // Act & Assert
        // xUnit intercepts the exception so the test passes instead of crashing
        await Assert.ThrowsAsync<ArgumentException>(() => service.AddAnimeAsync(badAnime, genreIds));
    }


    /// <summary>
    /// Tests the AddAnimeAsync method of AnimeService to ensure that it throws
    /// an ArgumentException when attempting to add an Anime with a negative number of episodes.
    /// </summary>
    /// <returns>The list of filtered Anime objects</returns>
    [Fact]
    public async Task AddAnimeAsync_NegativeEpisodes_ThrowsArgumentException()
    {
        // Arrange
        var dbContext = await GetInMemoryDbContext();
        var service = new AnimeService(dbContext);
        var badAnime = new Anime { Title = "Trigun", Episodes = -1 };
        var genreIds = new List<int>();

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => service.AddAnimeAsync(badAnime, genreIds));
    }

    [Fact]
    public async Task UpdateAnimeAsync_ExistingAnime_SuccessfullyUpdates()
    {
        // Arrange
        var dbContext = await GetInMemoryDbContext();
        dbContext.Animes.RemoveRange(dbContext.Animes); // Nuke seed data
        await dbContext.SaveChangesAsync();

        // Seed a valid record
        var originalAnime = new Anime { Title = "One Punch Man", Episodes = 12 };
        dbContext.Animes.Add(originalAnime);
        await dbContext.SaveChangesAsync();

        var service = new AnimeService(dbContext);

        // Act
        // We simulate the user changing the title and episode count in the UI
        originalAnime.Title = "One Punch Man Season 2";
        originalAnime.Episodes = 24;

        // Pass the modified object to the service layer.
        // Adjust the parameters if your method signature requires genre IDs!
        await service.UpdateAnimeAsync(originalAnime, new List<int>());

        // Assert
        var result = await dbContext.Animes.FindAsync(originalAnime.Id);
        Assert.NotNull(result);
        Assert.Equal("One Punch Man Season 2", result.Title);
        Assert.Equal(24, result.Episodes);
    }

    [Fact]
    public async Task UpdateAnimeAsync_NonExistentAnime_ThrowsKeyNotFoundException()
    {
        // Arrange
        var dbContext = await GetInMemoryDbContext();
        var service = new AnimeService(dbContext);

        // Creating an anime with an ID that definitely does not exist in the DB
        var ghostAnime = new Anime { Id = 999, Title = "Made Up Anime", Episodes = 1 };
        var genreIds = new List<int>();

        // Act & Assert
        // We expect the service to reject this update request cleanly
        await Assert.ThrowsAsync<KeyNotFoundException>(() => service.UpdateAnimeAsync(ghostAnime, genreIds));
    }
}