using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rowa.repository.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> AuthenticateUser(string email, string password);
    }
}
