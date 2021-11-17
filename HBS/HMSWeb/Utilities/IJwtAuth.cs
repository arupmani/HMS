using HMSDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMSWeb.Utilities
{
    public interface IJwtAuth
    {
        string Authentication(string userName, string password, IUserRepository userRepository);
    }
}
