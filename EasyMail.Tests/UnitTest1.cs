using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyMail.Tests
{
    [TestClass]
    public class MailServiceTests
    {
        /// <summary>
        /// Test metody zwracającej adres servera dla błędnego servera
        /// </summary>
        [TestMethod]
        public void GetMailServer_UnknownServer_ReturnsZero()
        {
            var test = new SendMailModel();
        }

        /// <summary>
        /// Test metody zwracającej port servera dla błędnego servera
        /// </summary>
        [TestMethod]
        public void GetMailPort_UnknownServer_ReturnsStrinEmpty()
        {

        }
    }
}
