using ConfigServices;

namespace Microsoft.Extensions.DependencyInjection;

public static class LayeredConfigExtension
{
    public static void AddLayeredConfig(this IServiceCollection services)
    {
        services.AddScoped<IConfigReader,LayeredConfigReader>();
    }
}