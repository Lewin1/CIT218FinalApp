using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CIT218FinalApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace CIT218FinalApp.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;

        #region Reviews

        public ActionResult ReviewIndex(string searchByName)
        {
            ViewBag.rollercoasters = db.rollercoasters.ToList();
            if (searchByName != null)
            {
                return View(db.reviews.Where(r => r.ReviewTitle.ToUpper().Contains(searchByName.ToUpper())));
            }
            return View(db.reviews.ToList());
        }
        
        public ActionResult ReviewDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.reviews.Find(id);
            ViewBag.RollercoasterName = db.rollercoasters.Where(r => r.Id == review.RollercoasterId).FirstOrDefault().Name;
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        public ActionResult ReviewCreateNoId()
        {
            ViewBag.rollercoasters = db.rollercoasters.ToList();
            return View();
        }

        public ActionResult ReviewCreate(int id)
        {
            ViewBag. rollercoaster = db.rollercoasters.Where(r => r.Id == id).First();
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReviewCreate([Bind(Include = "RollercoasterId,ReviewTitle,Content,Rating")] Review review)
        {
            if (review.ReviewTitle != null && review.ReviewTitle != null)
            {
                review.UserId = User.Identity.GetUserId();
                db.reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("RollercoasterIndex");
            }

            return View(review);
        }
        
        public ActionResult ReviewEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.reviews.Find(id);
            ViewBag.RollercoasterName = db.rollercoasters.Where(r => r.Id == review.RollercoasterId).First().Name;
            if(review.UserId != User.Identity.GetUserId())
            {
                return RedirectToAction("Index", "Home");
            }

            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReviewEdit([Bind(Include = "Id,UserId,RollercoasterId,ReviewTitle,Content,Rating")] Review review)
        {
            if (review.UserId != User.Identity.GetUserId())
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.RollercoasterName = db.rollercoasters.Where(r => r.Id == review.RollercoasterId).First().Name;
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ReviewsByUser", "User", new { id = review.UserId });
            }

            return View(review);
        }
        
        public ActionResult ReviewDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Review review = db.reviews.Find(id);

            if (review.UserId != User.Identity.GetUserId())
            {
                return RedirectToAction("Index", "Home");
            }

            if (review == null)
            {
                return HttpNotFound();
            }

            return View(review);
        }
        
        [HttpPost, ActionName("ReviewDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.reviews.Find(id);

            if (review.UserId != User.Identity.GetUserId())
            {
                return RedirectToAction("ViewProfile", "User");
            }

            db.reviews.Remove(review);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ReviewsByCoaster(int? id, string searchByName)
        {
            List<Review> reviews = db.reviews.Where(r => r.RollercoasterId == id).ToList();
            ViewBag.coasterName = "";

            if (searchByName != null)
            {
                if (db.reviews.Where(r => r.RollercoasterId == id).Count() != 0)
                {
                    ViewBag.coasterName = db.rollercoasters.Where(r => r.Id == id).First().Name;

                    return View(reviews.Where(r => r.ReviewTitle.ToUpper().Contains(searchByName.ToUpper())));
                }
            }

            if (db.reviews.Where(r => r.RollercoasterId == id).Count() != 0)
            {
                ViewBag.coasterName = db.rollercoasters.Where(r => r.Id == id).First().Name;
                return View(reviews);
            }

            return View();
        }

        #endregion

        #region User Profile

        [HttpGet]
        public ActionResult ViewProfile(string id)
        {
            if (User.Identity.GetUserId() == id)
            {
                if (id != null)
                {
                    UserViewModel uvm = AppUserToViewModel(db.Users.Where(u => u.Id == id).FirstOrDefault());

                    if (uvm != null)
                    {
                        return View(uvm);
                    }

                    return RedirectToAction("Index", "Home");
                }

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult EditProfile(string id)
        {
            if (User.Identity.GetUserId() == id)
            {
                if (id != null)
                    {
                        EditUserModel eum = new EditUserModel(db.Users.Where(u => u.Id == id).FirstOrDefault());

                        if (eum != null)
                    {
                        return View(eum);
                    }

                        return RedirectToAction("Index", "Home");
                    }

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult EditProfile ([Bind(Include = "UserName,Email,Role,Age,FirstName,LastName")] EditUserModel eum)
        {
            if (User.Identity.GetUserId() == db.Users.Where(u => u.UserName == eum.UserName).First().Id)
            {
                if (ModelState.IsValid)
                {
                    ApplicationUser appUser = db.Users.Where(u => u.UserName == eum.UserName).FirstOrDefault();
                    appUser.Email = eum.Email;
                    appUser.Age = eum.Age;
                    appUser.FirstName = eum.FirstName;
                    appUser.LastName = eum.LastName;

                    db.Entry(appUser).State = EntityState.Modified;
                    db.SaveChanges();
                
                    return RedirectToAction("ViewProfile", "User", new { id = appUser.Id });
                }

                return View(eum);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult ChangePassword (string id)
        {
            if (User.Identity.GetUserId() == id)
            {
                ApplicationUser appUser = db.Users.Where(u => u.Id == id).FirstOrDefault();
                return View(AppUserToViewModel(appUser));
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult ChangePassword (UserViewModel uvm)
        {
            if (User.Identity.GetUserId() == db.Users.Where(u => u.UserName == uvm.UserName).First().Id)
            {
                PasswordHasher ph = new PasswordHasher();
                ApplicationUser appUser = db.Users.Where(u => u.UserName == uvm.UserName).FirstOrDefault();

                appUser.Password = uvm.Password;
                appUser.PasswordHash = ph.HashPassword(appUser.Password);

                db.Entry(appUser).State = EntityState.Modified;
                db.SaveChanges();

                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ReviewsByUser (string id)
        {
            if (User.Identity.GetUserId() == id)
            {
                List<Review> reviews = db.reviews.Where(r => r.UserId == id).ToList();
                ViewBag.Rollercoasters = db.rollercoasters.ToList();

                return View(reviews);
            }

            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region View Rollercoasters
        public ActionResult RollercoasterIndex(string searchByName)
        {
            if (searchByName != null)
            {
                return View(db.rollercoasters.Where(r => r.Name.ToUpper().Contains(searchByName.ToUpper())));
            }

            return View(db.rollercoasters.ToList());
        }
        
        public ActionResult RollercoasterDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rollercoaster rollercoaster = db.rollercoasters.Find(id);
            if (rollercoaster == null)
            {
                return HttpNotFound();
            }
            return View(rollercoaster);
        }
        #endregion

        #region Helper Methods
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //UserViewModel to AppUser
        public ApplicationUser ViewModelToAppUser(UserViewModel UVM)
        {
            ApplicationUser appUser = new ApplicationUser();
            appUser.UserName = UVM.UserName;
            appUser.Email = UVM.Email;
            appUser.Password = UVM.Password;
            appUser.Age = UVM.Age;
            appUser.FirstName = UVM.FirstName;
            appUser.LastName = UVM.LastName;

            return appUser;
        }

        public ApplicationUser EditUserModelToAppUser(EditUserModel UVM)
        {
            ApplicationUser appUser = new ApplicationUser();
            appUser.UserName = UVM.UserName;
            appUser.Email = UVM.Email;
            appUser.Age = UVM.Age;
            appUser.FirstName = UVM.FirstName;
            appUser.LastName = UVM.LastName;

            return appUser;
        }

        //AppUser to UserViewModel
        public UserViewModel AppUserToViewModel(ApplicationUser AU)
        {
            UserViewModel uvm = new UserViewModel();
            uvm.UserName = AU.UserName;
            uvm.Email = AU.Email;
            uvm.Role = GetUserRoles(AU);
            uvm.Age = AU.Age;
            uvm.FirstName = AU.FirstName;
            uvm.LastName = AU.LastName;

            return uvm;
        }
        
        public string GetUserRoles(ApplicationUser AU)
        {
            string role = "";

            List<IdentityUserRole> userRole = AU.Roles.ToList();

            var allRoles = db.Roles.ToList();

            foreach (var dbRole in allRoles)
            {
                if (dbRole.Id == userRole[0].RoleId)
                {
                    role = (dbRole.Id);
                }
            }

            return role;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        #endregion
    }
}
