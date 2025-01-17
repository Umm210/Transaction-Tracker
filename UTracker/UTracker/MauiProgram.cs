using Microsoft.Extensions.Logging;
using SQLite;
using System.IO;
using UTracker.Models;
using MudBlazor.Services;

namespace UTracker
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            // Configure SQLite database path and inject UserService
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "UserDatabase.db3");
            builder.Services.AddSingleton<UserService>(s => new UserService(dbPath));

            return builder.Build();
        }
    }
}
