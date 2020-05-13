using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProje.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Display(Name = "Name")]
        public string  Name { get; set; }

        public int  role { get; set; }


      [Required(ErrorMessage = "username or password incorrect")]
        public string  Username{ get; set; }

      [Required(ErrorMessage = "username or password incorrect")]
        public string Password { get; set; }
    }
}