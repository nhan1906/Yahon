using System;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Yahon.Models;

namespace Yahon.Controllers
{
    public class AccountController: Controller
    {

         [HttpGet]
        public PartialViewResult Login()
        {
            
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(CustomerSession session, string returnUrl = "")
        {
            string message;
            using (var db = new DatabaseContext())
            {
                var v = db.Customers.FirstOrDefault(customer => customer.Email == session.EmailId);
                if (v != null)
                {
                    if (string.CompareOrdinal(Hash(session.PasswordHash, v.Salt), v.Password) == 0)
                    {
                        int timeOut = session.RememberMe ? 55200 : 20;
                        var ticket =
                            new FormsAuthenticationTicket(session.EmailId, session.RememberMe, timeOut);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeOut);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);

                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }

                        return RedirectToAction($"Index", $"Home");
                    }

                    message = "Invalid credentials.";
                }
                else
                {
                    message = "Account doesn't exist.";
                }
            }

            ViewBag.Message = message;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction($"Index", $"Home");
        }

        [HttpGet]
        public PartialViewResult Register()
        {
            return PartialView();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer customer)
        {
            bool status = false;
            string message;
            
            if (ModelState.IsValid)
            {
                bool isExist = IsMailExist(customer.Email);
                if (isExist)
                {
                    ModelState.AddModelError("AccountExists", "This account exists ");
                    return View(customer);
                }

                byte[] salt = GenerateSalt();
                string hashed = Hash(customer.Password, salt);

                customer.Password = hashed;
                customer.Salt = salt;
                
                using (var db = new DatabaseContext())
                {
                    try
                    {
                        customer.CreationDate = DateTime.Now;
                        db.Customers.Add(customer);
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.SaveChanges();
                        db.Configuration.ValidateOnSaveEnabled = true;
                    }
                    
                    catch (DbEntityValidationException e)
                    {
                        foreach (var eve in e.EntityValidationErrors)
                        {
                            Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().Name, eve.Entry.State);
                            foreach (var ve in eve.ValidationErrors)
                            {
                                Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                    ve.PropertyName, ve.ErrorMessage);
                            }
                        }
                    }
                    message = "You have created a new account.";
                    status = true;
                }
            }

            else
            {
                message = "Invalid request.";
            }

            ViewBag.Message = message;
            ViewBag.Status = status;

            return View(customer);
        }

        private bool IsMailExist(string email)
        {
            using (var db = new DatabaseContext())
            {
                var v = db.Customers.FirstOrDefault(customer => customer.Email == email);
                return v != null;
            }
        }
        
        [NonAction]
        public byte[] GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
 
        [NonAction]
        public string Hash(string password, byte[] salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password,
                salt,
                KeyDerivationPrf.HMACSHA256,
                10000,
                256 / 8));
        }
    }
}