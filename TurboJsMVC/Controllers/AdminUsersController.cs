using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using TurboJsMVC.Models;

namespace TurboJsMVC.Controllers
{
    public class AdminUsersController : Controller
    {
        private readonly GRP27ETutorContext _context;
        private readonly IToastNotification _toastNotification;

        public AdminUsersController(GRP27ETutorContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }

        public IActionResult Index(int ? page)
        {
            List<User> list = new List<User>();
            var result = _context.Users.ToList();
            list = result;

            if (page > 0)
            {
                page = page;
            }
            else
            {
                page = 1;
            }
            int limit = 10;
            int start = (int)(page - 1) * limit;
            int totalData = list.Count();
            ViewBag.totalHistories = totalData;
            ViewBag.pageCurrent = page;
            int numberPage = (totalData / limit);
            ViewBag.numberPage = numberPage;
            var dataHistories = list.Skip(start).Take(limit);
            return View(dataHistories.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                List<CustomUser> list = new List<CustomUser>();
                var users = _context.Users.ToList();
                if (null == users || users.Count < 1)
                {
                    return BadRequest(users);
                }
                foreach(var user in users)
                {
                    list.Add(new CustomUser
                    {
                        Username = user.Username,
                        Email = user.Email,
                        UserId = user.UserId,
                        DateJoined = user.DateJoined.ToString("dddd, dd MMMM yy"),
                        IsAdmin = user.IsAdmin,
                        IsLecture = user.IsLecture,
                        IsStudent = user.IsStudent,
                        StudentNumber = (int)user.StudentNumber
                    });
                }
                return Ok(list);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int userId, string reason)
        {
            try
            {
                User user = _context.Users.FirstOrDefault(m => m.UserId == userId);
                DateTime date = DateTime.Now;
                RemovedUser removedUser = new RemovedUser();
                if (user != null)
                {
                   var result =  _context.Users.Remove(user);
                    removedUser.UserId = userId;
                    removedUser.Reason = reason;
                    removedUser.Date = date;
                    _context.RemovedUsers.Add(removedUser);
                    _context.SaveChanges();
                    return Ok("User removed");
                }
                else
                {
                    return NotFound("User not found");
                }
                
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(int userId, string username, string email, string role)
        {
            User user = _context.Users.FirstOrDefault(m => m.UserId == userId);
            user.Username = username;
            user.Email = email;
            if(role == "Admin")
            {
                user.IsAdmin = true;
                user.IsLecture = false;
                user.IsStudent = false;
            }else if(role == "Lecture")
            {
                user.IsAdmin = false;
                user.IsLecture = true;
                user.IsStudent = false;
            }
            else
            {
                user.IsAdmin = false;
                user.IsLecture = false;
                user.IsStudent = true;
            }
            try
            {
                _context.Users.Update(user);
                _context.SaveChanges();
                return Ok("User updated");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult>GetUser(int userId)
        {
            var result = _context.Users.FirstOrDefault(x => x.UserId == userId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetLectures()
        {
            try
            {
                var result =  _context.Users.Where(x => x.IsLecture == true).ToList();
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
