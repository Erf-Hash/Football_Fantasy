using FootBall_Fantasy.Business.ResponseClass;
using System.Net.Mail;

namespace FootBall_Fantasy.Business.Email;

public static class EmailSender
{
    private static string smtpServer = "smtp.gmail.com";
    private static int smtpPort = 587;
    private static string smtpUsername = "untitledfootballfantasy@gmail.com";
    private static string smtpPassword = "lltavkutyttidgsq";
    public static Response SendEmail(string email, string subject, string body)
    {
        MailMessage mail = new MailMessage(smtpUsername, email, subject, body);
        SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new System.Net.NetworkCredential(smtpUsername, smtpPassword);
        smtpClient.EnableSsl = true;
        Response response;
        try
        {
            smtpClient.Send(mail);
            response = new Response(true , "Email sent successfuly.");
        }
        catch (Exception ex)
        {
            response = new Response(false , "Failed to send email.");
        }
        return response;
    }
}
