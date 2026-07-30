using System;
using System.Collections.Generic;
using System.Text;
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
    /// Configures the database context to use SQL Server with the specified connection string.
    /// </summary>
    /// <param name="optionsBuilder">
    /// The builder used to configure the options for the database context.
    /// </param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=ZACHARYKIMB6482;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
        }
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

        /// <summary>
        /// Seeds initial data for the Studio table in the database.
        /// </summary>
        modelBuilder.Entity<Studio>().HasData(
            new Studio { Id = 1, Name = "Studio Ghibli", Description = "A renowned Japanese animation studio." },
            new Studio { Id = 2, Name = "Madhouse", Description = "A Japanese animation studio known for its high-quality productions." },
            new Studio { Id = 3, Name = "Bones", Description = "A Japanese animation studio known for its diverse range of anime series." }
        );

        /// <summary>
        /// Seeds initial data for the Genre table in the database.
        /// </summary>  
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
    }
}

