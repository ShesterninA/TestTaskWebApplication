using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using TestTaskWebApplication.DAL.Entities;
using TestTaskWebApplication.Models;
using TestTaskWebApplication.ViewModels;

namespace TestTaskWebApplication.Controllers
{
    [Authorize]
    public class ManageController : BaseController
    {
        private IdentityDbContext<User> ApplicationDbContext;

        public ManageController(IdentityDbContext<User> applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, IdentityDbContext<User> applicationDbContext) : base(userManager, signInManager) { }

        //
        // GET: /Manage/Index
        public ActionResult Index(string message)
        {
            ViewBag.StatusMessage = message;
            return View();
        }

        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = "Пароль изменён" });
            }
            else {
                ModelState.AddModelError("", "Неверный старый пароль");
            }
            
            return View(model);
        }

        //
        // GET: /Manage/ChangeName
        public ActionResult ChangeName()
        {
            string userId = User.Identity.GetUserId();
            User user = UserManager.Users.FirstOrDefault(s => s.Id == userId);

            ChangeNameViewModel vm = new ChangeNameViewModel()
            {
                CurrentName = user.Name
            };

            return View(vm);
        }

        //
        // POST: /Manage/ChangeName
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeName(ChangeNameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = User.Identity.GetUserId();
            User user = UserManager.Users.FirstOrDefault(s => s.Id == userId);
            user.Name = model.Name;

            try
            {
                var result = UserManager.Update(user);
                ApplicationDbContext.SaveChanges();

                return RedirectToAction("Index", new { Message = "Имя изменено" });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
            }

            return View(model);
        }

        //
        // GET: /Manage/ChangeName
        public ActionResult ChangeLastName()
        {
            string userId = User.Identity.GetUserId();
            User user = UserManager.Users.FirstOrDefault(s => s.Id == userId);

            ChangeLastNameViewModel vm = new ChangeLastNameViewModel()
            {
                CurrentLastName = user.LastName
            };

            return View(vm);
        }

        //
        // POST: /Manage/ChangeLastName
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeLastName(ChangeLastNameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = User.Identity.GetUserId();
            User user = UserManager.Users.FirstOrDefault(s => s.Id == userId);
            user.LastName = model.LastName;

            try
            {
                var result = UserManager.Update(user);
                ApplicationDbContext.SaveChanges();

                return RedirectToAction("Index", new { Message = "Фамилия изменена" });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
            }

            return View(model);
        }
    }
}