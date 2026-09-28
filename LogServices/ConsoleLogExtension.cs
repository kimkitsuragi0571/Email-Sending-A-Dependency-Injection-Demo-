//和ServiceCollection类在同一命名空间下,可以少using点

using LogServices;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConsoleLogExtension
{
    public static void AddConsoleLog(this IServiceCollection services)
    {
        //1.这样可以避免直接在主项目中引用具体实现类库
        //2.同时避免配置逻辑暴露
        services.AddScoped<ILogProvider, ConsoleLogProvider>();
    }
}