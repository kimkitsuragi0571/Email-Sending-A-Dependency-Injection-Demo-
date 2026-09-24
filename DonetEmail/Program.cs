using System;
using ConfigServices;
using LogServices;
using MailServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

class Program
{
    static void Main(string[] args)
    {
       Console.WriteLine("项目主入口,开始执行");

       ServiceCollection services = new ServiceCollection();
       //这里直接用MailServices就会有命名空间和类冲突(都叫MailServices),这波没写标准
       //紧急改名为MailService
       services.AddScoped<IMailServices, MailService>();
       //注意具体实现类必须是public class,不然访问不到
       services.AddScoped<IConfigServices, EnvVarConfigServices>();
       services.AddScoped<ILogProvider, ConsoleLogProvider>();
       using (var sp = services.BuildServiceProvider())
       {
           //根对象只能用ServiceLocator(也就是下面这句)
           //根对象是指DI感染性中的起点
           //当创建mailService对象时自动new ILogProvider和IConfigServices两个接口及其对应实现类对象
           //mailService对象作为起点只能从容器中取出,后续要传入的new对象人家自动帮你塞进去
           //比如你手动塞进去就是var mail = new MailService(new ConsoleLogProvider(), new EnvVarConfigServices());
           var mailService = sp.GetRequiredService<IMailServices>();
           mailService.SendMail("曹操","讨贼檄文","盖闻明主图危以制变，忠臣虑难以立权");
       }
       //暂停程序执行,直到用户按下回车
       Console.ReadLine();
    }
}