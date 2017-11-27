using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LawyerWebApp.Models
{
    public class AccountLogin
    {

        [Required(ErrorMessage = "LawyerID is required")]
        [Display(Name = "LawyerID")]
        public string LawyerID { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType("password")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}