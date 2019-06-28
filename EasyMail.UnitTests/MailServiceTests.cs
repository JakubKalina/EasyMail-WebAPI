using EasyMail.Models;
using EasyMail.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EasyMail.UnitTests
{
    [TestClass]
    public class MailServiceTests
    {
        /// <summary>
        /// Test metody zwracaj¹cej adres servera dla servera nieznanego
        /// </summary>
        [TestMethod]
        public void GetMailServer_UnknownServer_ReturnsZero()
        {
            var mailService = new MailService();

            var result = mailService.GetMailServer("");

            Assert.AreEqual(String.Empty, result);
        }

        /// <summary>
        /// Test metody zwracaj¹cej port servera dla servera nieznanego
        /// </summary>
        [TestMethod]
        public void GetMailPort_UnknownServer_ReturnsStringEmpty()
        {
            var mailService = new MailService();

            var result = mailService.GetMailPort("");

            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Test metody zwracaj¹cej listê adresatów do których nie uda³o siê wys³aæ maila
        /// </summary>
        [TestMethod]
        public void SendMail_WrongRecipients_ReturnsListOfRecipients()
        {
            var mailService = new MailService();
            var mailModel = new SendMailModel();
            mailModel.Recipients.Add("a");
            mailModel.Recipients.Add("b");
            mailModel.Recipients.Add("c");

            var result = mailService.SendMail(mailModel);

            Assert.AreEqual(mailModel.Recipients.Count, result.Count);
        }
    }
}
