using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using TurboJsMVC.Common;
using TurboJsMVC.Models;

namespace TurboJsMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly GRP27ETutorContext _context;
        private readonly IToastNotification _toastNotification;

        private readonly IHttpContextAccessor httpContextAccessor;

        public LoginController(GRP27ETutorContext context, IToastNotification toastNotification, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _toastNotification = toastNotification;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> Index()
        {
              return _context.Users != null ? 
                          View() :
                          Problem("Entity set 'GRP27ETutorContext.Users'  is null.");
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(Login objLogin)
        {
            LoginHistory history = new LoginHistory();
            Result<bool> result = new Result<bool>();
                var userCheck = await _context.Users.FirstOrDefaultAsync(a => a.Email.Equals(objLogin.Email) && a.Password.Equals(objLogin.Password));
                if (userCheck != null)
                {
                    HttpContext.Session.SetString("Username", userCheck.Username);
                    HttpContext.Session.SetInt32("UserId", userCheck.UserId);
                var ip = this.httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                history.UserId = userCheck.UserId;
                history.Ip = ip;
                DateTime date = DateTime.Now;
                history.Date = date;
                _context.LoginHistories.Add(history);
                _context.SaveChanges();
                if (userCheck.IsAdmin)
                    {
                        return RedirectToAction("AdminDashboard", "AdminDashboard");
                    }else if (userCheck.IsLecture)
                    {
                        return RedirectToAction("LectureDashboard", "LectureDashboard");
                    }else if (userCheck.IsStudent)
                    {
                        return RedirectToAction("StudentDashboard", "StudentDashboard");
                    }
                    else
                    {
                        _toastNotification.AddErrorToastMessage("Please contact support");
                        return RedirectToAction("Index", "Login");
                    }
                    
                }
                else
                {
                    _toastNotification.AddErrorToastMessage("Invalid login details");
                    return RedirectToAction("Index", "Login");
                }

            
        }

        [HttpPost]
        public async Task<IActionResult> SignUpUser(Login user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var studNumber = 0;
                    var usersResult = _context.Users.ToList();
                    var length = usersResult.Count();
                    studNumber = (int)(usersResult[length - 1].StudentNumber + 1);
                    User list = new User();
                    list.Username = user.UserName;
                    list.Email = user.Email;
                    list.Password = user.Password;
                    list.DateJoined = DateTime.Now;
                    list.IsAdmin = false;
                    list.IsLecture = false;
                    list.IsStudent = true;
                    list.IsDeleted = false;
                    list.StudentNumber = studNumber;
                    _context.Users.Add(list);
                    var result = await _context.SaveChangesAsync();
                    if (result > 0)
                    {
                        var userCheck = await _context.Users.FirstOrDefaultAsync(a => a.Email.Equals(user.Email));
                        HttpContext.Session.SetString("Username", userCheck.Username);
                        HttpContext.Session.SetInt32("UserId", userCheck.UserId);
                        return RedirectToAction("StudentDashboard", "StudentDashboard");
                    }
                    else
                    {
                        _toastNotification.AddErrorToastMessage("Error signing up");
                        return RedirectToAction("Index", "Login");
                    }
                }
                catch
                {
                    _toastNotification.AddErrorToastMessage("Oops, something went wrong!");
                    return RedirectToAction("Index", "Login");
                }
                
            }
            else
            {
                _toastNotification.AddErrorToastMessage("Oops, something went wrong!");
                return RedirectToAction("Index", "Login");
            }
        }

       
    }
}
