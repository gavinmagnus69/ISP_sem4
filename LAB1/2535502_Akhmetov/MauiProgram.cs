using Android.App;
using Microsoft.Extensions.Logging;

namespace _2535502_Akhmetov;

public static class MauiProgram
{


	public static IServiceCollection services = new ServiceCollection();
    public static IDbService? dbService = new SQLiteService();
	public static MauiApp CreateMauiApp()
	{
		//services.AddTransient<IDbService, SQLiteService>();
		
		var builder = MauiApp.CreateBuilder();
		
		services.AddTransient<IDbService, SQLiteService>();
		//var sql = new SQLiteService();
		builder.UseMauiApp<App>().ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddTransient<SQLiteDemo>();	

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
