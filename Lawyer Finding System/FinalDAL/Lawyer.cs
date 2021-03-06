//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lawyer
    {
        public Lawyer()
        {
            this.Answers = new HashSet<Answer>();
            this.Appointments = new HashSet<Appointment>();
            this.Ratings = new HashSet<Rating>();
        }
    
        public string LawyerID { get; set; }
        public string PhotoPath { get; set; }
        public int UserID { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string PractiseArea { get; set; }
        public string MembershipIdNo { get; set; }
        public string CareerSummary { get; set; }
        public string CareerGoals { get; set; }
        public string Expertise { get; set; }
        public string EnrollmentYear { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string NID { get; set; }
        public string Nationality { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string OfficeAddress { get; set; }
        public Nullable<System.Guid> ActivationCode { get; set; }
        public bool IsEmailVerified { get; set; }
        public string ConfirmPassword { get; set; }
        public string ResetPasswordCode { get; set; }
    
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
