using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventLog;

namespace EventLog
{
    public class EventLogAPI : EventLogInterface//this is the interface class
    {
        public void Create(Event message)//calls the create method
        {
            EventLog.EventsLog eventlog = new EventsLog() { Name = message.UserName, DateTime = message.DateTime, ETA = message.ETA, EventType = message.EventType, Status = message.StatusFlag, isRemoteSession = false };
            //abov ecreate s a new EventsLog with the sepcified fields
            EventLog.Status statusLog = new Status(message.UserName, message.UserName) { ETA = message.ETA, StatusFlag = message.StatusFlag };
            //above upadates the status of an employee
            EventsLogHandler.Save(eventlog);//this saves the eventlog
            StatusHandler.Save(statusLog);//this saves the status
        }

        public Status[] GetStatus()//this function gets the status of the employees
        {
            Status[] allStatuses = StatusHandler.LoadAll();//this uses the load all method to get the statuses
            int i = 0;
            String[] arr = new String[0];

            foreach(Status myst in allStatuses)
            {
                Array.Resize(ref arr, arr.Length + 1);
                arr[i] = myst.Name;
                i++;
            }

            Array.Sort(arr);
            Status[] st = new Status[50];

            foreach (Status anotherSt in allStatuses)
            {
                int indexOfstatus = Array.IndexOf(arr, anotherSt.Name);
                st[indexOfstatus] = anotherSt;
            }

            //allStatuses = st;



            foreach (Status s in st)// for each status in all statuses
            {
                if (s != null)
                {
                    if (s.StatusFlag == StatusFlag.AwayExpectingReturn)//are we expecting the employee to return 
                    {
                        TimeSpan elapsedTime = (DateTime.Now - s.ETA);//this checks an elapsed time
                        if (DateTime.Now.Hour > 16.0 && elapsedTime.Hours > 1.0)//this checks if later than 4 and if elapsed time is greater than 1 hour
                        {
                            s.StatusFlag = StatusFlag.Gone_Home;//if so he's gone home
                        }
                        if (DateTime.Now.Hour < 16 && elapsedTime.Hours > 0)//checks if earlier than 4 o clock and if elapsed time is greater than 0
                        {
                            s.StatusFlag = StatusFlag.AwayLongerThanExpected;//away longer than expected
                        }

                        StatusHandler.Save(s);//saves these statuses
                    }
                }
            }

            return st;//returns an array of the statuses
        }

        public EventsLog[] GetHistory(string username, DateTime? startDate, DateTime? endDate)//this is the function used by zak
        {
            EventsLog[] logs = EventsLogHandler.Load(username, startDate, endDate);//creates an array of the eventlogs
            return logs;//returns that array
        }
    }
}
