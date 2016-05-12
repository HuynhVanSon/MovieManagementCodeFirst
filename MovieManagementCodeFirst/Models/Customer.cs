using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieManagementCodeFirst.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int IDCard { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public Customer()
        {

        }
    }
}