using OnlineStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace OnlineStoreMVC.Models
{
    public class EntityDbContext : DbContext
    {

        public DbSet<UserViewModel> Users { get; set; }

        public DbSet<Profession> Professions { get; set; }

        public DbSet<Experience> Experiences { get; set; }

        public DbSet<Education> Educations { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Certificate> Certificates{ get; set; }

        public DbSet<Language> Languages{ get; set; }

        public DbSet<Hobby> Hobbies { get; set; }

        public DbSet<CV> Cvs { get; set; }












    }
}