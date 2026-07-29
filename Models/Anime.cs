using System;
using System.Collections.Generic;
using System.Text;

namespace TeamPiZAZCPW211TeamProject.Models;

public class Anime
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Synopsis { get; set; } = string.Empty;

    public int ReleaseYear { get; set; }

    public double Rating { get; set; }

    public int? StudioId { get; set; }

    public Studio? Studio { get; set; }

    public ICollection<Genre> Genres { get; set; } = new List<Genre>();
}

