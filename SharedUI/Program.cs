global using Microsoft.AspNetCore.Components;
using BlazorStrap;
using Microsoft.Extensions.DependencyInjection;
using Radzen;

namespace SharedUI;

public static class SharedUIServices
{
    /// <summary>
	/// Registers Shared UI Services to work with Application with customised actions
	/// </summary>
	/// <param name="services"></param>
	/// <param name="platform"></param>
	public static IServiceCollection AddSharedUI(this IServiceCollection services, SharedUIPlatform platform)
    {
        AppConsts.AppName = "Survey";

#if DEBUG
        AppConsts.APIClient.APIBaseURL = "https://localhost:5001/api/";
        AppConsts.APIClient.AuthAPIKey = "66540d304bd26eab75d4edb249ec35df52668708526687085266870852b0351eba2f08036e3049e0a19318fbef";
        AppConsts.Environment = "Development";
#else
        AppConsts.APIClient.APIBaseURL = "{APIBaseURL}";
        AppConsts.APIClient.AuthAPIKey = "{AuthAPIKey}";
        AppConsts.Environment = "{Environment}";
#endif

        services.AddBlazorClient(platform);
        services.AddBlazorStrap();
        
        //Razden Components
        services.AddScoped<DialogService>();
        services.AddScoped<NotificationService>();
        services.AddScoped<TooltipService>();
        services.AddScoped<ContextMenuService>();

        services.AddSingleton<IAppInfo, AppInfo>();

        return services;
    }
}
