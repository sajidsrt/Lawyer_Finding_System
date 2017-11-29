using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalDAL;
namespace LawyerWebApp.Controllers
{
    public class QuestionController : Controller
    {
        LawyerDBEntities lawyerDBEntities = new LawyerDBEntities();

        // GET: Question
        public ActionResult Index()
        {
            return View();
        }

        // GET: Question/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Question/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Question/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Question/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Question/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Question/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public JsonResult GetStudents(string term)
        {
            List<string> students = lawyerDBEntities.Questions.Where(s => s.Question1.StartsWith(term)).Select(x => x.Question1).ToList();
            return Json(students, JsonRequestBehavior.AllowGet);
        }

        public ActionResult search()
        {
            

            return View(lawyerDBEntities.Questions);
        }
        [HttpPost]
        public ActionResult search(string searchTerm)
        {

            List<Question> students;

            students = lawyerDBEntities.Questions
                .Where(s => s.Question1.Contains(searchTerm)).ToList();

            return View(students);
        }

        public ActionResult SearchingResult(string txtSearch)
        {

            return View(lawyerDBEntities.Questions.Where(x => x.Question1 == txtSearch).ToList());

        }
    }
}
