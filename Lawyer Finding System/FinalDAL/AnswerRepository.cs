using FinalDAL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalDAL
{
    public class AnswerRepository
    {

        LawyerDBEntities lawyerDBEntities = new LawyerDBEntities();

        public bool AddAnswer(Answer Answer)
        {
            bool response = false;

            try
            {
                lawyerDBEntities.Answers.Add(Answer);
                lawyerDBEntities.SaveChanges();
                response = true;
            }
            catch { response = false; }
            return response;
        }

        public bool EditAnswer(Answer Answer)
        {
            lawyerDBEntities.Answers.Attach(Answer);
            lawyerDBEntities.Entry(Answer).State = System.Data.Entity.EntityState.Modified;
            return lawyerDBEntities.SaveChanges() > 0;
        }

        public bool DeleteAnswer(Answer Answer)
        {
            lawyerDBEntities.Answers.Attach(Answer);
            lawyerDBEntities.Entry(Answer).State = System.Data.Entity.EntityState.Deleted;
            return lawyerDBEntities.SaveChanges() > 0;
        }

        public List<Answer> GetAnswerList()
        {
            return lawyerDBEntities.Answers.ToList();
        }
        public List<Answer> GetAnswerListByUser(int id)
        {
            return lawyerDBEntities.Answers.Where(x => x.UserID == id).ToList();
        }
        
        public Answer GetAnswerByID(int Id)
        {
            return lawyerDBEntities.Answers.FirstOrDefault(u => u.AnswerID == Id);
        }
    }
}
