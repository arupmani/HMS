using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMSWeb.DomainViewModel
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Token { get; set; }

        public string Email { get; set; }
    }
}
