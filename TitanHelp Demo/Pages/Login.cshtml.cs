using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TitanHelp_Demo.Models;

namespace TitanHelp_Demo.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {

        private readonly TitanHelp_Demo.Data.TicketsContext _context;

        public LoginModel(TitanHelp_Demo.Data.TicketsContext context)
        {
            _context = context;
        }
        public string ReturnUrl { get; set; }
        public async Task<IActionResult>
        OnGetAsync(string paramUsername, string paramPassword)
        {
            string returnUrl = Url.Content("~/");
            try
            {
                // Clear the existing external cookie
                await HttpContext
                    .SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch { }
            //Here we could check passwords but we really dont care in the context of a demo
            bool exists = false;
            foreach (User U in _context.Users) //Here we check if a user exists
            {//I know that Sequential Search is bad, but at this point oh well.
                if (U.ScreenName.Equals(paramUsername)) { exists = true; }
            }
            if (!exists) // If it doesn't exist let's make it.
            {
                await _context.Users.AddAsync(new Models.User { ScreenName = paramUsername, Password = paramPassword });
                await _context.SaveChangesAsync();
            }

            // *** !!! This is where you would validate the user !!! ***
            // In this example we just log the user in
            // (Always log the user in for this demo)
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, paramUsername),
                new Claim(ClaimTypes.Role, "Administrator"),
            };
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                RedirectUri = this.Request.Host.Value
            };
            try
            {
                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return LocalRedirect(returnUrl);
        }
    }
}
