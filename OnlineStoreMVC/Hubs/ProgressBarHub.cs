using OnlineStoreMVC.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStoreMVC.Hubs
{
    public class ProgressBarHub : Hub
    {

        public void SendProgress(int dataPercent)
        {
            for (int i = 0; i <= (dataPercent* 10); i++)
            {
                Clients.Caller.sendMessage(i + "%");
            }

        }


    }
}


            










