using System.Web.Mvc;
using TestTaskWebApplication.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TestTaskWebApplication.DAL.Entities;
using System.Linq;

namespace TestTaskWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private IdentityDbContext<User> ApplicationDbContext;

        public HomeController(IdentityDbContext<User> applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("HomePage");
            }

            return View();
        }

        [Authorize]
        public ActionResult HomePage()
        {
            string userId = User.Identity.GetUserId();
            User user = ApplicationDbContext.Users.FirstOrDefault(s => s.Id == userId);

            HomeViewModel vm = new HomeViewModel()
            {
                Name = user.Name,
                LastName = user.LastName
            };

            return View(vm);
        }
    }
}