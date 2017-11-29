using FinalDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawyerWebApp.Controllers
{
    public class AnswerController : Controller
    {
        AnswerRepository answerRepository = new AnswerRepository();
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
        public ActionResult Create(int id, int UserID)
        {
            ViewData["question_id"] = id;
            ViewData["user_id"] = UserID;
            return View();
        }

        //
        // POST: /BloodBank/Create

        [HttpPost]
        public ActionResult Create(int userID, Answer answer)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    answerRepository.AddAnswer(answer);
                    return RedirectToAction("AnswerList", new { id = userID });
                }
                return View();
            }
            catch
            {
                return View();
            }
        }


        // GET: Answer/Edit/5
        public ActionResult Edit(int id)
        {

            Answer user = answerRepository.GetAnswerByID(id);

            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(int id,int userID, Answer lawyer)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    answerRepository.EditAnswer(lawyer);
                    return RedirectToAction("AnswerList", new { id = userID });

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
            Answer lawyer = answerRepository.GetAnswerByID(id);
            return View(lawyer);
        }

        //
        // POST: /User/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, int userID, Answer lawyer)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    answerRepository.DeleteAnswer(lawyer);
                    return RedirectToAction("AnswerList", new { id = userID });

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
    }
}

