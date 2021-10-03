using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Anladim.Models.EntityFramework
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactId { get; set; }
        [Display(Name = "Email adresiniz")]
        [Required(ErrorMessage = "Lutfen Email adresinizi giriniz")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Bos Birakilamaz")]
        [Display(Name = "Adınız")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bos Birakilamaz")]
        [Display(Name = "Konu")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Bos Birakilamaz")]
        [MinLength(20)]
        [Display(Name = "Mesaj")]
        public string Message { get; set; }
    }
}