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
        [Required(ErrorMessage="Hãy nhập tài khoảng của bạn")]
        [StringLength(6, ErrorMessage="Tài khoảng phải hơn 6 ký tự")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Hãy nhập mật khẩu")]
        [StringLength(6, ErrorMessage = "Tài khoảng phải hơn 6 ký tự")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Hãy xác nhận mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="Mật khẩu xác nhận không đúng")]
        public string ConfirmPassword { get; set; }
        public int IsActive { get; set; }
        public virtual Customer Customer { get; set; }
        public Account()
        {

        }
    }
}