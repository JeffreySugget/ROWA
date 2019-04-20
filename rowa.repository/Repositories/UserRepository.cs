using Microsoft.EntityFrameworkCore;
using rowa.repository.Entities;
using rowa.repository.Interfaces;
using System.Threading.Tasks;

namespace rowa.repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public async Task<bool> LogIn(string email, string password)
        {
            var user = await DatabaseContext.User.FirstOrDefaultAsync(x => string.Equals(x.Email, email) && string.Equals(x.Password, password));

            if (user == null)
            {
                return false;
            }

            return true;
        }
    }
}
