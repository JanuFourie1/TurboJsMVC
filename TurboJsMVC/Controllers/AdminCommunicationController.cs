using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Net;
using System.Net.Mail;
using TurboJsMVC.Models;

namespace turbojsmvc.controllers
{
    public class AdminCommunicationController : Controller
    {
        private readonly IToastNotification _toastNotification;
        private readonly GRP27ETutorContext _context;

        public AdminCommunicationController(GRP27ETutorContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(string user, string subj, string body)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(subj) || string.IsNullOrEmpty(body))
            {
                _toastNotification.AddErrorToastMessage("Error, please try again");
                return BadRequest();
            }
            else
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.To.Add(user);
                    mail.From = new MailAddress("turbojsetutor@gmail.com");
                    mail.Sender = new MailAddress("turbojsetutor@gmail.com");
                    mail.Subject = subj;
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    SmtpClient smtp =  new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("turbojsetutor@gmail.com", "oasfdmepqwqtlssb");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    return Ok("Message Sent");
                }
                catch
                {
                    return BadRequest();
                }
            }
        }
    }
}
