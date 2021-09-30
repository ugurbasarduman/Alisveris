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
        [Display(Name="Ürün İsmi")]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        [Display(Name = "Marka")]
        public string Brand { get; set; }
        [Required]
        [Display(Name = "Model")]
        public string Model { get; set; }
        [Display(Name = "Görsel")]
        public string Image { get; set; }
        [Display(Name = "Ürün Açıklaması")]
        public string Description { get; set; }
        [Required]
        [Range(1, 999999999.99)]
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }
    }
}