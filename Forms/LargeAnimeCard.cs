using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TeamPiZAZCPW211TeamProject.Models;
using System.Windows.Forms;

namespace TeamPiZAZCPW211TeamProject.Forms;

/// <summary>
/// Represents a user control that displays detailed information about an anime.
/// </summary>
public partial class LargeAnimeCard : UserControl
{
    public LargeAnimeCard()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Loads the full details of the specified anime into the user control.
    /// </summary>
    /// <param name="anime">The anime to display.</param>
    public void LoadFullDetails(Anime anime)
    {
        if (anime == null) return;

        lblTitle.Text = anime.Title;
        lblSynopsis.Text = anime.Synopsis;
        lblTvRating.Text = $"TV Rating: {anime.TvRating}";
        lblEpisodes.Text = $"Episodes: {anime.Episodes}";
        lblPublicationYear.Text = $"Published: {anime.PublicationYear}";
        lblReleaseYear.Text = $"Released: {anime.ReleaseYear}";

        // Picture logic goes here later.
    }
}
