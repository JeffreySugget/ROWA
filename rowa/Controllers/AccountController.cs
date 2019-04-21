using rowa.Models;
using rowa.repository.Classes;
using rowa.repository.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace rowa.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository _userRepository;
        private IUserHelper _userHelper;

        public AccountController(IUserRepository userRepository, IUserHelper userHelper)
        {
            _userRepository = userRepository;
            _userHelper = userHelper;
        }

        // GET: SignIn
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LogIn(AccountModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var userHasAuthenticated = await _userRepository.AuthenticateUser(model.Email, _userHelper.EncryptPassword(model.Password));

            if (userHasAuthenticated)
            {
                _userHelper.LogIn(model.Email);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = "User name or password incorrect";

            return View("Index", model);
        }

        public ActionResult LogOut()
        {
            _userHelper.LogOut();

            return View();
        }
    }
}