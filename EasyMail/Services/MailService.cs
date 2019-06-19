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
        /// Metoda wysyłająca mail do listy adresatów
        /// </summary>
        /// <param name="mailModel"></param>
        /// <returns></returns>
        public IList<string> SendMail(SendMailModel mailModel)
        {
            try
            {
                string mailServer = "";
                int mailPort = 0;
                switch(mailModel.Server)
                {
                    case "Gmail":
                        mailServer = "smtp.gmail.com";
                        mailPort = 587;
                        break;
                    case "Yahoo!":
                        mailServer = "smtp.mail.yahoo.com";
                        mailPort = 587;
                        break;
                    case "iCloud":
                        mailServer = "smtp.mail.me.com";
                        mailPort = 587;
                        break;
                    case "MSN":
                        mailServer = "smtp-mail.outlook.com";
                        mailPort = 587;
                        break;
                    case "Outlook":
                        mailServer = "smtp.live.com";
                        mailPort = 587;
                        break;
                }
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
