using System.Drawing.Text;
using TeamPiZAZCPW211TeamProject.Forms;
using TeamPiZAZCPW211TeamProject.Models;

namespace TeamPiZAZCPW211TeamProject
{
    public partial class Form1 : Form
    {
        private readonly Database.AnimeDbContext _context;
        public Form1(Database.AnimeDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var clbStudio = new MultiCheckDropdown<Studio>();
            clbStudio.Location = new Point(lblStudio.Right + 10, lblStudio.Top);
            
            foreach (var studio in _context.Studios)
            {
                clbStudio.AddItem(studio);
            }

            this.Controls.Add(clbStudio);

            var clbGenre = new MultiCheckDropdown<Genre>();
            clbGenre.Location = new Point(lblGenre.Right + 10, lblGenre.Top);

            foreach (var genre in _context.Genres)
            {
                clbGenre.AddItem(genre);
            }

            this.Controls.Add(clbGenre);
        }
    }
}
