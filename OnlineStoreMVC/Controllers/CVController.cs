using System;
using System.Linq;
using System.Web.Mvc;
using OnlineStoreMVC.Models;
using System.Globalization;
using System.Collections.Generic;
using PagedList;

namespace OnlineStoreMVC.Controllers
{
    public class CVController : Controller
    {

        [NonAction]
        public bool HasCv(string userName)
        {
            bool hasCv;
            using (var db = new EntityDbContext())
            {
                hasCv = db.Cvs.Any(x => x.UserName == User.Identity.Name);
            }


            return hasCv;
        }

        [Authorize]
        public ActionResult AddYourCV()
        {
            if (HasCv(User.Identity.Name))
                return RedirectToAction("EditCv");
            return View();
        }

        [HttpPost]
        public ActionResult AddYourCV(CvModel model)
        {
            if (model.Skills.Last().SkillName == null || model.Skills.Last().SkillDescription==null)
            {
               

                return Content("Error Nie podano umiejętności");

            }
            if (model.Hobby == null)
            {
                return Content("Error Nie podano swoich hobby");

            }
            if (model.Profession == null)
            {
                return Content("Error Nie podano swojego zawodu");
            }
            if (model.Experiences.Count == 1 &&
                (model.Experiences.Last().JobStartTime != null ||  model.Experiences.Last().JobEndTime !=null))
            {

                foreach (var exp in model.Experiences)
                {
                    DateTime dataFrom = new DateTime();
                    DateTime dataTo = new DateTime();

                    DateTime.TryParse(exp.JobStartTime+" 00:00:00",new CultureInfo("pl-PL"),DateTimeStyles.AssumeUniversal, out dataFrom);
                    DateTime.TryParse(exp.JobEndTime + " 00:00:00", new CultureInfo("pl-PL"), DateTimeStyles.AssumeUniversal, out dataTo);


                    if (dataFrom.ToShortDateString() == "0001-01-01" || dataTo.ToShortDateString() == "0001-01-01") { return Content("Error Podano niepoprawne daty");}
                    
                }

                
            }
            if (model.Educations.Count == 1 &&
               (model.Educations.Last().StartDate != null || model.Educations.Last().EndDate != null))
            {

                foreach (var edu in model.Educations)
                {
                    DateTime dataFrom = new DateTime();
                    DateTime dataTo = new DateTime();

                    DateTime.TryParse(edu.StartDate + " 00:00:00", new CultureInfo("pl-PL"), DateTimeStyles.AssumeUniversal, out dataFrom);
                    DateTime.TryParse(edu.EndDate + " 00:00:00", new CultureInfo("pl-PL"), DateTimeStyles.AssumeUniversal, out dataTo);


                    if (dataFrom.ToShortDateString() == "0001-01-01" || dataTo.ToShortDateString() == "0001-01-01") { return Content("Error Podano niepoprawne daty"); }

                }


            }


            using (EntityDbContext db = new EntityDbContext())
            {

                foreach (var item in model.Experiences)
                {
                    if (item.JobStartTime != null || item.JobEndTime != null)
                    {
                        db.Experiences.Add(item);

                       
                    }
                    
                }

                foreach (var item in model.Skills)
                {
                    db.Skills.Add(item);

                   
                }

                foreach (var item in model.Certificates)
                {
                    if (item.CertificateDesc != null || item.CertificateName != null)
                    {
                        db.Certificates.Add(item);

                     
                    }
                    
                }
                foreach (var item in model.Languages)
                {
                    if (item.LanguageName != null )
                    {
                        db.Languages.Add(item);

                        
                    }
                }
                foreach (var item in model.Educations)
                {
                    if (item.SchollName != null)
                    {
                        db.Educations.Add(item);


                    }
                }


                
                db.Hobbies.Add(model.Hobby);
                db.Professions.Add(model.Profession);
                db.Cvs.Add(new CV() {UserName = User.Identity.Name, hasCV = true});


                try
                {
                    db.SaveChanges();

                }

                catch (Exception)
                {   
                    return Content("Error Błąd walidacji danych. Upewnij się czy wpisane teksty nie są zbyt długie.") ;
                }
                    
                
            }

            return Content("Dane zostały zapisane poprawnie");
        }

