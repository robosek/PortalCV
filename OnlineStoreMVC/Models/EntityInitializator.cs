using OnlineStoreMVC.Models.DataFactories;
using System.Data.Entity;

namespace OnlineStoreMVC.Models
{
    //DropCreateDatabaseAlways for tests, DropCreateDatabaseIfModelChanges
    public class EntityInitializator : DropCreateDatabaseAlways<EntityDbContext>
    {
        protected override void Seed(EntityDbContext context)
        {
            //Generate fake data for statistics controller tests          
            context.Database.Delete();
            context.Database.Create();
            CvDataFactory cvDataFactory = new CvDataFactory(context);
            cvDataFactory.generateCvData(10);
        }

    }
}