using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TeamPiZAZCPW211TeamProject.Models;
using TeamPiZAZCPW211TeamProject.Services;
using TeamPiZAZCPW211TeamProject.Database;
using Microsoft.EntityFrameworkCore;

namespace TeamPiZAZCPW211TeamProject;

public partial class SmallAnimeCard : UserControl
{

    public int AnimeId { get; private set; }
    public SmallAnimeCard()
    {
        InitializeComponent();
    }

    public void SetupCard(Anime anime)
    {
        AnimeId = anime.Id;
        lblTitle.Text = anime.Title;
        lblRating.Text = anime.TvRating;
    }
}
