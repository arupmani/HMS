using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMSWeb.Repository
{
   public interface IUserRepository
    {
        bool IsUserExists(string userName, string password);
    }
}
