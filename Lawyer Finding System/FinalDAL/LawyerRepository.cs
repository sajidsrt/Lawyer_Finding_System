using FinalDAL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalDAL
{
    public class LawyerRepository
    {

        LawyerDBEntities lawyerDBEntities = new LawyerDBEntities();

        public bool AddLawyer(Lawyer lawyer)
        {
            lawyerDBEntities.Lawyers.Add(lawyer);
            return lawyerDBEntities.SaveChanges() > 0;
        }

        public bool EditLawyer(Lawyer Lawyer)
        {
            lawyerDBEntities.Lawyers.Attach(Lawyer);
            lawyerDBEntities.Entry(Lawyer).State = System.Data.Entity.EntityState.Modified;
            return lawyerDBEntities.SaveChanges() > 0;
        }

        public bool DeleteUser(Lawyer user)
        {
            lawyerDBEntities.Lawyers.Attach(user);
            lawyerDBEntities.Entry(user).State = System.Data.Entity.EntityState.Deleted;
            return lawyerDBEntities.SaveChanges() > 0;
        }

        public List<Lawyer> GetLawyerList()
        {
            return lawyerDBEntities.Lawyers.ToList();
        }
        public List<Lawyer> GetLawyerListByLawyerID(String LawyerID)
        {
            return lawyerDBEntities.Lawyers.Where(b => b.LawyerID == LawyerID).ToList();
        }
        public Lawyer GetLawyerByID(int Id)
        {
            return lawyerDBEntities.Lawyers.FirstOrDefault(u => u.UserID == Id);
        }

        public Lawyer GetLawyerByLawyerIDAndPassword(string lawyerID, string password)
        {
            return lawyerDBEntities.Lawyers.FirstOrDefault(u => u.LawyerID == lawyerID && u.Password == password);
        }

        public bool ValidLawyer(string lawyerID, string password)
        {
            return lawyerDBEntities.Lawyers.Count(u => u.LawyerID == lawyerID && u.Password == password) > 0;
        }
    }
}
