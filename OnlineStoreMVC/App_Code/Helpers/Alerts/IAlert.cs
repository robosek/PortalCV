using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreMVC.App_Code.Helpers
{
    public interface IAlert:IAlertFluent
    {

        IAlertFluent Danger();
        IAlertFluent Info();
        IAlertFluent Success();
        IAlertFluent Warning();


    }
}
