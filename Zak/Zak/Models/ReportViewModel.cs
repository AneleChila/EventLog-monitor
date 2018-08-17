using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zak.Models
{
    public class ReportViewModel
    {
        public string name { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set;  }
    }
}