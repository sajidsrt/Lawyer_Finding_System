using FinalDAL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalDAL
{
    public class NormalUserRepository
    {
        LawyerDBEntities lawyerDBEntities = new LawyerDBEntities();

        public bool AddNormalUser(NormalUser NormalUser)
        {
            bool response = false;

            try
            {
                lawyerDBEntities.NormalUsers.Add(NormalUser);
                
                response = lawyerDBEntities.SaveChanges()>0;
            }
            catch { response = false; }
            return response;
        }

        public bool EditNormalUser(NormalUser NormalUser)
        {
            lawyerDBEntities.NormalUsers.Attach(NormalUser);
            lawyerDBEntities.Entry(NormalUser).State = System.Data.Entity.EntityState.Modified;
            return lawyerDBEntities.SaveChanges() > 0;
        }

        public bool DeleteNormalUser(NormalUser NormalUser)
        {
            lawyerDBEntities.NormalUsers.Attach(NormalUser);
            lawyerDBEntities.Entry(NormalUser).State = System.Data.Entity.EntityState.Deleted;
            return lawyerDBEntities.SaveChanges() > 0;
        }

        public List<NormalUser> GetNormalUserList()
        {
            return lawyerDBEntities.NormalUsers.ToList();
        }
     

        public NormalUser GetNormalUserByID(int Id)
        {
            return lawyerDBEntities.NormalUsers.FirstOrDefault(u => u.UserID == Id);
        }
        public NormalUser GetNormalUserByUserNameAndPassword(string UserName, string password)
        {
            return lawyerDBEntities.NormalUsers.FirstOrDefault(u => u.UserName == UserName && u.Password == password);
        }
        public bool ValidNormalUser(string UserName, string password)
        {
            return lawyerDBEntities.NormalUsers.Count(u => u.UserName == UserName && u.Password == password) > 0;
        }
    }
}
