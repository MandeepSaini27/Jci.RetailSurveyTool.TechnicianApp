using Jci.RetailSurveyTool.TechnicianApp.Core.CommonUtility;
using Microsoft.Extensions.Logging;

namespace Jci.RetailSurveyTool.TechnicianApp;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        HndlerUtility.ModifyEntry();
        HndlerUtility.ModifyPicker();

        AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
        {
            //MessageBox.Show(text: error.ExceptionObject.ToString(), caption: "Error");
        };

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
