using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Appointment_Management_System
{
    public partial class MainForm : Form
    {
        public BindingList<Appointment> allAppointments = Database.GetAllAppointments();
        public BindingList<Customer> allCustomers = Database.GetAllCustomers();
        public BindingList<Address> allAddresses = Database.getAllAddresses();
        public BindingList<City> allCities = Database.GetAllCities();
        public BindingList<Country> allCountries = Database.GetAllCountries();
        public MainForm()
        {
            InitializeComponent();
            customerDataGrid.DataSource = getAllCustomerViews();
            appointmentDataGrid.DataSource = getAllAppointViews();
            //appointmentDataGrid.DataSource = allAppointments;
            //appointmentDataGrid.Columns["customerId"].Visible = false;
            //appointmentDataGrid.Columns["userId"].Visible = false;
            //appointmentDataGrid.Columns["createDate"].Visible = false;
            //appointmentDataGrid.Columns["createdBy"].Visible = false;
            //appointmentDataGrid.Columns["lastUpdate"].Visible = false;
            //appointmentDataGrid.Columns["lastUpdatedBy"].Visible = false;
            //appointmentDataGrid.Columns["appointmentId"].HeaderText = "ID";
            //appointmentDataGrid.Columns["title"].HeaderText = "Title";
            //appointmentDataGrid.Columns["description"].HeaderText = "Description";
            //appointmentDataGrid.Columns["location"].HeaderText = "Location";
            //appointmentDataGrid.Columns["contact"].HeaderText = "Contact";
            //appointmentDataGrid.Columns["type"].HeaderText = "Type";
            //appointmentDataGrid.Columns["url"].HeaderText = "URL";
            //appointmentDataGrid.Columns["start"].HeaderText = "Start";
            //appointmentDataGrid.Columns["end"].HeaderText = "End";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppointmentForm addAppointment = new AppointmentForm();
            
            if (addAppointment.ShowDialog() == DialogResult.OK)
            {
                if (addAppointment.Description.Equals("") || addAppointment.Title.Equals("") || addAppointment.Location.Equals(""))
                {
                    return;
                }
                var apt = addAppointment.Appointment;

                if (addAppointment.StartTime >= addAppointment.EndTime)
                {
                    MessageBox.Show("Cannot have an appointment end before it starts! Retry later.");
                    this.Focus();
                }
                
                else {
                    allAppointments = Database.GetAllAppointments();
                    //allAppointments.Add(addAppointment.Appointment);
                    if (IsOverlapping(addAppointment.Appointment))
                    {
                        MessageBox.Show("OVERLAPPING APPOINTMENT ARE NOT ALLOWED");
                        return;
                    }
                    Database.AddAppointment(addAppointment.Appointment);
                    allAppointments.Clear();
                    allAppointments = Database.GetAllAppointments();
                    appointmentDataGrid.DataSource = getAllAppointViews();
                    appointmentDataGrid.Refresh();
                }
               
            }
            else
            {
                addAppointment.Close();
            }
        }

        public bool IsOverlapping(Appointment apt)
        {
            if (apt == null) return false;
            bool bad = false;
            foreach (var a in getAllAppointViews())
            {
                if (a is null)
                {
                    continue;
                }
                var startstr = a.StartTime.ToUniversalTime().ToString("yyyy-mm-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                var endstr = a.EndTime.ToUniversalTime().ToString("yyyy-mm-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                var targetStart = apt.start.ToUniversalTime().ToString("yyyy-mm-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                var targetEnd = apt.end.ToUniversalTime().ToString("yyyy-mm-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);

                bool overlapping = startstr.CompareTo(targetEnd) < 0 && targetStart.CompareTo(endstr) < 0;

                if (overlapping)
                {
                    bad = true;
                }
            }

            // Return the final result (true if any overlaps were found)
            return bad;
        }



        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            Database.loggedIn = false;
            Database.UserLoggedIn();
            Application.Exit();
        }

        private void radioAllApts_CheckedChanged(object sender, EventArgs e)
        {
            appointmentDataGrid.DataSource = allAppointments; 
        }

        private void radioMonth_CheckedChanged(object sender, EventArgs e)
        {
            int currentMonth = System.DateTime.Now.Month;
            var filteredApts = allAppointments
                .Where<Appointment>(a => a.createDate.Month == currentMonth)
                .ToList();
            appointmentDataGrid.DataSource = filteredApts;
        }

        private void radioWeek_CheckedChanged(object sender, EventArgs e)
        {
            int currentDay = System.DateTime.Now.Day;
            var filteredApts = allAppointments
                .Where<Appointment>(a => a.createDate.Day == currentDay)
                .ToList();
            appointmentDataGrid.DataSource= filteredApts;
        }

        private void DateSelect_Click(object sender, EventArgs e)
        {
            if (monthCalendar1.SelectionRange.Start == null)
            {
                appointmentDataGrid.DataSource = allAppointments;
            }
            DateTime date = monthCalendar1.SelectionRange.Start;
            var filteredApts = allAppointments
                .Where<Appointment>(a => a.start.Day == date.Day)
                .ToList();
            if (filteredApts.Count > 0)
            {
                appointmentDataGrid.DataSource = filteredApts;
            }
            else return;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            
        }

        private void ShowAllApts_Click(object sender, EventArgs e)
        {
            appointmentDataGrid.DataSource = allAppointments;

            //var twentyfour = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss");
            //MessageBox.Show(DateTime.Now.ToString() + " vs " + DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss") + " VS " + Convert.ToDateTime(twentyfour));
        }

        private void AddCust_Click(object sender, EventArgs e)
        {
            CustomerForm addCustomer = new CustomerForm();
            addCustomer.Id = Database.NextIndex("customerId", "customer").ToString();
            if (addCustomer.ShowDialog() == DialogResult.OK)
            {
                if (addCustomer.CName.Equals("") || addCustomer.Address.Equals("") || addCustomer.Phone.Equals("") || addCustomer.PostalCode.Equals("") || addCustomer.CityName.Equals(""))
                {
                    MessageBox.Show("Fill out all fields!");
                    return;
                }
                if (!Database.IsInTable(addCustomer.CountryName, "country", "country"))
                {
                    Database.AddCountry(new Country(Database.NextIndex("countryId", "country"), addCustomer.CountryName, DateTime.Now,
                        Database.currentUser, DateTime.Now, Database.currentUser));
                }
                
                if (!Database.IsInTable(addCustomer.CityName, "city", "city"))
                {
                    //allCountries = Database.GetAllCountries();
                    Database.AddCity(new City(Database.NextIndex("cityId", "city"), addCustomer.CityName, 
                        Convert.ToInt32(Database.SingleSelectQuery($"SELECT countryId FROM Country WHERE country = '{addCustomer.CountryName}'")), 
                        DateTime.Now, Database.currentUser, DateTime.Now, Database.currentUser));
                }
                bool isValidPhone = true;
                string phone = addCustomer.Phone;
                foreach (var ch in phone)
                {
                    if (ch != '-' && !char.IsDigit(ch))
                    {
                        MessageBox.Show("ILLEGAL CHARS- Only digits and dashes allowed.");
                        isValidPhone = false;
                        addCustomer.Close();
                        return;
                    }

                }
                if (Database.SingleSelectQuery($"SELECT * FROM address WHERE address = '{addCustomer.Address}' AND" +
                        $" phone = '{addCustomer.Phone}' AND postalCode = '{addCustomer.PostalCode}'").Equals(""))
                {
                    Database.AddAddress(new Address(Database.NextIndex("addressId", "address"), addCustomer.Address, null,
                    Convert.ToInt32(Database.SingleSelectQuery($"SELECT cityId FROM city WHERE city = '{addCustomer.CityName}'")), addCustomer.PostalCode, 
                    addCustomer.Phone, DateTime.Now, Database.currentUser, DateTime.Now, Database.currentUser));
                }
                if (!Database.IsInTable(addCustomer.CustomerName, "customerName", "customer"))
                {
                    Database.AddCustomer(new Customer(Database.NextIndex("customerId", "customer"), 
                        addCustomer.CustomerName, Convert.ToInt32(Database.SingleSelectQuery($"SELECT addressId FROM address WHERE address = '{addCustomer.Address}'")), "1",
                        DateTime.Now, Database.currentUser, DateTime.Now, Database.currentUser));
                    allCountries.Clear();
                    allCities.Clear();
                    allAddresses.Clear();
                    allCustomers.Clear();
                    allCountries = Database.GetAllCountries();
                    allCities = Database.GetAllCities();
                    allAddresses = Database.getAllAddresses();
                    allCustomers = Database.GetAllCustomers();
                    customerDataGrid.DataSource = getAllCustomerViews();
                }
                customerDataGrid.Refresh();
            }
            else
            {
                addCustomer.Close();
            }
        }

        public BindingList<CustomerView> getAllCustomerViews()
        {
            var customerViews = new BindingList<CustomerView>();
            foreach (Customer customer in allCustomers)
            {
                var matchingAddress = allAddresses.FirstOrDefault<Address>(a => a.addressId == customer.addressId);
                if (matchingAddress != null)
                {
                    var matchingCity = allCities.FirstOrDefault<City>(c => c.cityId == matchingAddress.cityId);
                    if (matchingCity != null)
                    {
                        var matchingCountry = allCountries.FirstOrDefault<Country>(c => c.countryId == matchingCity.countryId);
                        if (matchingCountry != null) customerViews.Add(new CustomerView(customer, matchingAddress, matchingCity, matchingCountry));
                        else
                        {
                            MessageBox.Show("NO MATCHING Country");
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("NO MATCHING City");
                    }
                }
                else
                {
                    MessageBox.Show("NO MATCHING Address " + customer.addressId + " " + customer.addressId.GetType());
                }
            }
            return customerViews;
        }

        public BindingList<AppointmentView> getAllAppointViews()
        {
            var appointmentViews = new BindingList<AppointmentView>();
            foreach (var a in allAppointments)
            {
                appointmentViews.Add(new AppointmentView(a));
            }

            return appointmentViews;
        }
        private void UpdateCust_Click(object sender, EventArgs e)
        {
            CustomerForm modifyCustomer = new CustomerForm();

            if (customerDataGrid.SelectedRows.Count > 0)
            {
                CustomerView customer = (CustomerView)customerDataGrid.SelectedRows[0].DataBoundItem;
                modifyCustomer.Id = customer.ID.ToString();
                modifyCustomer.CName = customer.Name;
                modifyCustomer.Address = customer.Address;
                modifyCustomer.Phone = customer.PhoneNumber;
                modifyCustomer.CityName = customer.City;
                modifyCustomer.PostalCode = customer.PostalCode;
                modifyCustomer.CountryName = customer.Country;

                if (modifyCustomer.ShowDialog() == DialogResult.OK)
                {
                    CustomerView updatedCustomer = customer;
                    updatedCustomer.Name = modifyCustomer.CName;
                    updatedCustomer.Address = modifyCustomer.Address;
                    updatedCustomer.PhoneNumber = modifyCustomer.Phone;
                    updatedCustomer.City = modifyCustomer.CityName;
                    updatedCustomer.PostalCode = modifyCustomer.PostalCode;
                    updatedCustomer.Country = customer.Country;

                    Database.UpdateCustomer(updatedCustomer);
                    allCountries.Clear();
                    allCities.Clear();
                    allAddresses.Clear();
                    allCustomers.Clear();
                    allCountries = Database.GetAllCountries();
                    allCities = Database.GetAllCities();
                    allAddresses = Database.getAllAddresses();
                    allCustomers = Database.GetAllCustomers();
                }
                customerDataGrid.DataSource = null;
                customerDataGrid.Rows.Clear();
                customerDataGrid.DataSource = getAllCustomerViews();
                customerDataGrid.Refresh();
                appointmentDataGrid.Refresh();
                return;
            }
            else
            {
                MessageBox.Show("Please select a customer record to update...");
            }
        }

        private void DeleteCust_Click(object sender, EventArgs e)
        {
            if (customerDataGrid.SelectedRows.Count > 0)
            {
                CustomerView customer = (CustomerView)customerDataGrid.SelectedRows[0].DataBoundItem;
                var dialogResult = MessageBox.Show($"Are you sure you want to delete the customer \"{customer.Name}\"", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (!Database.SingleSelectQuery($"SELECT appointmentId FROM appointment WHERE customerId = {customer.ID}").Equals(""))
                    {
                        MessageBox.Show($"Cannot delete {customer.Name} when they have appointment(s)!");
                        return;
                    }
                    Database.DeleteCustomer(customer);
                    allCountries.Clear();
                    allCities.Clear();
                    allAddresses.Clear();
                    allCustomers.Clear();
                    allCountries = Database.GetAllCountries();
                    allCities = Database.GetAllCities();
                    allAddresses = Database.getAllAddresses();
                    allCustomers = Database.GetAllCustomers();
                }
                customerDataGrid.DataSource = null;
                customerDataGrid.Rows.Clear();
                customerDataGrid.DataSource = getAllCustomerViews();
                customerDataGrid.Refresh();
            }
            else
            {
                MessageBox.Show("You must select a record to delete...");
            }
        }

        private void ReportsBtn_Click(object sender, EventArgs e)
        {
            ReportChoices reports = new ReportChoices();
            reports.Show();
        }

        private void UpdateApt_Click(object sender, EventArgs e)
        {
            AppointmentForm modifyApt = new AppointmentForm();
            if (appointmentDataGrid.SelectedRows.Count > 0)
            {
                AppointmentView apt = appointmentDataGrid.SelectedRows[0].DataBoundItem as AppointmentView;
                modifyApt.AppointmentID = apt.ID.ToString();
                modifyApt.Contact = apt.Contact;
                modifyApt.Title = apt.Title;
                modifyApt.Description = apt.Description;
                modifyApt.Location = apt.Location;
                modifyApt.Type = apt.Type;
                modifyApt.URL = apt.URL;
                modifyApt.StartTimeComboBox = apt.StartTime.ToLocalTime().ToString("HH:mm");
                modifyApt.EndTimeComboBox = apt.EndTime.ToLocalTime().ToString("HH:mm");

                if (modifyApt.ShowDialog() == DialogResult.OK)
                {
                    
                    if (modifyApt.StartTime >= modifyApt.EndTime)
                    {
                        MessageBox.Show("Cannot have an appointment end before it starts! Retry later.");
                        this.Focus();
                    }
                    else if (true)
                    {
                        allAppointments = Database.GetAllAppointments();

                        if (IsOverlapping(modifyApt.Appointment))
                        {
                            MessageBox.Show("OVERLAPPING APPOINTMENT ARE NOT ALLOWED");
                            return;
                        }
                        AppointmentView updatedApt = apt;
                        updatedApt.ID = Convert.ToInt32(modifyApt.AppointmentID);
                        updatedApt.Contact = modifyApt.Contact;
                        updatedApt.Title = modifyApt.Title;
                        updatedApt.Description = modifyApt.Description;
                        updatedApt.Location = modifyApt.Location;
                        updatedApt.Type = modifyApt.Type;
                        updatedApt.URL = modifyApt.URL;
                        updatedApt.StartTime = modifyApt.StartTime;
                        updatedApt.EndTime = modifyApt.EndTime;

                        Database.ModifyAppointment(updatedApt);
                        allAppointments.Clear();
                        allAppointments = Database.GetAllAppointments();
                        appointmentDataGrid.DataSource = getAllAppointViews();
                        appointmentDataGrid.Refresh();
                    }
                }
            }
            else
            {
                MessageBox.Show("No appointment row selected...");
            }
        }

        private void DeleteApt_Click(object sender, EventArgs e)
        {
            if (appointmentDataGrid.SelectedRows.Count > 0)
            {
                Database.DeleteAppointment(appointmentDataGrid.SelectedRows[0].DataBoundItem as AppointmentView);
                allAppointments = Database.GetAllAppointments();
                appointmentDataGrid.DataSource = getAllAppointViews();
                appointmentDataGrid.Refresh();
            }
        }
    }

    public class CustomerView
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public CustomerView (Customer customer, Address address, City city, Country country) 
        { 
            ID = customer.id;
            Name = customer.name;
            Address = address.address;
            PhoneNumber = address.phone;
            City = city.cityName;
            PostalCode = address.postalCode;
            Country = country.countryName;
        }
    }

    public class AppointmentView
    {
        public AppointmentView(Appointment appointment)
        {
            ID = appointment.appointmentId;
            Contact = Database.SingleSelectQuery($"SELECT customerName FROM customer WHERE customerId = {appointment.customerId}");
            Title = appointment.title;
            Description = appointment.description;
            Location = appointment.location;
            Type = appointment.type;
            URL = appointment.url;
            StartTime = appointment.start;
            EndTime = appointment.end;
        }

        public int ID { get; set; }
        public string Contact { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public string URL { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
