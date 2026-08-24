using TeamPiZAZCPW211TeamProject.Models;
using TeamPiZAZCPW211TeamProject.Database;

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

        this.MouseEnter += Card_MouseEnter;
        MouseLeave += Card_MouseLeave;
        this.Click += Card_Click;
        lblTitle.MouseEnter += Card_MouseEnter;
        lblTitle.MouseLeave += Card_MouseLeave;
        lblRating.MouseEnter += Card_MouseEnter;
        lblRating.MouseLeave += Card_MouseLeave;
        lblTitle.Click += Card_Click;
        lblRating.Click += Card_Click;
    }


    /// <summary>
    /// Handles the MouseEnter event for the card, 
    /// changing its background color to a darker shade 
    /// when the mouse enters the card area.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Card_MouseEnter(object sender, EventArgs e)
    {
        this.BackColor = Color.FromArgb(48, 25, 52); // Change to a darker shade when the mouse enters the card
    }

    private void Card_MouseLeave(object sender, EventArgs e)
    {
        if (!this.ClientRectangle.Contains(this.PointToClient(Cursor.Position)))
        {
            this.BackColor = Color.FromArgb(95, 0, 160); // Change back to the original shade when the mouse leaves the card
        }
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

    public void PopulateData(Anime anime)
    {
        if (anime == null) return;

        lblTitle.Text = anime.Title;
        lblRating.Text = anime.TvRating;
    }

    private void SmallAnimeCard_Load(object sender, EventArgs e)
    {

    }

}
