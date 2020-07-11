﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stopaj.Models;
using Stopaj_Business.Interface;

namespace Stopaj.Controllers
{
    public class DealerController : Controller
    {
        IAuthService _authService;
        ILoggingService _loggingService;
        public DealerController(IAuthService _authService, ILoggingService _loggingService)
        {
            this._authService = _authService;
            this._loggingService = _loggingService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(LoginModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            if (await LoginUserAsync(model))
            {
                return RedirectToAction("Index");
            }

            if (model.Password != null)
            {
                ViewBag.LoginResult = "Lütfen Bayi ID'nizi ve şifrenizi kontrol ediniz.";
            }

            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Dealer");
        }
        [AllowAnonymous]
        private async Task<bool> LoginUserAsync(LoginModel model)
        {
            if (model.Password == null) return false;

            var user = _authService.LoginDealer(model.DealerId, model.Password);
            if (user != null)
            {
                var claims = new List<Claim>();
                if (user.RoleId == 1)
                {
                    claims.Add(new Claim(ClaimTypes.Name, user.DealerName.ToString()));
                    claims.Add(new Claim(ClaimTypes.Role, "Dealer"));
                    claims.Add(new Claim(ClaimTypes.PrimarySid, user.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.PrimaryGroupSid, user.DealerId.ToString()));
                }
                else if (user.RoleId == 3)
                {

                    claims.Add(new Claim(ClaimTypes.Name, user.DealerName.ToString()));
                    claims.Add(new Claim(ClaimTypes.Role, "Bayi1"));
                    claims.Add(new Claim(ClaimTypes.PrimarySid, user.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.PrimaryGroupSid, user.DealerId.ToString()));
                }

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(principal);

                _loggingService.Log("Dealer veya Bayi Login işlemi", Stopaj_Business.Enum.LogType.Login, user.Id);
                return true;
            }

            return false;
        }
    }
}
