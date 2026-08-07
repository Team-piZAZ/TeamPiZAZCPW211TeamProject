namespace TeamPiZAZCPW211TeamProject.Models;

/// <summary>
/// Represents the parameters used for filtering, sorting, and paginating Anime records in the database.
/// </summary>
public class AnimeFilterParams
{
    // Default values for pagination default to page 1 and 10 items per page
    public int PageNumber { get; set; } = 1;

    public int PageSize { get; set; } = 10;

    // Search term for filtering by title, studio, or genre
    public string? SearchTerm { get; set; }

    // SortBy property to specify the field to sort by, defaulting to "Title"
    public string SortBy { get; set; } = "Title";

    // Descending property to specify the sort order, defaulting to false (ascending)
    public bool Descending { get; set; }
}

