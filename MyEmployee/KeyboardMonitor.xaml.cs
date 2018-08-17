using System;
using System.Windows;
using MyEmployee.ServiceReference1;
namespace MyEmployee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            EventLogInterfaceClient api = new EventLogInterfaceClient();

            string employee = (string)name.Text;
            string Event = Eventtype.Text;
            DateTime eta = DateTime.Now;
            
            //Inefficient code

            //if (_15min.IsChecked == true)
            //{
                switch (Event)
                {
                    case "UnLock":
                        
                        api.Create(new Event() { UserName = employee, DateTime = DateTime.Now, EventType = EventTypeFlag.UnLock , StatusFlag = StatusFlag.At_desk});
                        break;
                    case "DefaultLock":
                        api.Create(new Event() { UserName = employee, DateTime = DateTime.Now, EventType = EventTypeFlag.DefaultLock , StatusFlag = StatusFlag.AwayExpectingReturn });
                        break;
                    case "Lock":
                        if (_15min.IsChecked == true)
                            api.Create(new Event() { UserName = employee, DateTime = DateTime.Now, ETA = eta.AddMinutes(15.0), EventType = EventTypeFlag.Lock });
                        if (_30min.IsChecked == true)
                            api.Create(new Event() { UserName = employee, DateTime = DateTime.Now, ETA = eta.AddMinutes(30.0), EventType = EventTypeFlag.Lock });
                        if (_1hour.IsChecked == true)
                            api.Create(new Event() { UserName = employee, DateTime = DateTime.Now, ETA = eta.AddMinutes(1.0), EventType = EventTypeFlag.Lock });
                        if (_2hour.IsChecked == true)
                          api.Create(new Event() { UserName = employee, DateTime = DateTime.Now, ETA = eta.AddMinutes(2.0), EventType = EventTypeFlag.Lock });
                        if (GoingHome.IsChecked == true)
                        { 
                            api.Create(new Event() { UserName = employee, ETA = DateTime.Now.AddDays(1), EventType = EventTypeFlag.Lock, StatusFlag = StatusFlag.Gone_Home });
                            MessageBox.Show("You are going home "+ "\n Goodbye");
                        break;
                        }
                    break;
                }


                MessageBox.Show("See you soon!");
            }
            //else if (_30min.IsChecked == true)
            //{
            //    switch (Event)
            //    {
            //        case "UnLock":

            //            api.Create(new Event() { UserName = employee, DateTime = DateTime.Now, EventType = EventTypeFlag.UnLock, StatusFlag = StatusFlag.At_desk });
            //            break;
            //        case "DefaultLock":
            //            api.Create(new Event() { UserName = employee, DateTime = DateTime.Now, EventType = EventTypeFlag.DefaultLock, StatusFlag = StatusFlag.AwayExpectingReturn });
            //            break;
            //        case "Lock":
            //            api.Create(new Event() { UserName = employee, DateTime = DateTime.Now, ETA = eta.AddMinutes(30.0), EventType = EventTypeFlag.Lock });
            //            break;
            //    }
            //    MessageBox.Show("Your ETA is 30 minutes, see you soon");
            //}
            //else if (_1hour.IsChecked == true)
            //{

            //    switch (Event)
            //    {
            //        case "UnLock":

            //            api.Create(new Event() { UserName = employee, DateTime = DateTime.Now, EventType = EventTypeFlag.UnLock, StatusFlag = StatusFlag.At_desk });
            //            break;
            //        case "DefaultLock":
            //            api.Create(new Event() { UserName = employee, DateTime = DateTime.Now, EventType = EventTypeFlag.DefaultLock, StatusFlag = StatusFlag.AwayExpectingReturn });
            //            break;
            //        case "Lock":
            //            api.Create(new Event() { UserName = employee, DateTime = DateTime.Now, ETA = eta.AddHours(1.0), EventType = EventTypeFlag.Lock });
            //            break;
            //    }
            //    MessageBox.Show("Your ETA is 1 hour, see you soon");
            //}
            //else if (_2hour.IsChecked == true)
            //{
            //    switch (Event)
            //    {
            //        case "UnLock":

            //            api.Create(new Event() { UserName = employee, DateTime = DateTime.Now, EventType = EventTypeFlag.UnLock, StatusFlag = StatusFlag.At_desk });
            //            break;
            //        case "DefaultLock":
            //            api.Create(new Event() { UserName = employee, DateTime = DateTime.Now, EventType = EventTypeFlag.DefaultLock, StatusFlag = StatusFlag.AwayExpectingReturn });
            //            break;
            //        case "Lock":
            //            api.Create(new Event() { UserName = employee, DateTime = DateTime.Now, ETA = eta.AddHours(2.0), EventType = EventTypeFlag.Lock });
            //            break;
            //    }
            //    MessageBox.Show("Your ETA is 2 hours, see you soon");
            //}
            //else if (GoingHome.IsChecked == true)
            //{
            //    api.Create(new Event() { UserName = employee, ETA = DateTime.Now.AddDays(1) , EventType = EventTypeFlag.Lock , StatusFlag = StatusFlag.Gone_Home});
                
            //    MessageBox.Show("You are going home "+ "\n Goodbye");
            //}
            //else
            //{
            //    MessageBox.Show("You must enter your ETA");
            //}
            
        //}
    }
}
