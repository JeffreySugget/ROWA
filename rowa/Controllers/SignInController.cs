using rowa.Models;
using rowa.repository.Classes;
using rowa.repository.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace rowa.Controllers
{
    public class SignInController : Controller
    {
        private IUserRepository _userRepository;
        private IUserHelper _userHelper;

        public SignInController(IUserRepository userRepository, IUserHelper userHelper)
        {
            _userRepository = userRepository;
            _userHelper = userHelper;
        }

        // GET: SignIn
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LogIn(SignInModel model)
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
    }
}