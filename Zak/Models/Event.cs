using Zak.EventLogReference;

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
       
        public string isRemoteSession { get; set; }
    }
}