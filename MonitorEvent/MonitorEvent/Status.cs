using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventLog;
using System.Runtime.Serialization;

namespace EventLog
{
    public class StatusHandler
    { 

        //public string empl_ID;
        //SSID needs to be inserted
        
        public static void Save(Status status)//this is the save function. 
        {
            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                session.Store(status);
                session.SaveChanges();//saves the changes you make to an object
            }
        }

        public static Status[] LoadAll()//this is the loadall function that Alice would be using 
        {
            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                Status[] statuses = session.Query<Status>().ToArray();//to Array allows conversion to Array. Query method is used for specific searches
                return statuses;//returns the array of statuses
            }
        }
    }

    
}
