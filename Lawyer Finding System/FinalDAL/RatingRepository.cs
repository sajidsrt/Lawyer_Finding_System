using FinalDAL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalDAL
{
    public class RatingRepository
    {

        LawyerDBEntities lawyerDBEntities = new LawyerDBEntities();

        public bool AddRating(Rating Rating)
        {
            bool response = false;

            try
            {
                lawyerDBEntities.Ratings.Add(Rating);
                lawyerDBEntities.SaveChanges();
                response = true;
            }
            catch { response = false; }
            return response;
        }

        public bool EditRating(Rating Rating)
        {
            lawyerDBEntities.Ratings.Attach(Rating);
            lawyerDBEntities.Entry(Rating).State = System.Data.Entity.EntityState.Modified;
            return lawyerDBEntities.SaveChanges() > 0;
        }

        public bool DeleteRating(Rating Rating)
        {
            lawyerDBEntities.Ratings.Attach(Rating);
            lawyerDBEntities.Entry(Rating).State = System.Data.Entity.EntityState.Deleted;
            return lawyerDBEntities.SaveChanges() > 0;
        }

        public List<Rating> GetRatingList()
        {
            return lawyerDBEntities.Ratings.ToList();
        }

        public Rating GetRatingByID(int Id)
        {
            return lawyerDBEntities.Ratings.FirstOrDefault(u => u.RatingID == Id);
        }
    }
}
