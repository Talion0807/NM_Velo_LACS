using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NM_Velo_LACS.Models;

namespace NM_Velo_LACS.Controllers
{
    public class UserController : Controller
    {
        //Registration Action
        [HttpGet]
        public ActionResult Inscription()
        {
            return View();
        }


        //Registraction POST action

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inscription([Bind()] User user)
        {
            bool Status = false;
            string message = "";
            //
            //Model Validation
            if (ModelState.IsValid)
            {
                #region //Email is already exist
                var isExist = IsEmailExist(user.EmailID);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist");
                    return View(user);
                }

                #endregion




                #region  //Password Hashing
                user.MotDePasse = Crypto.Hash(user.MotDePasse);
                user.ConfirmMDP = Crypto.Hash(user.ConfirmMDP);
                #endregion

                #region Save to Database

                using (BD_AuthentificationEntities dc = new BD_AuthentificationEntities())
                {
                    dc.Users.Add(user);
                    dc.SaveChanges();
                    //Send Email to User


                    message = "Registration successfully done. ";
                    Status = true;
                }

                #endregion
            }
            else
            {
                message = "Invaldi Request";
            }
            //Email is already Exist
            ViewBag.Message = message;

            ViewBag.Status = Status;


            return View(user);
        }

       

        //Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        //Login POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login (UserLogin login,string ReturnUrl)
        {
            string message = "";
           
            using(BD_AuthentificationEntities dc = new BD_AuthentificationEntities())
            {
                var v = dc.Users.Where(a => a.EmailID == login.EmailID).FirstOrDefault();
                if(v!=null)
                {
                    if(string.Compare(Crypto.Hash(login.MotDePasse),v.MotDePasse)==0)
                    {
                        int timeout = login.RemeberMe ? 525600 : 20;
                        var ticket = new FormsAuthenticationTicket(login.EmailID, login.RemeberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);


                        if(Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        message = "Identifiants invalide ";
                    }
                }
                else
                {
                    message = "Identifiants invalide ";
                }
            }
            ViewBag.Message = message;
            return View();
        }

        //Logout
        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }




        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            using (BD_AuthentificationEntities dc = new BD_AuthentificationEntities())
            {
                var v = dc.Users.Where(a => a.EmailID == emailID).FirstOrDefault();
                return v == null ? false : true;
            }
        }
    }
}