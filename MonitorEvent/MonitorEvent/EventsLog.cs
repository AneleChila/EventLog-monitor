using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EventLog
{
    public class EventsLogHandler
    {
        public static void Save(EventsLog log)
        {
            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                session.Store(log);
                session.SaveChanges();
            }
        }

        public static EventsLog Retrieve(string Id)
        {
            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                //loads the contact id
                var eventslog = session.Load<EventsLog>(Id);

                if (eventslog == null)
                {
                    return null;
                }
                return eventslog;
            }
        }

        internal static EventsLog[] Load(string username, DateTime? startDate, DateTime? endDate)
        {
            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                EventsLog[] eventslog = session.Query<EventsLog>().Where(x => x.Name == username && x.DateTime >= startDate && x.DateTime <= endDate).ToArray();
                return eventslog;
            }
        }
    }
}
/*
 Consider what classes and fields are needed:
 
 
 */
