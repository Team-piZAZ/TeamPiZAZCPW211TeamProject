using Microsoft.EntityFrameworkCore;
using TeamPiZAZCPW211TeamProject.Models;

namespace TeamPiZAZCPW211TeamProject.Database;

/// <summary>
/// Represents the Entity Framework Core database context for the Anime application.
/// </summary>
public class AnimeDbContext : DbContext
{
    /// <summary>
    /// Gets the DbSet of Anime entities,
    /// allowing CRUD operations on the Anime table in the database.
    /// </summary>
    public DbSet<Anime> Animes => Set<Anime>();

    /// <summary>
    /// Gets the DbSet of Genre entities,
    /// allowing CRUD operations on the Genre table in the database.
    /// </summary>
    public DbSet<Genre> Genres => Set<Genre>();

    /// <summary>
    /// Gets the DbSet of Studio entities,
    /// allowing CRUD operations on the Studio table in the database.
    /// </summary>
    public DbSet<Studio> Studios => Set<Studio>();

    /// <summary>
    /// Initializes a new instance of the <see cref="AnimeDbContext"/> class.
    /// </summary>
    public AnimeDbContext()
    {

    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AnimeDbContext"/> class with the specified options.
    /// </summary>
    /// <param name="options">
    /// The options to be used for the database context.
    /// </param>
    public AnimeDbContext(DbContextOptions<AnimeDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// Configures the model relationships and seeds initial data for the database.
    /// </summary>
    /// <param name="modelBuilder">
    /// The builder used to configure the model for the database context.
    /// </param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Anime>()
            .HasMany(a => a.Genres)
            .WithMany(g => g.Animes);

        modelBuilder.Entity<Anime>()
            .HasOne(a => a.Studio)
            .WithMany(s => s.Animes)
            .HasForeignKey(a => a.StudioId)
            .OnDelete(DeleteBehavior.SetNull);


        // Seeds initial data for the Studio table in the database.
        modelBuilder.Entity<Studio>().HasData(
            new Studio { Id = 1, Name = "Studio Ghibli", Description = "A renowned Japanese animation studio." },
            new Studio { Id = 2, Name = "Madhouse", Description = "A Japanese animation studio known for its high-quality productions." },
            new Studio { Id = 3, Name = "Bones", Description = "A Japanese animation studio known for its diverse range of anime series." },
            new Studio { Id = 4, Name = "Kyoto Animation", Description = "A Japanese animation studio known for its detailed animation and character-driven stories." },
            new Studio { Id = 5, Name = "Ufotable", Description = "A Japanese animation studio known for its visually stunning anime adaptations." },
            new Studio { Id = 6, Name = "Sunrise", Description = "A Japanese animation studio known for its mecha and science fiction anime." },
            new Studio { Id = 7, Name = "Wit Studio", Description = "A Japanese animation studio known for its creative and innovative approach to anime production." },
            new Studio { Id = 8, Name = "Studio Deen", Description = "A Japanese animation studio known for its high-quality productions and attention to detail." },
            new Studio { Id = 9, Name = "Pierrot", Description = "A Japanese animation studio known for its long-running anime series and adaptations of popular manga." },
            new Studio { Id = 10, Name = "OLM", Description = "A Japanese animation studio known for its iconic anime series and films." },
            new Studio { Id = 11, Name = "Toei Animation", Description = "A Japanese animation studio known for its long-running anime series and adaptations of popular manga." }
        );

        // Seeds initial data for the Genre table in the database.  
        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "Action", Description = "Anime with intense action sequences and battles." },
            new Genre { Id = 2, Name = "Adventure", Description = "Anime that follows characters on exciting journeys and quests." },
            new Genre { Id = 3, Name = "Comedy", Description = "Anime that focuses on humor and comedic situations." },
            new Genre { Id = 4, Name = "Drama", Description = "Anime that explores emotional and dramatic storylines." },
            new Genre { Id = 5, Name = "Fantasy", Description = "Anime set in fantastical worlds with magical elements." },
            new Genre { Id = 6, Name = "Horror", Description = "Anime that aims to scare or unsettle the audience." },
            new Genre { Id = 7, Name = "Romance", Description = "Anime that focuses on romantic relationships and love stories." },
            new Genre { Id = 8, Name = "Science Fiction", Description = "Anime that explores futuristic or scientific concepts." },
            new Genre { Id = 9, Name = "Slice of Life", Description = "Anime that depicts everyday life and experiences of characters." }
        );

