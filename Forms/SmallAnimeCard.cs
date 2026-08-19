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


    public event Action<int> OnCardClicked;

    /// <summary>
    /// Initializes a new instance of the <see cref="SmallAnimeCard"/> 
    /// class and sets up event handlers for click events on the card and its labels.
    /// </summary>
    public SmallAnimeCard()
    {
        InitializeComponent();

        this.Click += Card_Click;
        lblTitle.Click += Card_Click;
        lblRating.Click += Card_Click;
    }

    /// <summary>
    /// Sets up the card with the provided Anime object, populating the title and rating labels.
    /// </summary>
    /// <param name="anime">The Anime object to use for populating the card.</param>
    public void SetupCard(Anime anime)
    {
        AnimeId = anime.Id;
        lblTitle.Text = anime.Title;
        lblRating.Text = anime.TvRating;
    }

    /// <summary>
    /// Handles the click event for the card and invokes the OnCardClicked event with the AnimeId.
    /// When anything is clicked on the card, it will trigger this event and pass the AnimeId to any subscribers.
    /// </summary>
    /// <param name="sender">A reference to the control that raised the event.</param>
    /// <param name="e">An EventArgs object that contains the event data.</param>
    private void Card_Click(object sender, EventArgs e)
    {
        OnCardClicked?.Invoke(AnimeId);
    }
}
