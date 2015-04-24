using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStoreMVC.Models;
using OnlineStoreMVC.Models.Bussiness;
using System.IO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PagedList;

namespace OnlineStoreMVC.Controllers
{
    public class UserController : Controller
    {
        private EntityDbContext db = new EntityDbContext();

        // GET: /User/
        [Authorize]
        public ActionResult _UserProfile()
        {
            return PartialView();
        }
    
        [Authorize(Roles = "Admin")]
        public ActionResult AddToAdmin(string userName)
        {

            using (var context = new ApplicationDbContext())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                if (!roleManager.RoleExists("Admin"))
                    roleManager.Create(new IdentityRole("Admin"));

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var user = userManager.FindByName(userName);
                if (user != null&& !userManager.IsInRole(user.Id,"Admin"))
                    userManager.AddToRole(user.Id, "Admin");

                context.SaveChanges();
                
            }
            
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteFromAdmin(string userName)
        {
            using (var context = new ApplicationDbContext())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                if (roleManager.RoleExists("Admin"))
                {
                    var userStore = new UserStore<ApplicationUser>(context);
                    var userManager = new UserManager<ApplicationUser>(userStore);

                    var user = userManager.FindByName(userName);
                    if (user != null && userManager.IsInRole(user.Id, "Admin"))
                        userManager.RemoveFromRole(user.Id, "Admin");

                    context.SaveChanges();
                }


                return RedirectToAction("Index");
            }
        }

        [Authorize]
        public ActionResult _AboutUser()
        {
            UserViewModel model;

            using (var context = new EntityDbContext())
            {
                model = context.Users.FirstOrDefault(u => u.Nickname == User.Identity.Name);

            }

            if (model == null) { model = new UserViewModel(); }

            ViewBag.FromPost = false;
            return PartialView(model);

        }

        [HttpPost]
        public ActionResult _AboutUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (EntityDbContext context = new EntityDbContext())
                {

                    var user = context.Users.FirstOrDefault(u => u.Nickname == User.Identity.Name);

                    if (user != null)
                    {
                        user.UserID = model.UserID;
                        user.Surname = model.Surname;
                        user.Secondname = model.Secondname;
                        user.Name = model.Name;
                        user.ImagePath = model.ImagePath;
                        user.Email = model.Email;
                        user.Address = model.Address;
                        user.CellNumber = model.CellNumber;
                        user.City = model.City;
                        user.Country = model.Country;
                        user.Nickname = model.Nickname;
                        user.PostalCode = model.PostalCode;
                        user.PhoneNumber = model.PhoneNumber;
                    }


                    try
                    {
                        context.SaveChanges();
                       
                        

                    }
                    catch(InvalidOperationException ex)
                    {
                        ModelState.AddModelError("", ex);
                        
                    }
                   
                }

                
            }
     
            ViewBag.FromPost = true;
            return PartialView(model);         
        }

        [Authorize(Roles="Admin")]
        public ActionResult Index(string query, int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            using (var dbApp = new ApplicationDbContext())
            {
                var userStore = new UserStore<ApplicationUser>(dbApp);
                var userManager = new UserManager<ApplicationUser>(userStore);

                foreach (var user in dbApp.Users)
                {

                    ViewData[user.UserName] = (userManager.IsInRole(user.Id, "Admin"));
                }
            }

            if (query == null)
            {
                var models = db.Users.OrderBy(x => x.UserID).ToList();


                return View(models.ToPagedList(pageNumber, pageSize));
            }


                List<UserViewModel> users;

                using (var context = new EntityDbContext())
                {
                    users = context.Users.Where(c => c.Nickname.Contains(query) ||c.Name.Contains(query) || c.Surname.Contains(query) || c.Address.Contains(query)).ToList();
                }

                return View(users.ToPagedList(pageNumber, pageSize));


        }


        // GET: /User/Create
        public ActionResult Create()
        {
            UserViewModel model;

            using(var context = new EntityDbContext())
            {
                model = context.Users.FirstOrDefault(u => u.Nickname == User.Identity.Name);

            }
           
            if(model == null){model = new UserViewModel();}

            return View("_UserProfile",model);
           
        }

        // POST: /User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Nickname,Name,Secondname,Surname,Email,Country,City,PostalCode,Address,PhoneNumber,CellNumber,ImagePath")] UserViewModel userviewmodel)
        {
            if (ModelState.IsValid)
            {
                using(EntityDbContext context = new EntityDbContext())
                {

                    var user = context.Users.Where(u => u.UserID == userviewmodel.UserID).FirstOrDefault();

                    if(user !=null)
                    {
                        context.Users.Remove(user);
                    }

                  
                    context.Users.Add(userviewmodel);
                    context.SaveChanges();
                }

               
            }

            return View("_UserProfile",userviewmodel);
        }


        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserViewModel userviewmodel = db.Users.Find(id);
            db.Users.Remove(userviewmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        [Authorize]
        public ActionResult _PhotoAsyncUpload()
        {
            var username = User.Identity.Name;


            if (!System.IO.File.Exists(Server.MapPath("/Content/Uploads/Users/min_" + username + ".jpg")))
            {
                ViewBag.ImageUrl = Url.Content("~/Content/Uploads/Users/unknown.png");
            }
            else
            {
                ViewBag.ImageUrl = Url.Content("~/Content/Uploads/Users/min_" + username + ".jpg");
            }

            return PartialView();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _PhotoAsyncUpload(Photo model)
        {

            if (ModelState.IsValid)
            {
                HttpPostedFileBase image = model.File;

                ViewBag.ImageUrl = Url.Content("~/Content/Uploads/Users/unknown.png");

                if (image != null)
                {
                    var username = User.Identity.Name;

                    string filePath = Server.MapPath("/Content/Uploads/Users");
                    string savedFileName = Path.Combine(filePath, username + ".jpg");

                    if (System.IO.File.Exists(savedFileName))
                    {
                        System.IO.File.Delete(savedFileName);

                        if (System.IO.File.Exists(Path.Combine(filePath, "min_" + username + ".jpg"))) { System.IO.File.Delete(Path.Combine(filePath, "min_" + username + ".jpg")); }

                    }

                    image.SaveAs(savedFileName);

                    PhotoFactory.Thumbnail(username + ".jpg", filePath, 250, 250, false);

                    ViewBag.ImageUrl = Url.Content("~/Content/Uploads/Users/min_" + username + ".jpg");


                }
                else
                {
                    ViewBag.ImageUrl = (System.IO.File.Exists(Server.MapPath("/Content/Uploads/Users/min_" + User.Identity.Name + ".jpg")))?
                        ViewBag.ImageUrl = Url.Content("/Content/Uploads/Users/min_" + User.Identity.Name + ".jpg") :
                        ViewBag.ImageUrl = Url.Content("~/Content/Uploads/Users/unknown.png");

                }

                return new JsonResult { Data = ViewBag.ImageUrl };
            }

            return PartialView();

        }

        [HttpPost]
        [Authorize]
        public ActionResult DeletePhoto(string username)
        {
            if(System.IO.File.Exists(Server.MapPath("~/Content/Uploads/Users/"+username+".jpg")))
            {
                System.IO.File.Delete(Server.MapPath("~/Content/Uploads/Users/" + username + ".jpg"));

                if (System.IO.File.Exists(Server.MapPath("~/Content/Uploads/Users/min_" + username + ".jpg"))) { System.IO.File.Delete(Server.MapPath("~/Content/Uploads/Users/min_" + username + ".jpg")); }
            }

            return PartialView("_PhotoPath");

        }


    }
}



 