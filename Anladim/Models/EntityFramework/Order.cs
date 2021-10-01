using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Anladim.Models.EntityFramework
{
    public class Order
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int UserAddressId { get; set; }
        public UserAddress UserAddress { get; set; }
        public DateTime OrderDate { get; set; }

        [Range(1, 99999999999.99)]
        public decimal TotalPrice { get; set; }
        public virtual List<OrderProduct> OrderProducts { get; set; }
    }
}