using System;
using System.Collections.Generic;
using System.Text;

namespace TeamPiZAZCPW211TeamProject.Models;

/// <summary>
/// Represents a Studio entity in the database, 
/// which can be associated with multiple Anime entities.
/// </summary>
public class Studio
{
    /// <summary>
    /// Gets or sets the unique identifier for the Studio.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the Studio.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the Studio.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the collection of Anime entities associated with this Studio.
    /// </summary>
    public ICollection<Anime> Animes { get; set; } = [];
}

