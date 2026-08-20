using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TeamPiZAZCPW211TeamProject.Services;
using TeamPiZAZCPW211TeamProject.Models;
using TeamPiZAZCPW211TeamProject.Database;
using Microsoft.EntityFrameworkCore;

namespace TeamPiZAZCPW211TeamProject.Forms;

public partial class AnimeEditControl : UserControl
{

    private readonly AnimeDbContext _context = new AnimeDbContext();
    public AnimeEditControl(AnimeDbContext context)
    {
        InitializeComponent();
        _context = context;
    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {

    }

    private async void AnimeEditControl_Load(object sender, EventArgs e)
    {
        var titles = await _context.Animes.Select(a => a.Title).Distinct().ToArrayAsync();
        var autoCompleteData = new AutoCompleteStringCollection();
        autoCompleteData.AddRange(titles);

        txtEditSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        txtEditSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
        txtEditSearch.AutoCompleteCustomSource = autoCompleteData;
    }

    private Anime _animeToEdit;

    private async void btnSearch_Click(object sender, EventArgs e)
    {
        string searchTitle = txtEditSearch.Text;

        // Search for the anime by title in the database
        _animeToEdit = await _context.Animes.FirstOrDefaultAsync(a => a.Title == searchTitle);

        if (_animeToEdit == null)
        {
            MessageBox.Show("Anime not found. Please try another title.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        // Populate the text boxes with the anime details
        txtTitle.Text = _animeToEdit.Title;
        txtSynopsis.Text = _animeToEdit.Synopsis;


        dtpPublicationYear.Value = new DateTime(_animeToEdit.PublicationYear, 1, 1);

        
        numEpisodes.Value = Math.Max(numEpisodes.Minimum, _animeToEdit.Episodes);


        cmbEditTvRating.Text = _animeToEdit.TvRating;

    }
}
