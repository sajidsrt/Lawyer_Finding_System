using FinalDAL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalDAL
{
    public class AppointmentRepository
    {
        LawyerDBEntities lawyerDBEntities = new LawyerDBEntities();

        public bool AddAppointment(Appointment Appointment)
        {
            bool response = false;

            try
            {
                lawyerDBEntities.Appointments.Add(Appointment);
                lawyerDBEntities.SaveChanges();
                response = true;
            }
            catch { response = false; }
            return response;
        }

        public bool EditAppointment(Appointment Appointment)
        {
            lawyerDBEntities.Appointments.Attach(Appointment);
            lawyerDBEntities.Entry(Appointment).State = System.Data.Entity.EntityState.Modified;
            return lawyerDBEntities.SaveChanges() > 0;
        }

        public bool DeleteAppointment(Appointment Appointment)
        {
            lawyerDBEntities.Appointments.Attach(Appointment);
            lawyerDBEntities.Entry(Appointment).State = System.Data.Entity.EntityState.Deleted;
            return lawyerDBEntities.SaveChanges() > 0;
        }

        public List<Appointment> GetAppointmentList()
        {
            return lawyerDBEntities.Appointments.ToList();
        }
        public List<Appointment> GetAppointmentListByUser(int id)
        {
            return lawyerDBEntities.Appointments.Where(x => x.NormalUserID == id).ToList();
        }
        public List<Appointment> GetAppointmentListByLawyer(int id)
        {
            return lawyerDBEntities.Appointments.Where(x => x.LawyerID == id).ToList();
        }
        public Appointment GetAppointmentByID(int Id)
        {
            return lawyerDBEntities.Appointments.FirstOrDefault(u => u.AppointmentID == Id);
        }
    }
}

