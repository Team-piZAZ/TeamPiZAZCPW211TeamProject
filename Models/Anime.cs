namespace TeamPiZAZCPW211TeamProject.Models;

/// <summary>
/// Represents an Anime entity in the database, which can be associated with a Studio and multiple Genres.
/// </summary>
public class Anime
{

    /// <summary>
    /// Gets or sets the unique identifier for the Anime.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the Anime.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the synopsis of the Anime.
    /// </summary>
    public string Synopsis { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the release year of the Anime.
    /// </summary>
    public int ReleaseYear { get; set; }

    /// <summary>
    /// Gets or sets the TV rating of the Anime.
    /// </summary>
    public string TvRating { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the foreign key for the associated Studio entity.
    /// </summary>
    public int? StudioId { get; set; }

    /// <summary>
    /// Gets or sets the associated Studio entity for the Anime.
    /// </summary>
    public Studio? Studio { get; set; }

    /// <summary>
    /// Gets or sets the number of episodes in the Anime.
    /// </summary>
    public int Episodes { get; set; }

    /// <summary>
    /// Gets or sets the publication year of the Anime.
    /// </summary>
    public int PublicationYear { get; set; }


    /// <summary>
    /// Gets or sets the collection of Genre entities associated with this Anime.
    /// </summary>
    public ICollection<Genre> Genres { get; set; } = new List<Genre>();
}

