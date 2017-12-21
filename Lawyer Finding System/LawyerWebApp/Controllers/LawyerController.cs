using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalDAL;
using LawyerWebApp.Models;
using System.Web.Security;
using System.Web.Helpers;
using System.Net.Mail;
using System.Net;

namespace LawyerWebApp.Controllers
{
    
    
    public class LawyerController : Controller
    {
        LawyerDBEntities lawyerDBEntities = new LawyerDBEntities();
        LawyerRepository lawyerRepository = new LawyerRepository();
        // GET: Lawyer
       
       public ActionResult Index()
       {
           return View();
       }
    
        public new ActionResult Profile(int userID)
       {
           ViewData["user_id"] = userID;
           Lawyer user = lawyerRepository.GetLawyerByID(userID);
           return View(user);
       }

       public  ActionResult ProfileForSearchByArea(int userID, String text)
        {
            ViewData["searchItem"] = text;

            Lawyer user = lawyerRepository.GetLawyerByID(userID);
           return View(user);
       }
        public ActionResult ProfileForSearchByCategory(int userID, String text)
        {
            ViewData["searchItem"] = text;

            Lawyer user = lawyerRepository.GetLawyerByID(userID);
            return View(user);
        }
        public ActionResult ProfileForOthers(int userID,String text)
        {
            ViewData["searchItem"] = text;
            Lawyer user = lawyerRepository.GetLawyerByID(userID);
            return View(user);
        }
        public ActionResult ProfileForOthersLoggedInRejected(int userID,int NormalUserID)
        {
            ViewData["NormalUser_id"] = NormalUserID;
            Lawyer user = lawyerRepository.GetLawyerByID(userID);
            return View(user);
        }
        public ActionResult ProfileForOthersLoggedInAccepted(int userID, int NormalUserID)
        {
            ViewData["NormalUser_id"] = NormalUserID;
            Lawyer user = lawyerRepository.GetLawyerByID(userID);
            return View(user);
        }
        // GET: Lawyer/Details/5
        public ActionResult Details(int userID)
       {
           Lawyer user = lawyerRepository.GetLawyerByID(userID);
           return View(user);
       }

       public ActionResult Create()
       {
           return View();
       }

       //
       // POST: /BloodBank/Create

       [HttpPost]
       public ActionResult Create(Lawyer lawyer, HttpPostedFileBase file)
       {
           try
           {
               // TODO: Add insert logic here
               if (ModelState.IsValid)
               {
                   if (file != null)
                   {
                       string ImageName = System.IO.Path.GetFileName(file.FileName);
                       string physicalPath = Server.MapPath("~/images/" + ImageName);

                       // save image in folder
                       file.SaveAs(physicalPath);
                       lawyer.PhotoPath = ImageName;
                   }
                   lawyerRepository.AddLawyer(lawyer);
                   return RedirectToAction("Login");
               }
               return View();
           }
           catch
           {
               return View();
           }
       }

       // GET: Lawyer/Edit/5
       public ActionResult Edit(int id)
       {

           Lawyer user = lawyerRepository.GetLawyerByID(id);

           return View(user);
       }

       //
       // POST: /User/Edit/5

       [HttpPost]
       public ActionResult Edit(int id, Lawyer lawyer, HttpPostedFileBase file)
       {
           try
           {
               // TODO: Add update logic here

               if (ModelState.IsValid)
               {
                   if (file != null)
                   {
                       string ImageName = System.IO.Path.GetFileName(file.FileName);
                       string physicalPath = Server.MapPath("~/images/" + ImageName);

                       // save image in folder
                       file.SaveAs(physicalPath);
                       lawyer.PhotoPath = ImageName;
                   }
                   lawyerRepository.EditLawyer(lawyer);
                   Lawyer user = lawyerRepository.GetLawyerByID(id);
                   Session["User"] = user;

                   return RedirectToAction("Profile", "Lawyer", new { UserID = user.UserID });


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
            ViewData["lawyer_id"] = id;

            Lawyer lawyer = lawyerRepository.GetLawyerByID(id);
           return View(lawyer);
       }

       //
       // POST: /User/Delete/5

       [HttpPost]
       public ActionResult Delete(int id, Lawyer lawyer)
       {
           try
           {
               // TODO: Add update logic here

               if (ModelState.IsValid)
               {
                   lawyerRepository.DeleteUser(lawyer);
                   return RedirectToAction("Login");

               }

               return View();
           }
           catch
           {
               return View();
           }
       }
/*
       public ActionResult Login()
       {
           return View();
       }

       [HttpPost]
       public ActionResult Login(AccountLogin login)
       {
           if (ModelState.IsValid)
           {
               if (lawyerRepository.ValidLawyer(login.LawyerID, login.Password))
               {
                   FormsAuthentication.SetAuthCookie(login.LawyerID, false);
                   Lawyer user = lawyerRepository.GetLawyerByLawyerIDAndPassword(login.LawyerID, login.Password);
                   Session["User"] = user;

                       return RedirectToAction("Profile", "Lawyer", new { UserID= user.UserID });



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
           return RedirectToAction("Index", "Home");

       }
       public ActionResult LawyerRegistration()
       {
           return View();
       }



       [HttpPost]
       public ActionResult LawyerRegistration(Lawyer lawyer)
       {
           try
           {
               // TODO: Add insert logic here
               if (ModelState.IsValid)
               {
                   lawyerRepository.AddLawyer(lawyer);
                   return RedirectToAction("Index", "Home");
               }
               return View();
           }
           catch
           {
               return View();
           }
       }
       public ActionResult dummy()
       {
           return View();
       }
       */

       public ActionResult SearchingLawyer(String txtSearch)
       {
            ViewData["searchItem"] = txtSearch;

            List<Lawyer> questionList = lawyerDBEntities.Lawyers.ToList();
            List<string> questions = questionList.Select(o => o.PresentAddress).ToList();
            List<string> list = new List<string>();

            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].Equals(txtSearch))
                {
                    list.Add(questions[i]);

                }
            }
            ViewData["MyData"] = list;

