using HotelProject.WebUI.Dtos.DAL;
using HotelProject.WebUI.Models.Mail;
using MailKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            MailManager.SendMail(model.Subject, model.ReciverMail, model.Message);
            return View();
        }
    }
}
