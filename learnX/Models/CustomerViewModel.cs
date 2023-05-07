using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace learnX.Models
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
        }

        [DisplayName("ID")]
        public int CID { get; set; }

        [DisplayName("Họ và tên")]
        [MaxLength(125, ErrorMessage = "Họ và tên không quá 125 ký tự.")]
        public string cName { get; set; }

        [DisplayName("Giới tính")]
        public bool cSex { get; set; }

        [DisplayName("Địa chỉ khách hàng")]
        [MaxLength(1000, ErrorMessage = "Thông tin địa chỉ không quá 1000 ký tự.")]
        public string cAddress { get; set; }
    }
}
