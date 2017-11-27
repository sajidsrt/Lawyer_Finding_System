using FinalDAL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalDAL
{
    public class QuestionRepository
    {
        LawyerDBEntities lawyerDBEntities = new LawyerDBEntities();

        public bool AddQuestion(Question Question)
        {
            lawyerDBEntities.Questions.Add(Question);
            return lawyerDBEntities.SaveChanges() > 0;
        }

        public bool EditQuestion(Question Question)
        {
            lawyerDBEntities.Questions.Attach(Question);
            lawyerDBEntities.Entry(Question).State = System.Data.Entity.EntityState.Modified;
            return lawyerDBEntities.SaveChanges() > 0;
        }

        public bool DeleteQuestion(Question Question)
        {
            lawyerDBEntities.Questions.Attach(Question);
            lawyerDBEntities.Entry(Question).State = System.Data.Entity.EntityState.Deleted;
            return lawyerDBEntities.SaveChanges() > 0;
        }

        public List<Question> GetQuestionList()
        {
            return lawyerDBEntities.Questions.ToList();
        }

        public Question GetQuestionByID(int Id)
        {
            return lawyerDBEntities.Questions.FirstOrDefault(u => u.QuestionID == Id);
        }
    }
}
