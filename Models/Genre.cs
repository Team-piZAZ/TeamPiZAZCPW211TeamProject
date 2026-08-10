using System;
using System.Collections.Generic;
using System.Text;

namespace TeamPiZAZCPW211TeamProject.Models;

/// <summary>
/// Represents a Genre entity in the database, which can be associated with multiple Anime entities.
/// </summary>
public class Genre
{

    /// <summary>
    /// Gets or sets the unique identifier for the Genre.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the Genre.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the Genre.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the collection of Anime entities associated with this Genre.
    /// </summary>
    public ICollection<Anime> Animes { get; set; } = [];

    public override string ToString() => Name;
}

