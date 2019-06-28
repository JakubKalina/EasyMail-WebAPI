using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMail.Models
{
    public class SendMailModel
    {
        /// <summary>
        /// Nadawca
        /// </summary>
        public string Sender { get; set; }
        /// <summary>
        /// Hasło
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Temat wiadomości
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Treść wiadomości
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Lista adresatów
        /// </summary>
        public IList<string> Recipients { get; set; }
        /// <summary>
        /// Wybrany serwer pocztowy
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// Przerwa pomiędzy kolejnymi wiadomościami
        /// </summary>
        public int TimeBreak { get; set; }

        /// <summary>
        /// Konstruktor bez parametrów
        /// </summary>
        public SendMailModel()
        {
            this.Recipients = new List<string>();
        }
    }
}