        modelBuilder.Entity<Anime>().HasData(
            new Anime { Id = 101, Title = "Bleach", Synopsis = "Bleach follows Ichigo Kurosaki, a teenager who can see ghosts,\r\nand Rukia Kuchiki, a Soul Reaper (Shinigami). After Rukia\r\nshares her powers with Ichigo to save his family, he must protect\r\nhumans from evil spirits called Hollows and guide lost souls.", StudioId = 9, Episodes = 366, PublicationYear = 2004, ReleaseYear = 2004, TvRating = "TV-14" },
            new Anime { Id = 102, Title = "Demon Slayer", Synopsis = "Set in Taisho Era Japan, the story follows a boy, Tanjiro Kamado,\r\nwho's family is massacred by a demon which sets him on the\r\npath for revenge. Eventually, he meets an organization called the\r\nDemon Slayer Corp who help him in this adventure.", StudioId = 5, Episodes = 63, PublicationYear = 2016, ReleaseYear = 2016, TvRating = "TV-14" },
            new Anime { Id = 103, Title = "Pokemon", Synopsis = "Humans known as 'Trainers' catch, train, and battle creatures\r\nknown as Pokémon. The trainers and they're Pokémon not only\r\nshare a special bond in battle, but also a deep friendship.", StudioId = 10, Episodes = 1300, PublicationYear = 1997, TvRating = "TV-PG" },
            new Anime { Id = 104, Title = "One Piece", Synopsis = "Monkey D. Luffy dreams of becoming the Pirate King by finding\r\nthe legendary \"One Piece\" treasure left behind by Gol D. Roger.\r\nAfter accidentally eating a magical Gum-Gum Devil Fruit, Luffy\r\ngained the ability to stretch like rubber. He sets sail, assembling a\r\nloyal and eccentric crew, to conquer the perilous Grand Line.", StudioId = 11, Episodes = 1170, PublicationYear = 2004, ReleaseYear = 2004, TvRating = "TV-14" },
            new Anime { Id = 105, Title = "Naruto", Synopsis = "Focus' on the struggle of a young ninja in the Hidden Leaf Village,\r\nNaruto Uzumaki. He faces many dangers with his companions\r\nSasuke Uchiha and Sakura Haruno, including other ninja and\r\nother villages.", StudioId = 9, Episodes = 220, PublicationYear = 1999, ReleaseYear = 1999, TvRating = "TV-PG" },
            new Anime { Id = 106, Title = "Dragon Ball", Synopsis = "Follows a hero named Goku and his friends who together, these\r\nfighters defend Earth from powerful space aliens, killer robots,\r\nand magic monsters through intense martial arts battles.", StudioId = 11, Episodes = 291, PublicationYear = 1989, ReleaseYear = 1989, TvRating = "TV-PG" },
            new Anime { Id = 107, Title = "Apothecary Diaries", Synopsis = "Historical mystery anime following Maomao, a young apothecary\r\nsold into palace servitude, who solves medical and court\r\nmysteries using her vast knowledge of poisons and herbs.", StudioId = 10, Episodes = 48, PublicationYear = 2023, ReleaseYear = 2023, TvRating = "TV-14" },
            new Anime { Id = 108, Title = "Frieren: Beyond Journey's End", Synopsis = "Fantasy anime series that follows Frieren, an immortal elf mage.\r\nIt uniquely begins after her party defeats the Demon King,\r\nexploring her emotional journey to understand human mortality\r\nand connections decades later with her new party.", StudioId = 2, Episodes = 38, PublicationYear = 2023, ReleaseYear = 2023, TvRating = "TV-14" },
            new Anime { Id = 109, Title = "The Ancient Magus' Bride", Synopsis = "Fantasy anime series that follows Chise Hatori, a young girl\r\nsold at an auction to a mysterious non-human mage named Elias\r\nAinsworth. The story explores their relationship and Chise's\r\njourney of self-discovery in a world of magic and mythical creatures.", StudioId = 3, Episodes = 24, PublicationYear = 2017, ReleaseYear = 2017, TvRating = "TV-14" },
            new Anime { Id = 110, Title = "Sailor Moon", Synopsis = "Following Usagi Tsukino, a clumsy, average teenager who\r\ndiscovers she is the reincarnation of a Moon Kingdom princess.\r\nGuided by a talking cat named Luna, she transforms into the\r\nmagical guardian \"Sailor Moon\" to fight dark forces and protect\r\nEarth alongside a team of fellow Sailor Guardians.", StudioId = 11, Episodes = 200, PublicationYear = 1992, ReleaseYear = 1992, TvRating = "TV-PG" },
            new Anime { Id = 111, Title = "May I Ask For One Final Thing", Synopsis = "Follows a noble woman, Scarlet El Vandimion, who's received\r\nUnflattering nicknames due to her love for a good beatdown on\r\nunjustly nobles. Scarlet is also on mission with the Prince, Julius,\r\nto bring down corrupt nobility and religious institutions.", Episodes = 13, PublicationYear = 2025, ReleaseYear = 2025, TvRating = "TV-MA" },
            new Anime { Id = 112, Title = "The Executioner and Her Way of Life", Synopsis = "Fantasy anime series that follows Menou, a skilled executioner\r\nwho is tasked with eliminating individuals summoned from\r\nanother world. The story explores themes of morality, justice,\r\nand the consequences of wielding power in a fantastical setting.", Episodes = 12, PublicationYear = 2022, ReleaseYear = 2022, TvRating = "TV-14" },
            new Anime { Id = 113, Title = "The World's Finest Assassin", Synopsis = "Fantasy anime series that follows Lugh Tuatha De, a skilled\r\nassassin who is reincarnated into a parallel world. Tasked with\r\npreventing the rise of a destructive hero, Lugh must navigate\r\npolitical intrigue and moral dilemmas to fulfill his mission.", Episodes = 12, PublicationYear = 2021, ReleaseYear = 2021, TvRating = "TV-14" }

        );
    }
}

