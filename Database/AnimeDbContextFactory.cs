using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace TeamPiZAZCPW211TeamProject.Database;

public class AnimeDbContextFactory : IDesignTimeDbContextFactory<AnimeDbContext>
{
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

        connectionString ??= "Data Source=localhost;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

        optionsBuilder.UseSqlServer(connectionString);

        return new AnimeDbContext(optionsBuilder.Options);

    }
}


