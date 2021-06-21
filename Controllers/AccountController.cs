using Certificates.Data;
using Certificates.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace Certificates.Controllers
{
    public class AccountController : Controller
    {
        private CertificateContext _context;


        public AccountController(CertificateContext certificateContext)
        {
            _context = certificateContext;

        }

        public IActionResult Login(Guid auid/*, int? pID*/)
        {
            if (string.IsNullOrEmpty(Convert.ToString(auid)))
            {
                return View("UnAuthenticated");
            }

            if (auid != null)
            {
                 ACSPersonCME acsPersonCME = _context.ACSPersonCME.FirstOrDefault(a => a.ACSUniqueId == auid);
                //Person person = _context.Person.FirstOrDefault(p => p.Id == pID);
                ClaimsIdentity identity = null;
                bool isAuthenticated = false;

                if (acsPersonCME != null)
                {

                    //Create the identity for the user  
                    identity = new ClaimsIdentity(new[] {

                        new Claim(ClaimTypes.Name, Convert.ToString(auid)),
                        new Claim(ClaimTypes.Role, "User")
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                    isAuthenticated = true;
                }



                if (isAuthenticated)
                {
                    var principal = new ClaimsPrincipal(identity);
                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    TempData["auid"] = auid;
                    return RedirectToAction("Index", "Certificate");
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}