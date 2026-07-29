using System;
using System.Collections.Generic;
using System.Text;

namespace TeamPiZAZCPW211TeamProject.Models;

public class Studio
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ICollection<Anime> Animes { get; set; } = [];
}

