using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TeamPiZAZCPW211TeamProject.Models;

namespace TeamPiZAZCPW211TeamProject.Database;

public class AnimeDbContext : DbContext
{
    public DbSet<Anime> Animes => Set<Anime>();

    public DbSet<Genre> Genres => Set<Genre>();

    public DbSet<Studio> Studios => Set<Studio>();

    public AnimeDbContext()
    {

    }

    public AnimeDbContext(DbContextOptions<AnimeDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=ZACHARYKIMB6482;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
        }
    }

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

        modelBuilder.Entity<Studio>().HasData(
            new Studio { Id = 1, Name = "Studio Ghibli", Description = "A renowned Japanese animation studio." },
            new Studio { Id = 2, Name = "Madhouse", Description = "A Japanese animation studio known for its high-quality productions." },
            new Studio { Id = 3, Name = "Bones", Description = "A Japanese animation studio known for its diverse range of anime series." }
        );

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

