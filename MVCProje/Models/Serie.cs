using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCProje.Models
{
    public class Serie
    {
        public int SerieId { get; set; }


        [Required(ErrorMessage = "Enter title")]
        [Display(Name = "Title")]
        public string  title { get; set; }


        [Required(ErrorMessage = "Enter rating")]
        [Display(Name = "Rating")]
        public string rating { get; set; }

        public string category { get; set; }
    }
}