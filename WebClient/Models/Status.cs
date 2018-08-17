using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClient.EventLogR;

namespace WebClient.Models
{
    public class Status
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ETA { get; set; }
        public string StatusFlag { get; set; }
    }
}