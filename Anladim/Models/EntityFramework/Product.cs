using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Anladim.Models.EntityFramework
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(1, 999999999.99)]
        public decimal Price { get; set; }
        public int? QuantityProd { get; set; }
    }
}