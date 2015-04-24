using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SqlServer.Server;

namespace OnlineStoreMVC.Models
{
    public class CV
    {
        public int CVId { get; set; }

        public String UserName { get; set; }

        public bool hasCV { get; set; }

    }
}