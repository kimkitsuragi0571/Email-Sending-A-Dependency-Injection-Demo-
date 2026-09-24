//文件级命名空间,直接整个文件都在这命名空间下
namespace LogServices;

public interface ILogProvider
{
     public void LogInfo(string msg);
     public void LogError(string msg);
}