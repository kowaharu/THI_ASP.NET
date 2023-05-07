using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int CID { get; set; }
        public string cName { get; set; }
        public bool cSex { get; set; }
        public string cAddress { get; set; }
    }
}
