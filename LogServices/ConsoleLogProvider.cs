using System;

namespace LogServices;

public class ConsoleLogProvider:ILogProvider
{
    public void LogInfo(string msg)
    {
        Console.WriteLine("LogInfo:" + msg);
    }

    public void LogError(string msg)
    {
        Console.WriteLine("LogError:" + msg);
    }
}