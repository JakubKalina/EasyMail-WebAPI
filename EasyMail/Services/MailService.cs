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
        public bool SendMail(SendMailModel mailModel)
        {
            try
            {
                // Utworzenie nowego klienta mailowego
                SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587);
                mailClient.EnableSsl = true;
                mailClient.Credentials = new System.Net.NetworkCredential(mailModel.Sender, mailModel.Password);

                // Pętla wysyłająca mail do każdego z odbiorców
                foreach (var recipient in mailModel.Recipients)
                {
                    // Utworzenie nowej wiadomości i jej wysłanie
                    MailMessage newMessage = new MailMessage(mailModel.Sender, recipient, mailModel.Subject, mailModel.Message);
                    mailClient.Send(newMessage);
                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
