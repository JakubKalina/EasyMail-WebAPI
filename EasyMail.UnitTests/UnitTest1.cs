using EasyMail.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
    }
}
