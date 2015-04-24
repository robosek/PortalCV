using System.Collections.Generic;


namespace OnlineStoreMVC.Models
{
    public class CvModel
    {
        public Profession Profession { get; set; }

        public List<Experience> Experiences { get; set; }

        public List<Education> Educations { get; set; }

        public List<Skill> Skills { get; set; }

        public List<Certificate> Certificates{ get; set; }

        public List<Language> Languages{ get; set; }

        public Hobby Hobby { get; set; }



    }
}