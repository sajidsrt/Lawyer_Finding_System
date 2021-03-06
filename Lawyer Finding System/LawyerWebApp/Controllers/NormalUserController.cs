﻿using FinalDAL;
using LawyerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace LawyerWebApp.Controllers
{
    public class NormalUserController : Controller
    {
        // GET: NormalUser
        NormalUserRepository normalUserRepository = new NormalUserRepository();
        LawyerDBEntities lawyerDBEntities = new LawyerDBEntities();
        // GET: Answer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Answer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Answer/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /BloodBank/Create

        [HttpPost]
        public ActionResult Create(NormalUser normalUser)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    normalUserRepository.AddNormalUser(normalUser);
                    return RedirectToAction("Login");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CreateForAppointment(int id)
        {

            ViewData["user_id"] = id;
            return View();
            
        }

        //
        // POST: /BloodBank/Create

        [HttpPost]
        public ActionResult CreateForAppointment(int id, NormalUser normalUser)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    normalUserRepository.AddNormalUser(normalUser);
                    return RedirectToAction("LoginForAppointment",new {id = id});
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(NormalUserLogin login)
        {
            if (ModelState.IsValid)
            {
                if (normalUserRepository.ValidNormalUser(login.UserName, login.Password))
                {
                    FormsAuthentication.SetAuthCookie(login.UserName, false);
                    NormalUser user = normalUserRepository.GetNormalUserByUserNameAndPassword(login.UserName, login.Password);
                    Session["User"] = user;

                    return RedirectToAction("Profile", "NormalUser", new { UserID = user.UserID });



                }

                else
                {
                    return View("Login");
                }
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult LoginForAppointment(int id)
        {
            ViewData["user_id"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult LoginForAppointment(int id, NormalUserLogin login)
        {
            if (ModelState.IsValid)
            {
                if (normalUserRepository.ValidNormalUser(login.UserName, login.Password))
                {
                    FormsAuthentication.SetAuthCookie(login.UserName, false);
                    NormalUser user = normalUserRepository.GetNormalUserByUserNameAndPassword(login.UserName, login.Password);
                    Session["User"] = user;
                    return RedirectToAction("Create", "Appointment", new { UserID = user.UserID, LawyerID = id });



                }

                else
                {
                    return View("Login");
                }
            }
            else
            {
                return View("Login");
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session["User"] = null;
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Login", "NormalUser");

        }

        public new ActionResult Profile(int userID)
        {
            ViewData["user_id"] = userID;
            NormalUser user = normalUserRepository.GetNormalUserByID(userID);
            return View(user);
        }

        // GET: Answer/Edit/5
     public ActionResult Edit(int id)
        {
            ViewData["user_id"] = id;

            NormalUser user = normalUserRepository.GetNormalUserByID(id);

            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, NormalUser user)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    normalUserRepository.EditNormalUser(user);
                    return RedirectToAction("Profile", "NormalUser", new { UserID = user.UserID });

                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Lawyer/Delete/5
        public ActionResult Delete(int id)
        {
            ViewData["user_id"] = id;

            NormalUser lawyer = normalUserRepository.GetNormalUserByID(id);
            return View(lawyer);
        }

        //
        // POST: /User/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, NormalUser lawyer)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    normalUserRepository.DeleteNormalUser(lawyer);
                    return RedirectToAction("Login");

                }

                return View();
            }
            catch
            {
                return View();
            }
        }
        /*      public ActionResult SearchingResult(string txtSearch)
           {

               return View(lawyerDBEntities.Answers.Where(x => x.Question.Question1.Contains(txtSearch)).ToList());

           }

           public ActionResult KMPSubstringSearchMethod(string txtSearch)
           {

               List<String> list = new List<String>();

               string text = "abcd abc ab";
               char[] sText = text.ToCharArray();

               string pattern = txtSearch;
               char[] sPattern = pattern.ToCharArray();

               int forwardPointer = 1;
               int backwardPointer = 0;

               int[] tempStorage = new int[sPattern.Length];
               tempStorage[0] = 0;

               while (forwardPointer < sPattern.Length)
               {
                   if (sPattern[forwardPointer].Equals(sPattern[backwardPointer]))
                   {
                       tempStorage[forwardPointer] = backwardPointer + 1;
                       forwardPointer++;
                       backwardPointer++;
                   }
                   else
                   {
                       if (backwardPointer == 0)
                       {
                           tempStorage[forwardPointer] = 0;
                           forwardPointer++;
                       }
                       else
                       {
                           int temp = tempStorage[backwardPointer];
                           backwardPointer = temp;
                       }

                   }
               }

               int pointer = 0;
               int successPoints = sPattern.Length;
               bool success = false;
               for (int i = 0; i < sText.Length; i++)
               {
                   if (sText[i].Equals(sPattern[pointer]))
                   {
                       pointer++;
                   }
                   else
                   {
                       if (pointer != 0)
                       {
                           int tempPointer = pointer - 1;
                           pointer = tempStorage[tempPointer];
                           i--;
                       }
                   }

                   if (successPoints == pointer)
                   {
                       success = true;
                   }
               }

               if (success)
               {
                   list.Add(text);
                   return View(list);
               }
               else
               {
                   return View();

               }
           }
           public ActionResult AnswerList(int id)
           {
               ViewData["user_id"] = id;
               List<Answer> answers = answerRepository.GetAnswerListByUser(id);

               return View(answers);
           }
           */
    }
}