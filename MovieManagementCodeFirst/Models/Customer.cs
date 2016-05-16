using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieManagementCodeFirst.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Hãy nhập tên của bạn")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Hãy nhập số chứng minh nhân dân của bạn")]
        [DataType(DataType.PostalCode)]
        public string IDCard { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "Hãy chọn giới tính của bạn")]
        public Gender Genders { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Hãy nhập số điện thoại của bạn")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public Customer()
        {

        }
    }

    public enum Gender
    {
        Nam,
        Nữ,
        Khác
    }
}