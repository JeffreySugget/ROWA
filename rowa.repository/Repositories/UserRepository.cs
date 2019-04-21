using Microsoft.EntityFrameworkCore;
using rowa.repository.Entities;
using rowa.repository.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

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

            var authTicket = new FormsAuthenticationTicket(1, email, DateTime.Now, DateTime.Now.AddMinutes(30), true, "");

            var cookieContents = FormsAuthentication.Encrypt(authTicket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieContents)
            {
                Expires = authTicket.Expiration,
                Path = FormsAuthentication.FormsCookiePath
            };

            if (HttpContext.Current != null)
            {
                HttpContext.Current.Response.Cookies.Add(cookie);
            }

            return true;
        }
    }
}
