using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Anladim.Models.EntityFramework
{
    public class UserAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserAddressId { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        [Display(Name = "Başlık")]
        [Required]
        public string Title { get; set; }
        [Display(Name = "Şehir")]
        [Required]
        public string City { get; set; }
        [Display(Name = "Adres")]
        [Required]
        public string Address { get; set; }
    }
}