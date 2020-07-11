using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stopaj_Business.Interface;
using Stopaj.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Stopaj_Data.Entity;

namespace Stopaj.Controllers
{
    public class CallCenterController : Controller
    {
        public IAuthService _authService;
        public ILoggingService _loggingService;

        public CallCenterController(IAuthService authService, ILoggingService loggingService)
        {
            _authService = authService;
            _loggingService = loggingService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListCallCenterUser()
        {
            var list = _authService.GetAllCallCenterUser();
            List<CallCenterUserModel> modelList = new List<CallCenterUserModel>();
            foreach (var item in list)
            {
                CallCenterUserModel model = new CallCenterUserModel()
                {
                    Id = item.Id,
                    CreatedDate = item.CreatedDate,
                    FullName = item.FullName,
                    IsActive = item.IsActive
                };
                modelList.Add(model);
            }
            return View(modelList);
        }

        public async Task<bool> LoginUserAsync(LoginModel model)
        {
            var user = _authService.LoginCallCenter(model.DealerId, model.Password);
            if (user != null)
            {
                var claims = new List<Claim>();
                if (user.RoleId == 2)
                {
                    claims.Add(new Claim(ClaimTypes.Name, user.FullName.ToString()));
                    claims.Add(new Claim(ClaimTypes.Role, "CallCenterAdmin"));
                    claims.Add(new Claim(ClaimTypes.PrimarySid, user.Id.ToString()));
                }
                else if (user.RoleId == 4)
                {
                    claims.Add(new Claim(ClaimTypes.Name, user.FullName.ToString()));
                    claims.Add(new Claim(ClaimTypes.Role, "CallCenter"));
                    claims.Add(new Claim(ClaimTypes.PrimarySid, user.Id.ToString()));
                }

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(principal);
                _loggingService.Log("CallCenter Login işlemi", Stopaj_Business.Enum.LogType.Login, user.Id);
                return true;
            }
            return false;
        }

        public async Task<IActionResult> Login(LoginModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Search");
            }
            if (await LoginUserAsync(model))
            {
                return RedirectToAction("ListCallCenterUser");
            }
            if (model.Password != null)
            {
                ViewBag.LoginResult = "Lütfen Kullanıcı ID'nizi ve şifrenizi kontrol ediniz.";
            }

            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "CallCenter");
        }
      
       

        public IActionResult CreateCallCenterUser(CallCenterUserModel model)
        {
            if (model.FullName == null || model.Password == null)
            {
                return View();
            }

            User user = new User()
            {
                IsActive = model.IsActive,
                FullName = model.FullName,
                Password = _authService.PasswordHasher(model.Password),
                CreatedDate = DateTime.Now,
                RoleId = 4,
                CreatedBy = 2
            };
            _authService.CreateCallCenter(user);
            return RedirectToAction("ListCallCenterUser", "CallCenter");
        }
        public IActionResult Search()
        {
            return View();
        }
        public JsonResult SearchByDealerId(int dealerId)
        {
            User user = new User();
            user = _authService.GetUserByDealerId(dealerId);
            return Json(user?.DealerId);
        }

        public IActionResult DealerInfo(int dealerId)
        {
            User user = new User();
            user = _authService.GetUserByDealerId(dealerId);
            return View(user);
        }

        public IActionResult UpdatePhone(int dealerId, string phone)
        {
            var user = _authService.GetUserByDealerId(dealerId);
            string oldPhone = user.Phone;
            user.Phone = phone;

            _authService.UpdateUser(user);
            var id = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.PrimarySid));
            _loggingService.Log(dealerId.ToString() + $" ID li bayinin telefon numarası {oldPhone} -> {phone} güncellenmiştir.", Stopaj_Business.Enum.LogType.ChangePhone, id);
            return Ok();
        }
        public IActionResult ToggleStatus(int userId)
        {
            var user = _authService.GetUserById(userId);

            user.IsActive = !user.IsActive;

            _authService.UpdateUser(user);

            return Ok();
        }
        public IActionResult ChangeCallCenterPassword(int userId, string pass)
        {
            var user = _authService.GetUserById(userId);
            user.Password = _authService.PasswordHasher(pass);
            _authService.UpdateUser(user);
            return Ok();
        }

        public IActionResult GeneratePassword()
        {
            return Json(_authService.RandomPassword(6));
        }
    }
}
