namespace ConfigServices;

public class LayeredConfigReader : IConfigReader
{
    private readonly IEnumerable<IConfigService> services;
    public LayeredConfigReader(IEnumerable<IConfigService> services)
    {
        this.services = services;
    }
    
    public string GetValue(string name)
    {
        string value = null;
        foreach (var service in services)
        {
           string newValue = service.GetValue(name);
           if (newValue != null)
           {
               //不断覆盖,最后一个非null的值就是最终值
               value = newValue;
           }
        }
        return value;
    }
}