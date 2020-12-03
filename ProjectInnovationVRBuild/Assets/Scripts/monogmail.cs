using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;



public class monogmail : MonoBehaviour
{

    public void SendData(string message,string theme="test") {
        //Mail();
        Mail(message, theme);
    }

    void Mail(string message, string theme = "test")
    {
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("iinnovation991@gmail.com");
        mail.To.Add("iinnovation991@gmail.com");
        mail.Subject = theme;
        mail.Body = message;

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new System.Net.NetworkCredential("iinnovation991@gmail.com", "B2hSIBkhIqHLNNg8UTME") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };
        smtpServer.Send(mail);
        Debug.Log("success");

    }
}
