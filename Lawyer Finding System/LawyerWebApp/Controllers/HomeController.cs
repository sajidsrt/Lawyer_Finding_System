using FinalDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawyerWebApp.Controllers
{
    public class HomeController : Controller
    {
        LawyerDBEntities lawyerDBEntities = new LawyerDBEntities();
        QuestionRepository questionRepository = new QuestionRepository();


        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /BloodBank/Create

        [HttpPost]
        public ActionResult Index(Question question,String search,String add,String area,String SearchTerm)
        {
            List<Question> personList = lawyerDBEntities.Questions.ToList();
            List<string> properties = personList.Select(o => o.Question1).ToList();

            try
            {
                if (add != null && question.Question1 != null)
                {     // TODO: Add insert logic here
                    if (ModelState.IsValid)
                    {
                        if (!properties.Contains(question.Question1))
                        {
                            questionRepository.AddQuestion(question);
                            return RedirectToAction("QuestionConfirmation", "Home");
                        }
                        else
                        {
                            return RedirectToAction("SearchingResult", "Answer", new { txtSearch = question.Question1 });
                        }
                    }


                }
                if (SearchTerm == ""&& search != null)
                {
                    TempData["msg"] = "<script>alert('Searching content is empty');</script>";
                    return View();
                }
                if (search!=null)
                {
                    return RedirectToAction("KMPSubstringSearchMethod", "Answer", new { txtSearch = SearchTerm });
                }
              
                if (area != null)
                {
                    return RedirectToAction("SearchingLawyer", "Lawyer", new { txtSearch = SearchTerm });
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        

        
        public ActionResult QuestionConfirmation()
        {
            return View();
        }
        public ActionResult QuestionList(int id)
        {
            ViewData["user_id"] = id;
            List<Question> questions = questionRepository.GetQuestionList();

            return View(questions);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}