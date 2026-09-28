namespace ConfigServices;

public interface IConfigReader
{
    //配置找不到就返回null
    public string GetValue(string name);
}