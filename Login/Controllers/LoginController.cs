using Login.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace Login.Controllers
{
    public class LoginController : Controller
    {

        [HttpPost]
        public async Task<IActionResult> CheckLogin(ModelLogin modelLogin)
        {
            if (modelLogin.username == "user" && modelLogin.password == "123")
            {
                List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.Name, modelLogin.username ),
                    new Claim("OtherProperties", "Example Role")
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return Redirect("/Home");
            }
            ViewData["ValidateMessage"] = "user not found";
            return Redirect("/Home");
        }


    }
}
