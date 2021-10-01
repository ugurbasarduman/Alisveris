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
        [StringLength(70, MinimumLength = 2, ErrorMessage = "En az 2 karakter uzunlugunda olmali")]
        [Required(ErrorMessage = "Bos Birakilamaz")]
        public string Title { get; set; }
        [Display(Name = "Şehir")]
        [StringLength(70, MinimumLength = 2, ErrorMessage = "En az 2 karakter uzunlugunda olmali")]
        [Required(ErrorMessage = "Bos Birakilamaz")]
        public string City { get; set; }
        [Display(Name = "Adres")]
        [StringLength(700, MinimumLength = 2, ErrorMessage = "En az 2 karakter uzunlugunda olmali")]
        [Required(ErrorMessage = "Bos Birakilamaz")]
        public string Address { get; set; }
    }
}