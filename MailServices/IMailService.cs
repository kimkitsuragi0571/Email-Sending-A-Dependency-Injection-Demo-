namespace MailServices;

public interface IMailService
{
    public void SendMail(string to, string title, string body);
}