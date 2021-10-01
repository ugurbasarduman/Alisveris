using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Anladim.Models.EntityFramework
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Display(Name = "Isminiz")]
        [Required(ErrorMessage = "Bos Birakilamaz")]
        [StringLength(70, MinimumLength = 2, ErrorMessage = "En az 2 karakter uzunlugunda olmali")]
        public string Name { get; set; }
        [Display(Name = "Soy Adınız")]
        [Required(ErrorMessage ="Bos Birakilamaz")]
        [StringLength(70, MinimumLength = 2, ErrorMessage = "En az 2 karakter uzunlugunda olmali")]
        public string Surname { get; set; }
        [Display(Name = "Email adresiniz")]
        [Required(ErrorMessage = "Lutfen Email adresinizi giriniz")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Mail { get; set; }
        [Display(Name="Telefon Numarasi")]
        [Required(ErrorMessage = "Telefon Numarasi zorunludur")]
        [StringLength(13, MinimumLength = 10, ErrorMessage = "Geçersiz numara")]
        public string Phone { get; set; }
        [Display(Name = "Şifreniz")]
        [Required(ErrorMessage = "Sifre giriniz")]
        [StringLength(70, MinimumLength = 6, ErrorMessage = "En az 6 karakter uzunlugunda olmali")]
        public string Password { get; set; }
        public virtual IEnumerable<UserAddress> UserAddresses { get; set; }
        public string Role { get; set; }  ="U";
    }
}