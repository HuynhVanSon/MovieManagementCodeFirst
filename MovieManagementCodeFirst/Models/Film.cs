using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieManagementCodeFirst.Models
{
    public class Film
    {
        public int ID { get; set; }
        public int FilmTypeID { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
        public virtual FilmType FilmType { get; set; }
        public Film()
        {

        }
    }
}