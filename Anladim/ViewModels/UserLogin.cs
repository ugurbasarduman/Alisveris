using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Anladim.ViewModels
{
    public class UserLogin
    {
        [Required(AllowEmptyStrings =false)]
        public string Mail { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}