using System.Data.Entity;
namespace OnlineStoreMVC.Models
{
    public class EntityInitializator : DropCreateDatabaseIfModelChanges<EntityDbContext>
    {
        protected override void Seed(EntityDbContext context)
        {

        }

    }
}