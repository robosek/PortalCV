using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OnlineStoreMVC.App_Code.Helpers
{
    public interface IAlertFluent: IHtmlString
    {
        IAlertFluent Dismissible(bool canDismiss=true);

    }
}
