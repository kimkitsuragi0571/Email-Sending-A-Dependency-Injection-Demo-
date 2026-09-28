namespace ConfigServices;

public class InitFileConfigService : IConfigService
{
    public string FilePath
    {
        get;
        set;
    }

    public string GetValue(string name)
    {
       //总之就是读取了配置文件,不用管这些细节
        var kv = File.ReadAllLines(FilePath)
            .Select(s => s.Split('=', 2)) 
            .Select(strs => new { Name = strs[0].Trim(), Value = strs[1].Trim() })
            .SingleOrDefault(kv => kv.Name == name);
        if (kv != null)
        {
            return kv.Value;
        }
        else
        {
            return null;
        }
    }
}