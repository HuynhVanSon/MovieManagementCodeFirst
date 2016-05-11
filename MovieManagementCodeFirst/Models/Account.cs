using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieManagementCodeFirst.Models
{
    public class Account
    {
        [Key, ForeignKey("Customer")]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int IsActive { get; set; }
        public virtual Customer Customer { get; set; }
        public Account()
        {

        }
    }
}