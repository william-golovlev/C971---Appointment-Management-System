using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appointment_Management_System
{
    public partial class AppointmentForm : Form
    {
        private int getDay(int selectedDay)
        {
            DateTime currDate = DateTime.Now;
            DayOfWeek currentDayOfWeek = DateTime.Now.DayOfWeek;
            int today = currDate.Day;
            int desiredDay = today;
            if ((DayOfWeek)selectedDay > currentDayOfWeek)
            {
                desiredDay += selectedDay - (int)currentDayOfWeek;
            } 
            else
            {
                int offsetDays = 7 - (int)currentDayOfWeek;
                
                desiredDay += offsetDays + selectedDay;
            
            }
            return desiredDay;
        }
        public AppointmentForm()
        {
            
            
            InitializeComponent();
            IDtextbox.Text = Database.NextIndex("appointmentId", "appointment").ToString();
            ContactComboBox.DataSource = Database.GetAllCustomers();
            ContactComboBox.DisplayMember = "name";
            BindingList<String> types = new BindingList<String>();
            types.Add("Presentation");
            types.Add("Meeting");
            types.Add("Other");
            BindingList<String> days = new BindingList<String>();
            days.Add(DayOfWeek.Monday.ToString().Substring(0, 1));
            days.Add(DayOfWeek.Tuesday.ToString().Substring(0, 2));
            days.Add(DayOfWeek.Wednesday.ToString().Substring(0, 1));
            days.Add(DayOfWeek.Thursday.ToString().Substring(0, 2));
            days.Add(DayOfWeek.Friday.ToString().Substring(0, 1));
            TypeTextComboBox.DataSource = types;
            StartDayCombo.DataSource = days;
            EndDayCombo.DataSource = days;
            
            //TimeSlots 
            
            StartComboBox.DataSource = timeSlots();
            EndComboBox.DataSource = timeSlots();
        }
        private List<string> timeSlots()
        {
            DateTime estStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 0, 0, DateTimeKind.Utc);
            DateTime estEndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 21, 0, 0, DateTimeKind.Utc);

            List<String> timeSlots = new List<String>();

            DateTime currentSlot = estStartTime;
            while (currentSlot <= estEndTime)
            {
                string localTime = currentSlot.ToLocalTime().ToString("HH:mm");
                timeSlots.Add(localTime);
                currentSlot = currentSlot.AddMinutes(15);
            }
            timeSlots.Sort();
            return timeSlots;
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public string AppointmentID { get { return IDtextbox.Text; } set { IDtextbox.Text = value; } }
        public string Contact { 
            get 
            {
                Customer customer = (Customer)ContactComboBox.SelectedItem;
                return customer.name;
            }
            set { ContactComboBox.SelectedItem = value; } }

        public string Title { get { return TitleTextBox.Text; } set { TitleTextBox.Text = value; }}
        public string Description { get { return DescTextBox.Text; } set { DescTextBox.Text = value; } }
        public string Location { get { return LocationTextBox.Text; } set { LocationTextBox.Text = value; } }
        public string Type { get { return TypeTextComboBox.SelectedItem.ToString(); } set { TypeTextComboBox.SelectedItem = value; } }

        public string URL { get { return UrlTextBox.Text; } set { UrlTextBox.Text = value; } }
        public DateTime StartTime 
        { 
            get 
            {
                
                DateTime time = DateTime.ParseExact(StartComboBox.SelectedItem.ToString(), "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, getDay(StartDayCombo.SelectedIndex+1), time.Hour, time.Minute, 0);
            } 
            set 
            { 
                StartComboBox.SelectedItem = value; 
            } 
        }
        public DateTime EndTime 
        {
            get
            {
                DateTime time2 = DateTime.ParseExact(EndComboBox.SelectedItem.ToString(), "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, getDay(EndDayCombo.SelectedIndex+1), time2.Hour, time2.Minute, 0);
            }
            set 
            { 
                EndComboBox.SelectedItem = value; 
            } 
        }

        public Appointment Appointment {  get; set; }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            int cid = Convert.ToInt32(Database.SingleSelectQuery($"SELECT customerId FROM customer WHERE customerName = '{Contact}'"));
            int uid = Convert.ToInt32(Database.SingleSelectQuery($"SELECT userId FROM user WHERE userName = '{Database.currentUser}'"));
            Appointment = new Appointment(Convert.ToInt32(AppointmentID), 1,
                uid, Title, Description, Location, Contact, Type, URL, StartTime, EndTime,
                DateTime.UtcNow, Database.currentUser, DateTime.UtcNow, Database.currentUser);
        }
    }
}
