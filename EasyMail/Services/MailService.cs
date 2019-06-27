using EasyMail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EasyMail.Services
{
    public class MailService
    {
        /// <summary>
        /// Zwraca adres serwera mailowego
        /// </summary>
        /// <param name="serverName">Nazwa servera</param>
        /// <returns></returns>
        public string GetMailServer(string serverName)
        {
            switch (serverName)
            {
                case "Gmail":
                    return "smtp.gmail.com";
                case "Yahoo!":
                    return "smtp.mail.yahoo.com";
                case "iCloud":
                    return "smtp.mail.me.com";
                case "MSN":
                    return "smtp-mail.outlook.com";
                case "Outlook":
                    return "smtp.live.com";
                default:
                    return String.Empty;
            }
        }

        /// <summary>
        /// Zwraca port serwera mailowego
        /// </summary>
        /// <param name="serverName">Nazwa servera</param>
        /// <returns></returns>
        public int GetMailPort(string serverName)
        {
            switch (serverName)
            {
                case "Gmail":
                    return 587;
                case "Yahoo!":
                    return 587;
                case "iCloud":
                    return 587;
                case "MSN":
                    return 587;
                case "Outlook":
                    return 587;
                default:
                    return 0;
            }
        }
        /// <summary>
        /// Metoda wysyłająca mail do listy adresatów
        /// </summary>
        /// <param name="mailModel"></param>
        /// <returns></returns>
        public IList<string> SendMail(SendMailModel mailModel)
        {
            try
            {
                string mailServer = GetMailServer(mailModel.Server);
                int mailPort = GetMailPort(mailModel.Server);

                // Utworzenie nowego klienta mailowego
                SmtpClient mailClient = new SmtpClient(mailServer, mailPort);
                mailClient.EnableSsl = true;
                mailClient.Credentials = new System.Net.NetworkCredential(mailModel.Sender, mailModel.Password);
                // Lista adresów na które nie udało się wysłać maila
                IList<string> results = new List<string>();
                // Pętla wysyłająca mail do każdego z odbiorców
                foreach (var recipient in mailModel.Recipients)
                {
                    try
                    {
                    // Utworzenie nowej wiadomości i jej wysłanie
                    MailMessage newMessage = new MailMessage(mailModel.Sender, recipient, mailModel.Subject, mailModel.Message);
                    mailClient.Send(newMessage);
                    }
                    catch(Exception e)
                    {
                        results.Add(recipient);
                    }

                }
                return results;
            }
            catch(Exception e)
            {
                return mailModel.Recipients;
            }
        }
    }
}