            return View(lawyerDBEntities.Lawyers.Where(x => x.PresentAddress == txtSearch).ToList());
       }
       public ActionResult SearchingLawyerByCategory(String txtSearch)
       {
            ViewData["searchItem"] = txtSearch;

            List<Lawyer> questionList = lawyerDBEntities.Lawyers.ToList();
            List<string> questions = questionList.Select(o => o.Expertise).ToList();
            List<string> list = new List<string>();
            bool flag = true;

            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].Equals(txtSearch))
                {
                    flag = true;
                }
                else
                    flag = false;
                if (flag)

                {
                    list.Add(questions[i]);
                }
            }
            ViewData["MyData"] = list;
            return View(lawyerDBEntities.Lawyers.Where(x => x.Expertise == txtSearch).ToList());
       }
       
        //Registration Action

       
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        //Registration POST action 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Exclude = "IsEmailVerified,ActivationCode")] Lawyer user, HttpPostedFileBase file)
        {
            bool Status = false;
            string message = "";
            //
            // Model Validation 
            if (ModelState.IsValid)
            {

                #region //Email is already Exist 
                var isExist = IsEmailExist(user.Email);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist");
                    return View(user);
                }
                #endregion

                #region Generate Activation Code 
                user.ActivationCode = Guid.NewGuid();
                #endregion

                #region  Password Hashing 
               // user.Password = Crypto.Hash(user.Password);
              //  user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword); //
                #endregion
                user.IsEmailVerified = false;

                #region Save to Database
                using (LawyerDBEntities dc = new LawyerDBEntities())
                {
                    if (file != null)
                    {
                        string ImageName = System.IO.Path.GetFileName(file.FileName);
                        string physicalPath = Server.MapPath("~/images/" + ImageName);

                        // save image in folder
                        file.SaveAs(physicalPath);
                        user.PhotoPath = ImageName;
                    }

                    dc.Lawyers.Add(user);
                    dc.SaveChanges();

                    //Send Email to User
                    SendVerificationLinkEmail(user.Email, user.ActivationCode.ToString());
                    message = "Registration successfully done. Account activation link " +
                        " has been sent to your email id:" + user.Email;
                    Status = true;
                }
                #endregion
            }
            else
            {
                message = "Invalid Request";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(user);
        }

        [HttpPost]
        public JsonResult DoesUserEmailExist(string email)
        {

            var user = lawyerRepository.GetLawyerByEmail(email);

            return Json(user == null);
        }

        //Verify Account  
        public ActionResult RegistrationConfirmation()
        {
            return View();
        }


        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool Status = false;
            using (LawyerDBEntities dc = new LawyerDBEntities())
            {
                dc.Configuration.ValidateOnSaveEnabled = false; // This line I have added here to avoid 
                                                                // Confirm password does not match issue on save changes
                var v = dc.Lawyers.Where(a => a.ActivationCode == new Guid(id)).FirstOrDefault();
                if (v != null)
                {
                    v.IsEmailVerified = true;
                    dc.SaveChanges();
                    Status = true;
                }
                else
                {
                    ViewBag.Message = "Invalid Request";
                }
            }
            ViewBag.Status = Status;
            return View();
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
        public ActionResult Login(UserLogin login, string ReturnUrl = "")
        {
            string message = "";
            using (LawyerDBEntities dc = new LawyerDBEntities())
            {
                var v = dc.Lawyers.Where(a => a.Email == login.EmailID).FirstOrDefault();
                if (v != null)
                {
                   if (!v.IsEmailVerified)
                    {
                        ViewBag.Message = "Please verify your email first";
                        return View();
                    } 

                    if (string.Compare(login.Password, v.Password) == 0)
                    {
                        int timeout = login.RememberMe ? 525600 : 20; // 525600 min = 1 year
                        var ticket = new FormsAuthenticationTicket(login.EmailID, login.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);


                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Profile", "Lawyer", new { UserID = v.UserID });
                        }
                    }
                    else
                    {
                        message = "Invalid credential provided";
                    }
                }
                else
                {
                    message = "Invalid credential provided";
                }
            }
            ViewBag.Message = message;
            return View();
        }

        //Logout
      
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session["User"] = null;
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Login", "Lawyer");

        }

        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            using (LawyerDBEntities dc = new LawyerDBEntities())
            {
                var v = dc.Lawyers.Where(a => a.Email == emailID).FirstOrDefault();
                return v != null;
            }
        }

        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string activationCode, string emailFor = "VerifyAccount")
        {
            var verifyUrl = "/Lawyer/" + emailFor + "/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("bsse0633@iit.du.ac.bd", "Lawyer Finding System");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "sajidsrt"; // Replace with actual password

            string subject = "";
            string body = "";
            if (emailFor == "VerifyAccount")
            {
                subject = "Your account is successfully created!";
                body = "<br/><br/>We are excited to tell you that your Lawyer Finding System account is" +
                    " successfully created. Please click on the below link to verify your account" +
                    " <br/><br/><a href='" + link + "'>" + link + "</a> ";

            }
            else if (emailFor == "ResetPassword")
            {
                subject = "Reset Password";
                body = "Hi,<br/> We got request for reset your account password. Please click on the below link to reset your password" +
                    "<br/><br/><a href=" + link + ">Reset Password link</a>";
            }


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }



        [NonAction]
        public void SendVerificationLinkEmail2(string emailID, string activationCode)
        {
            var verifyUrl = "/Lawyer/VerifyAccount/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("bsse0633@iit.du.ac.bd", "Dotnet Awesome");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "sajidsrt"; // Replace with actual password
            string subject = "Your account is successfully created!";

            string body = "<br/><br/>We are excited to tell you that your Dotnet Awesome account is" +
                " successfully created. Please click on the below link to verify your account" +
                " <br/><br/><a href='" + link + "'>" + link + "</a> ";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }


        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string EmailID)
        {
            //Verify Email ID
            //Generate Reset password link 
            //Send Email 
            string message = "";
            bool status = false;

            using (LawyerDBEntities dc = new LawyerDBEntities())
            {
                var account = dc.Lawyers.Where(a => a.Email == EmailID).FirstOrDefault();
                if (account != null)
                {
                    //Send email for reset password
                    string resetCode = Guid.NewGuid().ToString();
                    SendVerificationLinkEmail(account.Email, resetCode, "ResetPassword");
                    account.ResetPasswordCode = resetCode;
                    //This line I have added here to avoid confirm password not match issue , as we had added a confirm password property 
                    //in our model class in part 1
                    dc.Configuration.ValidateOnSaveEnabled = false;
                    dc.SaveChanges();
                    message = "Reset password link has been sent to your email id.";
                }
                else
                {
                    message = "Account not found";
                }
            }
            ViewBag.Message = message;
            return View();
        }

        public ActionResult ResetPassword(string id)
        {
            //Verify the reset password link
            //Find account associated with this link
            //redirect to reset password page
            if (string.IsNullOrWhiteSpace(id))
            {
                return HttpNotFound();
            }

            using (LawyerDBEntities dc = new LawyerDBEntities())
            {
                var user = dc.Lawyers.Where(a => a.ResetPasswordCode == id).FirstOrDefault();
                if (user != null)
                {
                    ResetPasswordModel model = new ResetPasswordModel();
                    model.ResetCode = id;
                    return View(model);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                using (LawyerDBEntities dc = new LawyerDBEntities())
                {
                    var user = dc.Lawyers.Where(a => a.ResetPasswordCode == model.ResetCode).FirstOrDefault();
                    if (user != null)
                    {
                        user.Password = model.NewPassword;
                        user.ResetPasswordCode = "";
                        dc.Configuration.ValidateOnSaveEnabled = false;
                        dc.SaveChanges();
                        message = "New password updated successfully";
                    }
                }
            }
            else
            {
                message = "Something invalid";
            }
            ViewBag.Message = message;
            return View(model);
        }



    }
}
