//要是没有添加引用,这里是没法使用using的
using ConfigServices;
using LogServices;

namespace MailServices;

public class MailService : IMailService
{
    //添加了对Config和Log项目的引用,所以这里可以直接写接口类成员
    private readonly ILogProvider logProv;
    //private readonly IConfigService configServ;这里也记得换成ConfigReader类型
    private readonly IConfigReader configServ;
    //之后MailService类实例化时,构造函数传入具体实现类ConfigServices和LogProvider变量就行
    //你要是直接传入接口变量肯定报错
    //public MailService(ILogProvider logProv, IConfigService configServ)这里就不直接简单读取
    public MailService(ILogProvider logProv, IConfigReader configServ)
    {
        this.logProv = logProv;
        this.configServ = configServ;
    }



    public void SendMail(string to, string title, string body)
    {
        this.logProv.LogInfo("开始发送邮件:" + to);
        string smtpServ = this.configServ.GetValue("SmtpServ");
        string userName = this.configServ.GetValue("UserName");
        string password = this.configServ.GetValue("Password");
        Console.WriteLine("邮件发送地址" + "/" + smtpServ + "/" + userName + "/" + password);
        //发送邮件具体逻辑这里就不写了
        Console.WriteLine("SendMail:" + to);
        this.logProv.LogInfo("邮件发送完毕");
        
       
    }
}