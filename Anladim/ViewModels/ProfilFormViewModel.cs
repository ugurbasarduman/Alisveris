using Anladim.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anladim.ViewModels
{
    public class ProfilFormViewModel
    {
        public ProfilFormViewModel(User user, IEnumerable<UserAddress> userAddress)
        {
            this.user = user;
            this.userAddress = userAddress;
        }

        public User user { get; set; }
        public IEnumerable<UserAddress> userAddress { get; set; }
    }
    
}