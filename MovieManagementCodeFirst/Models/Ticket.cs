using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieManagementCodeFirst.Models
{
    public class Ticket
    {
        public int ID { get; set; }
        public int FilmID { get; set; }
        public int TicketTypeID { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public DateTime StartHours { get; set; }
        public DateTime EndHours { get; set; }
        public virtual Film Film { get; set; }
        public virtual TicketType TicketType { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public Ticket()
        {

        }
    }
}