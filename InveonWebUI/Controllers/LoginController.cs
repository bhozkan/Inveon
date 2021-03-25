using InveonWebUI.Business;
using InveonWebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InveonWebUI.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel login)
        {
            string Token = new SignInBusiness().LoginUser(new LoginViewModel { UserName = login.UserName, Password = login.Password }).Result;
            if (!String.IsNullOrEmpty(Token))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, Token),
                     new Claim(ClaimTypes.Name, new TokenBusiness().GetUserName(Token)),
                    new Claim(ClaimTypes.UserData, new TokenBusiness().GetUserId(Token)),
                    new Claim(ClaimTypes.Role, new TokenBusiness().GetUserType(Token))

                };


                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                //Just redirect to our index after logging in. 
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        
        public async Task<IActionResult> LogOut()
        {

            await HttpContext.SignOutAsync();

            return RedirectToAction("SignIn", "Login");
        }

    }
}
