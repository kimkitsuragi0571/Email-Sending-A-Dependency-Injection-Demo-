namespace MailServices;

public interface IMailServices
{
    public void SendMail(string to, string title, string body);
}