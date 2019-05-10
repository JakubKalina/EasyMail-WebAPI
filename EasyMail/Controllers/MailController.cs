using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyMail.Services;
using EasyMail.Models;

namespace EasyMail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : Controller
    {
        /// <summary>
        /// Serwis mailowy
        /// </summary>
        MailService mailService;

        public MailController()
        {
            this.mailService = new MailService();
        }

        /// <summary>
        /// Testowy get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<string> Index()
        {
            return "get działa LOL";
        }

        /// <summary>
        /// Testowy post
        /// </summary>
        /// <returns></returns>
        [Route("lol")]
        [HttpPost]
        public ActionResult<string> PostTest()
        {
            return "Post działa";
        }

        ///// <summary>
        ///// Wysłanie maila do listy adresatów
        ///// </summary>
        //[Route("send")]
        //[HttpPost]
        //public ActionResult<string> SendMail(SendMailModel mailModel)
        //{
        //    if (this.mailService.SendMail(mailModel)) return "Wiadomości zostały wysłane";
        //    else return "Coś poszło nie tak";
        //}

        [Route("send")]
        [HttpPost]
        public ActionResult<string> SendMail([FromBody]SendMailModel model)
        {
            return "poszło";
        }

    }
}