using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieManagementCodeFirst.Models
{
    public class HourPresent
    {
        public int ID { get; set; }
        public int FilmID { get; set; }
        public DateTime StartHours { get; set; }
        public DateTime EndHours { get; set; }
        public virtual Film Film { get; set; }
        public HourPresent()
        {

        }
    }
}