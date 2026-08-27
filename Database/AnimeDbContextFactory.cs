using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace TeamPiZAZCPW211TeamProject.Database;

/// <summary>
/// Factory class for creating instances of <see cref="AnimeDbContext"/> at design time.
/// </summary>
public class AnimeDbContextFactory : IDesignTimeDbContextFactory<AnimeDbContext>
{

    /// <summary>
    /// Creates a new instance of <see cref="AnimeDbContext"/> using the provided arguments.
    /// </summary>
    /// <param name="args">
    /// The arguments to use for creating the context.
    /// </param>
    /// <returns>
    /// A new instance of <see cref="AnimeDbContext"/>.
    /// </returns>
    public AnimeDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AnimeDbContext>();

        string? connectionString = null;

        if (File.Exists("appsettings.json"))
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // If the connection string is not found in appsettings.json, use a default connection string
        connectionString ??= "Data Source=localhost;Database=AnimeCPW211Db;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

        optionsBuilder.UseSqlServer(connectionString);

        return new AnimeDbContext(optionsBuilder.Options);

    }
}


