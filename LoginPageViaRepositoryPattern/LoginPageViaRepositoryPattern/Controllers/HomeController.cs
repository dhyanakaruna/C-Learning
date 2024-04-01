﻿using LoginPageViaRepositoryPattern.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LoginPageViaRepositoryPattern.Controllers
{
    public class HomeController : Controller
    {
    
        private readonly IUsers iu;

        public HomeController()
        {
            iu = new UsersRepository("Nothing");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string email,string password)
        {
            bool result = iu.Verify(email, password);

            if (result == true)
            {
                return View("LoginSuccess");
            }
            else
            {
                ViewBag.message = "Login Failed";
                return View("Index");
            }
        }

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult Register(Users u)
        {
            ValidationError v = new ValidationError();

            v = Validation(u);

            if (v.retval==true)
            {
                bool x=iu.Register(u);

                if (x == true)
                {
                    TempData["message"] = "User have been registered successfully.";
                    return RedirectToAction("Registration");
                }
                else
                {
                    ViewBag.message ="Unspecified Error in Data Insertion.";
                    return View("Registration", u);
                }
            }
            else
            {
                ViewBag.message = v.retmsg;
                return View("Registration", u);
            }
        }

        public ValidationError Validation(Users u)
        {
            ValidationError ve = new ValidationError();

            if(u.fullname==null||u.email==null||u.password==null||u.confirmpass==null)
            {
                ve.retval = false;
                ve.retmsg = "Input can no be blank.";

                return ve;
            }
            else if (iu.FindDuplicate(u.email) == false)
            {
                ve.retval = false;
                ve.retmsg = "You have already registered with this email.";

                return ve;
            }
            else if(u.password.Length<4 || u.password.Length > 8)
            {
                ve.retval = false;
                ve.retmsg = "Password must be more than 4 and less than 8 characters.";

                return ve;
            }
            else if(!u.password.Equals(u.confirmpass))
            {
                ve.retval = false;
                ve.retmsg = "Password and Confirm Password are not equal.";

                return ve;
            }
            else
            {
                ve.retval = true;
                ve.retmsg = null;

                return ve;
            }
        }
    }
}
