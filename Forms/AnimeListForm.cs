using System.Drawing.Text;
using TeamPiZAZCPW211TeamProject.Forms;
using TeamPiZAZCPW211TeamProject.Models;

namespace TeamPiZAZCPW211TeamProject
{
    public partial class AnimeListForm : Form
    {
        private readonly Database.AnimeDbContext _context;
        private MultiCheckDropdown<Studio> _clbStudio;
        private MultiCheckDropdown<Genre> _clbGenre;

        private List<Studio> _studioFilter = new();
        private List<Genre> _genreFilter = new();
        private string _titleFilter = "";

        public AnimeListForm(Database.AnimeDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void AnimeListForm_Load(object sender, EventArgs e)
        {
            _clbStudio = new MultiCheckDropdown<Studio>();
            _clbStudio.Location = new Point(lblStudio.Right + 10, lblStudio.Top);

            foreach (var studio in _context.Studios)
            {
                _clbStudio.AddItem(studio);
            }

            Controls.Add(_clbStudio);

            _clbGenre = new MultiCheckDropdown<Genre>();
            _clbGenre.Location = new Point(lblGenre.Right + 10, lblGenre.Top);

            foreach (var genre in _context.Genres)
            {
                _clbGenre.AddItem(genre);
            }

            Controls.Add(_clbGenre);
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {

        }

        private void txtAnimeName_TextChanged(object sender, EventArgs e)
        {
            _titleFilter = txtAnimeName.Text.Trim();
            ApplyFilters();
        }

        private void GenreChanged(object sender, EventArgs e)
        {
            _genreFilter = _clbGenre.CheckedItems.ToList();
            ApplyFilters();
        }

        private void StudioChanged(object sender, EventArgs e)
        {
            _studioFilter = _clbStudio.CheckedItems.ToList();
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            var filtered = _context.Animes.AsEnumerable();

            if (!string.IsNullOrEmpty(_titleFilter))
            {
                filtered = filtered.Where(a => a.Title.Contains(_titleFilter, StringComparison.OrdinalIgnoreCase));
            }
            if (_studioFilter.Any())
            {
                filtered = filtered.Where(a => _studioFilter.Contains(a.Studio));
            }
            if (_genreFilter.Any())
            {
                filtered = filtered.Where(a => _genreFilter.All(g => a.Genres.Contains(g)));
            }
            DisplayAnime(filtered.ToList());
        }
    }
}
