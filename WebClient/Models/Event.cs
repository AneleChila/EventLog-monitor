using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zak.EventLogR;

namespace Zak.Models
{
    public class Event
    {
        
        public string Id { get; set; }
       
        public string Name { get; set; }
        
        public string DateTime { get; set; }
       
        public string ETA { get; set; }
        
        public StatusFlag Status { get; set; }
       
        public EventTypeFlag EventType { get; set; }
       
        public bool isRemoteSession { get; set; }
    }
}