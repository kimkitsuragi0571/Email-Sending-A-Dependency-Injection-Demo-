using Microsoft.Extensions.DependencyInjection;

namespace ConfigServices;

public static class InitFileConfigExtension
{
    public static void AddInitFileConfig(IServiceCollection services, string filePath)
    {
        // services.AddScoped<IConfigService>((IServiceProvider sp) =>
        //     {
        //         return new InitFileConfigService { FilePath = "mail.ini" };
        //     }
        // );
    }
}