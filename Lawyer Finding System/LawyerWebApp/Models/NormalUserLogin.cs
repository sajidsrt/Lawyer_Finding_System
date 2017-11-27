using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LawyerWebApp.Models
{
    public class NormalUserLogin
    {
        [Required(ErrorMessage = "UserName is required")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType("password")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}