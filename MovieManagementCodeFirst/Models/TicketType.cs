﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieManagementCodeFirst.Models
{
    public class TicketType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Seat { get; set; }
        public int PricePercent { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public TicketType()
        {

        }
    }
}