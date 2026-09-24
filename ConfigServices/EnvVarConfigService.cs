namespace ConfigServices;

public class EnvVarConfigService : IConfigService
{
    public string GetValue(string name)
    {
        return Environment.GetEnvironmentVariable(name) ?? string.Empty;
    }
}