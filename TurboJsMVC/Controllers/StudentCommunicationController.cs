using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Net.Mail;
using TurboJsMVC.Models;

namespace TurboJsMVC.Controllers
{
    public class StudentCommunicationController : Controller
    {
        private readonly IToastNotification _toastNotification;
        private readonly GRP27ETutorContext _context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public StudentCommunicationController(GRP27ETutorContext context, IToastNotification toastNotification, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _toastNotification = toastNotification; 
            this.httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var username = HttpContext.Session.GetString("Username") ?? "";
            ViewBag.Username = username;
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
                    mail.From = new MailAddress("xnqimfa@gmail.com");
                    mail.Sender = new MailAddress("xnqimfa@gmail.com");
                    mail.Subject = subj;
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("xnqimfa@gmail.com", "wnxxubpgvpykhbus");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    return Ok("Message Sent");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
        }
    }
}
