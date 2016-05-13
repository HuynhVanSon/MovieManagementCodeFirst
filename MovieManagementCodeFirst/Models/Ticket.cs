using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieManagementCodeFirst.Models
{
    public class Ticket
    {
        public int ID { get; set; }
        public int FilmID { get; set; }
        public int TicketTypeID { get; set; }
        [Required(ErrorMessage = "Hãy nhập giá vé")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Hãy nhập số lượng vé")]
        public int Quantity { get; set; }
        public DateTime DatePresent { get; set; }
        [Required(ErrorMessage = "Hãy nhập giờ bắt đầu")]
        public DateTime StartHours { get; set; }
        [Required(ErrorMessage = "Hãy nhập giờ kết thúc")]
        public DateTime EndHours { get; set; }
        public virtual Film Film { get; set; }
        public virtual TicketType TicketType { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public Ticket()
        {

        }
    }
}