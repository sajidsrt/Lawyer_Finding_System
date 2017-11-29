using FinalDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawyerWebApp.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Appointment
       AppointmentRepository appointmentRepository = new AppointmentRepository();
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
        public ActionResult Create(int UserID, int LawyerID)
        {
            ViewData["lawyer_id"] = LawyerID;
            ViewData["user_id"] = UserID;
            return View();
        }

        //
        // POST: /BloodBank/Create

        [HttpPost]
        public ActionResult Create(int userID, Appointment answer)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    appointmentRepository.AddAppointment(answer);
                    return RedirectToAction("AppointmentListByNormalUser", "Appointment", new { id = userID });
                }
                return View();
            }
            catch
            {
                return View();
            }
        }


        // GET: Answer/Edit/5
        public ActionResult EditByNormalUser(int id)
        {

            Appointment user = appointmentRepository.GetAppointmentByID(id);

            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult EditByNormalUser(int LawyerID, int userID, Appointment lawyer)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    appointmentRepository.EditAppointment(lawyer);
                    return RedirectToAction("AppointmentListByNormalUser", "Appointment", new { id = userID });

                }

                return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult EditByLawyer(int id)
        {

            Appointment user = appointmentRepository.GetAppointmentByID(id);

            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult EditByLawyer(int id, Appointment lawyer)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    appointmentRepository.EditAppointment(lawyer);
                    return RedirectToAction("AppointmentListByLawyer", "Appointment", new { id = lawyer.LawyerID });

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
            Appointment lawyer = appointmentRepository.GetAppointmentByID(id);
            return View(lawyer);
        }

    
        // POST: /User/Delete/5

        [HttpPost]
        public ActionResult Delete(int LawyerID, int userID, Appointment lawyer)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    appointmentRepository.DeleteAppointment(lawyer);
                    return RedirectToAction("AppointmentListByNormalUser", "Appointment", new { id = userID });

                }

                return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult SearchingResult(string txtSearch)
        {

            return View(lawyerDBEntities.Answers.Where(x => x.Question.Question1.Contains(txtSearch)).ToList());

        }
     
        public ActionResult AppointmentListByNormalUser(int id)
        {
            ViewData["user_id"] = id;
            List<Appointment> answers = appointmentRepository.GetAppointmentListByUser(id);

            return View(answers);
        }
        public ActionResult AppointmentListByLawyer(int id)
        {
            ViewData["Lawyer_id"] = id;
            List<Appointment> answers = appointmentRepository.GetAppointmentListByLawyer(id);

            return View(answers);
        }

    }
}