        [Authorize]
        public ActionResult EditCv()
        {
            if (!HasCv(User.Identity.Name))
                return RedirectToAction("AddYourCV");

            var db = new EntityDbContext();

            var userName = User.Identity.Name;

            //First Model
            var exp = db.Experiences.Where(x => x.UserName == userName).ToList();
            var hob = db.Hobbies.FirstOrDefault(x => x.UserName == userName) ?? new Hobby() { HobbyDesc = " " };
            var cert = db.Certificates.Where(x => x.UserName == userName).ToList();
            var lang = db.Languages.Where(x => x.UserName == userName).ToList();
            var skill = db.Skills.Where(x => x.UserName == userName).ToList();
            var prof = db.Professions.FirstOrDefault(x => x.UserName == userName) ?? new Profession() { ProfessionName = " " };
            var edus = db.Educations.Where(x => x.UserName == userName).ToList();
         
                      

            CvModel cvModel = new CvModel()
            {
                Experiences =  exp,
                Certificates = cert,
                Languages=lang,
                Skills = skill,
                Hobby = hob,
                Profession = prof,
                Educations = edus

            };
            //Second Model
            var user = db.Users.FirstOrDefault(x => x.Nickname == userName);

            db.Dispose();

            if (user == null)
            {
                ViewBag.UserIsEmpty = true;
                return View();
            }
            
            var tuple = new Tuple<CvModel,UserViewModel>(cvModel,user);

            return View(tuple);
        }

        [HttpPost]
        public ActionResult DeleteCv(string userName)
        {
            if (userName != null)
            {
                using (EntityDbContext db = new EntityDbContext())
                {
                    db.Database.ExecuteSqlCommand("Delete from Experiences where UserName='" + userName+"'");
                    db.Database.ExecuteSqlCommand("Delete from Hobbies where UserName='" + userName+"'");
                    db.Database.ExecuteSqlCommand("Delete from Certificates where UserName='" + userName+"'");
                    db.Database.ExecuteSqlCommand("Delete from Languages where UserName='" + userName+"'");
                    db.Database.ExecuteSqlCommand("Delete from Skills where UserName='" + userName+"'");
                    db.Database.ExecuteSqlCommand("Delete from Cvs where UserName='" + userName+"'");
                    db.Database.ExecuteSqlCommand("Delete from Professions where UserName='" + userName + "'");
                    db.Database.ExecuteSqlCommand("Delete from Educations where UserName='" + userName + "'");
                    db.SaveChanges();

                }

                return RedirectToAction("AddYourCV");
            }


            return RedirectToAction("EditCv");

        }

        public ActionResult _Experiences()
        {
          
            return PartialView();

        }



        [HttpPost]
        public ActionResult AddExperience(CvModel model)
        {

            return PartialView("_Experiences");
        }
            


        [Authorize]
        public ActionResult _Skills()
        {
            return PartialView();
        }

        [Authorize]
        public ActionResult _Certifications()
        {

            return PartialView();
        }
        [Authorize]
        public ActionResult _Languages()
        {

            return PartialView();
        }

       
        [Authorize]
        public ActionResult _Hobby()
        {
            return PartialView();
        }

        [Authorize]
        public ActionResult _Profession()
        {
            return PartialView();
        }

        [Authorize]
        public ActionResult _Education()
        {
            return PartialView();
        }
        [Authorize]
        public ActionResult AddBranch(FormCollection collection)
        {
            EntityDbContext db = new EntityDbContext();
            var user = db.Users.First(x => x.Nickname == User.Identity.Name);
            user.Branch = collection["Branch"];
            //user.Branch = "Admin";
            db.SaveChanges();
            return RedirectToAction("EditCv");
        }

        //Branch specified as ID to use existing routing (CV/Browse/Informatyka)
        public ActionResult Browse(string ID, int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            EntityDbContext db = new EntityDbContext();
            List<UserViewModel> users;

            if (ID == null)
            {
                users = db.Users.OrderBy(x => x.UserID).ToList();
            }
            else
            {
                users = db.Users.Where(x => x.Branch == ID).OrderBy(x => x.UserID).ToList();
            }
            ViewData["branch"] = ID;
            return View(users.ToPagedList(pageNumber, pageSize));

        }

	}
}