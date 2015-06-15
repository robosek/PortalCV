using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace OnlineStoreMVC.Models.DataFactories
{
    public class CvDataFactory
    {
        private ApplicationDbContext appDb;
        private EntityDbContext db;
        private Random rand;

        private static Char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_".ToCharArray();
        private static int USERNAME_LENGTH = 8;
        private static String[] educationTypes = new String[] { "Liceum", "Technikum", "Szkoła Zawodowa", "Uniwersytet", "Politechnika" };
        private static String[] languages = new String[] { "Angielski", "Niemiecki", "Hiszpański", "Francuski", "Rosyjski", "Chiński", "Hebrajski", "Arabski" };
        private static String[] languageLevels = new String[] { "Beginner", "Pre-Intermidiate", "Intermidiate", "FCE" };
        private static String[] branches = new String[] { "Administracja", "Rachunkowość", "Mechanika", "Gastronomia", "Informatyka", "Zarządzanie" };
        public CvDataFactory(EntityDbContext context)
        {
            db = context;
            rand = new Random();
            appDb = new ApplicationDbContext();
        }
        //add records with cv data to custom db
        public void generateCvData(int numUsers)
        {
            //generate data for users created in app db
            List<ApplicationUser> userList = appDb.Users.ToList();
            foreach(ApplicationUser user in userList){
                string userName = user.UserName;
                db.Users.Add(new UserViewModel() { Nickname = userName, Created = getRandomDate(DateTime.Parse("2015/01/01"), DateTime.Parse("2015/06/01")).ToString() });
                db.Languages.Add(generateLanguage(userName));
                db.Educations.Add(generateEducation(userName));
                try
                {
                    db.SaveChanges();
                }
                catch (Exception)
                { }
            }
            //for (int i = 0; i < numUsers; i++)
            //{
            //    string userName = randomUserName();
            //    db.Users.Add(new UserViewModel() { UserID=i, Nickname = userName, Created = getRandomDate(DateTime.Parse("2015/01/01"), DateTime.Parse("2015/06/01")).ToString() });
            //    db.Languages.Add(generateLanguage(userName));
            //    db.Educations.Add(generateEducation(userName));
            //    try
            //    {
            //        db.SaveChanges();
            //    }
            //    catch (Exception)
            //    { }
            //}

        }
        private string randomUserName()
        {
            String name = "";
            for (int i = 0; i < USERNAME_LENGTH; i++) name += alphabet[rand.Next(alphabet.Length)];
            return name;
        }
        private string getRandomLanguage()
        {
            return languages[rand.Next(languages.Length)];
        }
        private string getRandomLanguageLevel()
        {
            return languageLevels[rand.Next(languageLevels.Length)];
        }
        private string getRandomEducationType()
        {
            return educationTypes[rand.Next(educationTypes.Length)];
        }
        private string getRandomSchoolName(string schoolType)
        {
            return String.Format("{0} {1}", rand.Next(10), schoolType);
        }
        private DateTime getRandomDate(DateTime from, DateTime to)
        {
            TimeSpan range = new TimeSpan(to.Ticks - from.Ticks);
            return from + new TimeSpan((long)(range.Ticks * rand.NextDouble()));
        }
        private Language generateLanguage(String username)
        {
            return new Language() { LanguageName = getRandomLanguage(), LanguageSpeakLevel = getRandomLanguageLevel(), UserName=username };
        }
        private Education generateEducation(String username)
        {
            DateTime startDate = getRandomDate(DateTime.Parse("1970/01/01"), DateTime.Parse("2015/01/01"));
            DateTime endDate = getRandomDate(startDate, DateTime.Parse("2015/06/30"));
            string schoolType = getRandomEducationType();
            return new Education() { TypeOfSchool = schoolType, StartDate = startDate.ToString(), EndDate = endDate.ToString(), SchollName = getRandomSchoolName(schoolType), UserName=username };
        }
    }
}