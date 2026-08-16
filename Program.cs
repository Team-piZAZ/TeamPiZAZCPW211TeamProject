using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeamPiZAZCPW211TeamProject.Database;
using TeamPiZAZCPW211TeamProject.Services;


namespace TeamPiZAZCPW211TeamProject;

/// <summary>
/// The main entry point for the application.
/// </summary>
internal static class Program
{
    /// <summary>
    /// Gets the service provider for dependency injection, 
    /// allowing access to registered services throughout the application.
    /// </summary>
    public static IServiceProvider ServiceProvider { get; private set; } = null!;


    [STAThread]

   
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // 1. Build configuration from appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        // 2. Setup Dependency Injection
        var services = new ServiceCollection();

        services.AddDbContext<AnimeDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Register Repository / Services
        services.AddScoped<IAnimeService, AnimeService>();

        // Register Forms
        services.AddTransient<AnimeListForm>();

        ServiceProvider = services.BuildServiceProvider();

        // 3. Automatically apply pending migrations & build DB on startup
        using (var scope = ServiceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AnimeDbContext>();
            dbContext.Database.Migrate();
        }

        // 4. Run application
        var mainForm = ServiceProvider.GetRequiredService<AnimeListForm>();
        Application.Run(mainForm);
    }
}
