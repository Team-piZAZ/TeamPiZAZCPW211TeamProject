using Microsoft.EntityFrameworkCore;
using System.Data;
using TeamPiZAZCPW211TeamProject.Database;
using TeamPiZAZCPW211TeamProject.Models;


namespace TeamPiZAZCPW211TeamProject.Forms;

public partial class GenreManagementForm : Form
{
    private readonly AnimeDbContext _context;

    public GenreManagementForm(AnimeDbContext context)
    {
        InitializeComponent();
        _context = context;
    }

    private void GenreManagementForm_Load(object sender, EventArgs e)
    {
        LoadGenres();
    }

    /// <summary>
    /// Loads the genres from the database and binds them to the list box.
    /// </summary>
    private void LoadGenres()
    {
        lstGenres.DataSource = null;
        lstGenres.DataSource = _context.Genres.OrderBy(g => g.Name).ToList();
        lstGenres.DisplayMember = "Name";
    }

    /// <summary>
    /// Handles the click event of the "Add" button. Adds a new genre to the database if it doesn't already exist.
    /// </summary>
    /// <param name="sender">A reference to the button that raised the event.</param>
    /// <param name="e">A reference to the event arguments.</param>
    private void btnAdd_Click(object sender, EventArgs e)
    {
        string newName = txtGenreName.Text.Trim();

        if (string.IsNullOrEmpty(newName)) return;

        // Prevents Duplicates
        if (_context.Genres.Any(g => g.Name.ToLower() == newName.ToLower()))
        {
            MessageBox.Show("Genre already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        _context.Genres.Add(new Genre { Name = newName });
        _context.SaveChanges();
        LoadGenres();
        txtGenreName.Clear();
    }

    /// <summary>
    /// Handles the click event of the "Update" button. Updates the selected genre's name in the database 
    /// if it has changed and is not empty. If the genre is associated with any anime,
    /// a warning message is displayed before proceeding with the update.
    /// </summary>
    /// <param name="sender">A reference to the button that raised the event.</param>
    /// <param name="e">A reference to the event arguments.</param>
    private void btnUpdate_Click(object sender, EventArgs e)
    {

        if (lstGenres.SelectedItem is not Genre selectedGenre) return;

        string updatedName = txtGenreName.Text.Trim();

        if (string.IsNullOrEmpty(updatedName) || selectedGenre.Name == updatedName) return;

        var genreWithAnimes = _context.Genres.Include(g => g.Animes).FirstOrDefault(g => g.Id == selectedGenre.Id);

        if (genreWithAnimes != null && genreWithAnimes.Animes.Any())
        {
            // Warn the user that they are about to affect multiple records.
            int count = genreWithAnimes.Animes.Count;

            var result = MessageBox.Show($"Warning: '{selectedGenre.Name}' is associated with {count} anime.\n\nChanging this name will update the genre for all of them. Do you want to update it anyway?",
                                                    "Safety Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No) return;
        }

        // Update the genre name
        selectedGenre.Name = updatedName;
        _context.Genres.Update(selectedGenre);
        _context.SaveChanges();

        LoadGenres();
        txtGenreName.Clear();


    }

    /// <summary>
    /// Handles the click event of the list box. Updates the text box with the selected genre's name.
    /// </summary>
    /// <param name="sender">A reference to the button that raised the event.</param>
    /// <param name="e">A reference to the event arguments.</param>
    private void lstGenres_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (lstGenres.SelectedItem is Genre selected)
        {
            txtGenreName.Text = selected.Name;
        }
    }

    /// <summary>
    /// Handles the click event of the "Delete" button. Deletes the selected genre from the database if it is not associated with any anime.
    /// </summary>
    /// <param name="sender">A reference to the button that raised the event.</param>
    /// <param name="e">A reference to the event arguments.</param>
    private void btnDelete_Click(object sender, EventArgs e)
    {
        // Ensure a genre is actually selected
        if (lstGenres.SelectedItem is not Genre selectedGenre) return;

        // Fetch the genre from the database, including its relational data
        var genreToDelete = _context.Genres
                                    .Include(g => g.Animes)
                                    .FirstOrDefault(g => g.Id == selectedGenre.Id);

        if (genreToDelete == null) return;

        // THE SAFETY CHECK: Block deletion if it's currently in use
        if (genreToDelete.Animes != null && genreToDelete.Animes.Any())
        {
            int count = genreToDelete.Animes.Count;
            MessageBox.Show(
                $"Action Denied: Cannot delete '{selectedGenre.Name}' because it is currently attached to {count} anime.\n\nYou must remove this genre from those anime before it can be deleted.",
                "Deletion Blocked",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error); // Use the Error icon to indicate a hard stop
            return;
        }

        // If it's safe to delete, ask for final confirmation
        var confirmResult = MessageBox.Show(
            $"Are you sure you want to permanently delete the '{selectedGenre.Name}' genre?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirmResult == DialogResult.Yes)
        {
            // Remove the record and save changes
            _context.Genres.Remove(genreToDelete);
            _context.SaveChanges();

            // Refresh the UI
            LoadGenres();
            txtGenreName.Clear();
        }
    }


}
