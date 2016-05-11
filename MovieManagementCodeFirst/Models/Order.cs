using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieManagementCodeFirst.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int TicketID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public int IsOnline { get; set; }
        public virtual Ticket Ticket { get; set; }
        public virtual Customer Customer { get; set; }
        public Order()
        {

        }
    }
}