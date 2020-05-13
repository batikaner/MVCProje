using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProje.Models.SerieViewModels
{
    public class SerieViewModels
    {
        public  Serie tv { get; set; }

        public IEnumerable<Serie> tvserie { get; set; }
    }
}