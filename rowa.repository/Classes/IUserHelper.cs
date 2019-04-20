using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rowa.repository.Classes
{
    public interface IUserHelper
    {
        string EncryptPassword(string password);
    }
}
