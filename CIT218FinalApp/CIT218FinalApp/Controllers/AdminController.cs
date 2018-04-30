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

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager _userManager;

        public ActionResult AdminLanding()
        {
            return View();
        }

        #region Manage Rollercoasters
        public ActionResult RollercoasterIndex(string rollercoasterName)
        {
            if (rollercoasterName != null)
            {
                return View(db.rollercoasters.Where(r => r.Name.ToUpper().Contains(rollercoasterName.ToUpper())));
            }
            return View(db.rollercoasters.ToList());
        }
        
        public ActionResult RollercoasterDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rollercoaster rc = db.rollercoasters.Find(id);
            if (rc == null)
            {
                return HttpNotFound();
            }
            return View(rc);
        }
        
        public ActionResult RollercoasterCreate()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RollercoasterCreate([Bind(Include = "Id,Name,Description,Height,Speed,Location")] Rollercoaster rc)
        {
            if (ModelState.IsValid)
            {
                db.rollercoasters.Add(rc);
                db.SaveChanges();
                return RedirectToAction("RollercoasterIndex");
            }

            return View(rc);
        }
        
        public ActionResult RollercoasterEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rollercoaster rc = db.rollercoasters.Find(id);
            if (rc == null)
            {
                return HttpNotFound();
            }
            return View(rc);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RollercoasterEdit([Bind(Include = "Id,Name,Description,Height,Speed,Location")] Rollercoaster rc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("RollercoasterIndex");
            }
            return View(rc);
        }
        
        public ActionResult RollercoasterDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rollercoaster rc = db.rollercoasters.Find(id);
            if (rc == null)
            {
                return HttpNotFound();
            }
            return View(rc);
        }
        
        [HttpPost, ActionName("RollercoasterDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult RollercoasterDeleteConfirmed(int id)
        {
            Rollercoaster rc = db.rollercoasters.Find(id);
            db.rollercoasters.Remove(rc);
            db.SaveChanges();
            return RedirectToAction("RollercoasterIndex");
        }

        #endregion

        #region Manage Reviews
        
        public ActionResult ReviewIndex(string searchByName)
        {
            List<Rollercoaster> rollercoasters = db.rollercoasters.ToList();
            List<Review> reviews = db.reviews.ToList();
            ViewBag.rollercoasters = rollercoasters;


            if (searchByName != null)
            {
                return View(reviews.Where(r => r.ReviewTitle.ToUpper().Contains(searchByName.ToUpper())));
            }

            return View(reviews);
        }
        
        public ActionResult ReviewDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }
        
        public ActionResult ReviewCreate()
        {
            ViewBag.rollercoasters =  db.rollercoasters.ToList();
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReviewCreate([Bind(Include = "Id,RollercoasterId,ReviewTitle,Content,Rating")] Review review)
        {
            ViewBag.rollercoasters = db.rollercoasters.ToList();
            if (ModelState.IsValid)
            {
                review.UserId = User.Identity.GetUserId();
                db.reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("ReviewIndex");
            }

            return View(review);
        }
        
        public ActionResult ReviewEdit(int? id)
        {
            ViewBag.rollercoasters = db.rollercoasters.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReviewEdit([Bind(Include = "Id,RollercoasterId,ReviewTitle,Content,Rating")] Review review)
        {
            ViewBag.rollercoasters = db.rollercoasters.ToList();
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ReviewIndex");
            }
            return View(review);
        }
        
        public ActionResult ReviewDelete(int? id)
        {
            ViewBag.rollercoasters = db.rollercoasters.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }
        
        [HttpPost, ActionName("ReviewDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ReviewDeleteConfirmed(int id)
        {
            Review review = db.reviews.Find(id);
            db.reviews.Remove(review);
            db.SaveChanges();
            return RedirectToAction("ReviewIndex");
        }

        public ActionResult ReviewsByCoaster(int id, string searchByName)
        {
            ViewBag.coasterName = "";
            ViewBag.coasterName = db.rollercoasters.Where(r => r.Id == id).First().Name;
            List<Review> reviews = db.reviews.Where(r => r.RollercoasterId == id).ToList();

            if (searchByName != null)
            {
                return View(reviews.Where(r => r.ReviewTitle.ToUpper().Contains(searchByName.ToUpper())));
            }
            if (db.reviews.Where(r => r.RollercoasterId == id).Count() != 0)
            {
                return View(reviews);
            }

            return View();
        }
        #endregion

        #region Manage Users

        
        public ActionResult UserIndex(string searchByName)
        {
            List<ApplicationUser> Users = db.Users.ToList();
            if(searchByName != null)
            {
                Users = db.Users.Where(r => r.UserName.ToUpper().Contains(searchByName.ToUpper())).ToList();
                return View(UserListToViewModelList(Users));
            }
            
            return View(UserListToViewModelList(Users));
        }

        
        public ActionResult UserDetails(string userName)
        {
            if (userName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ApplicationUser appUser = db.Users.First(au => au.UserName == userName);
            
            UserViewModel userViewModel = AppUserToViewModel(appUser);

            List<IdentityRole> allRoles = db.Roles.ToList();
            List<string> viewBagRoles = new List<string>();

            foreach (var dbRole in allRoles)
            {
                if (dbRole.Id == userViewModel.Role)
                {
                    viewBagRoles.Add(dbRole.Name);
                }
            }

            ViewBag.Roles = viewBagRoles;

            if (appUser == null)
            {
                return HttpNotFound();
            }
            
            return View(userViewModel);
        }

        
        public ActionResult UserCreate()
        {
            List<IdentityRole> roles = db.Roles.ToList();
            ViewBag.Roles = roles;
            
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserCreate([Bind(Include = "UserName,Email,Role,Password,ConfirmPassword")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                PasswordHasher ph = new PasswordHasher();
                ApplicationUser appUser = ViewModelToAppUser(userViewModel);
                appUser.SecurityStamp = Guid.NewGuid().ToString();
                appUser.PasswordHash = ph.HashPassword(appUser.Password);

                db.Users.Add(appUser);
                db.SaveChanges();

                UserManager.AddToRole(appUser.Id, userViewModel.Role);
                db.SaveChanges();
                return RedirectToAction("UserIndex");
            }

            return View(userViewModel);
        }

        
        public ActionResult UserEdit(string userName)
        {
            List<IdentityRole> roles = db.Roles.ToList();
            ViewBag.Roles = roles;

            if (userName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ApplicationUser appUser = db.Users.First(au => au.UserName == userName);

            if (appUser == null)
            {
                return HttpNotFound();
            }

            return View(AppUserToViewModel(appUser));
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserEdit([Bind(Include = "UserName,Email,Role,Password,ConfirmPassword")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                PasswordHasher ph = new PasswordHasher();
                ApplicationUser oldAppUser = db.Users.First(u => u.UserName == userViewModel.UserName);
                ApplicationUser appUser = ViewModelToAppUser(userViewModel);
                appUser.Id = oldAppUser.Id;
                appUser.SecurityStamp = Guid.NewGuid().ToString();
                appUser.PasswordHash = ph.HashPassword(appUser.Password);

                db.Users.Remove(oldAppUser);
                db.SaveChanges();

                db.Users.Add(appUser);
                db.SaveChanges();
                UserManager.AddToRole(appUser.Id, userViewModel.Role);

                return RedirectToAction("UserIndex");
            }
            return View(userViewModel);
        }

        
        public ActionResult UserDelete(string userName)
        {
            if (userName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ApplicationUser appUser = db.Users.FirstOrDefault(u => u.UserName == userName);
            UserViewModel UVM = AppUserToViewModel(appUser);

            string roleID = GetUserRoles(appUser);

            UVM.Role = db.Roles.Where(r => r.Id == roleID).FirstOrDefault().Name;

            if (appUser == null)
            {
                return HttpNotFound();
            }

            return View(UVM);
        }

        
        [HttpPost, ActionName("UserDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult UserDeleteConfirmed(string userName)
        {
            ApplicationUser appUser = db.Users.FirstOrDefault(u => u.UserName == userName);
            db.Users.Remove(appUser);
            db.SaveChanges();
            return RedirectToAction("UserIndex");
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
        
        //ApplicationUser list to UserViewModel List
        public List<UserViewModel> UserListToViewModelList (List<ApplicationUser> Users)
        {
            List<UserViewModel> UsersViewModel = new List<UserViewModel>();

            foreach (ApplicationUser u in Users)
            {
                UserViewModel UVM = new UserViewModel(u);
                string roleID = GetUserRoles(u);

                UVM.Role = db.Roles.Where(r => r.Id == roleID).FirstOrDefault().Name;
                
                UsersViewModel.Add(UVM);
            }

            return UsersViewModel;
        }

        //UserViewModel to AppUser
        public ApplicationUser ViewModelToAppUser (UserViewModel UVM)
        {
            ApplicationUser appUser = new ApplicationUser();
            appUser.UserName = UVM.UserName;
            appUser.Email = UVM.Email;
            appUser.Password = UVM.Password;

            return appUser;
        }

        //AppUser to UserViewModel
        public UserViewModel AppUserToViewModel(ApplicationUser AU)
        {
            UserViewModel uvm = new UserViewModel();
            uvm.UserName = AU.UserName;
            uvm.Email = AU.Email;
            uvm.Role = GetUserRoles(AU);

            return uvm;
        }

        public string GetUserRoles (ApplicationUser AU)
        {
            string role = "";

            List<IdentityUserRole> userRole = AU.Roles.ToList();

            var allRoles = db.Roles.ToList();
            
                foreach (var dbRole in allRoles)
                {
                    if(dbRole.Id == userRole[0].RoleId)
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
