using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appointment_Management_System
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
            var allCountries = GetAllCountryNamesInTheWorld();
            foreach (var country in allCountries)
            {
                if (country.Contains("'"))
                {
                    var fixedName = country.Replace("'", "''");
                    Database.AddCountry(new Country(Database.NextIndex("countryId", "country"), fixedName, DateTime.Now,
                        Database.currentUser, DateTime.Now, Database.currentUser));
                }
                else if (Database.SingleSelectQuery($"SELECT country FROM country WHERE country = '{country}'").Equals(""))
                {
                    Database.AddCountry(new Country(Database.NextIndex("countryId", "country"), country, DateTime.Now, 
                        Database.currentUser, DateTime.Now, Database.currentUser));
                }             
            }
            CountryChoices.DataSource = allCountries;
            CountryChoices.SelectedItem = "United States";
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {

        }

        public string Id { get { return textBoxID.Text; } set { textBoxID.Text = value; } }

        public string CName { get { return textBoxName.Text; } set { textBoxName.Text = value; } }

        public string Address { get { return textBoxAddress.Text; } set { textBoxAddress.Text = value; } }

        public string Phone 
        { 
            get 
            {
                return textBoxPhone.Text.Trim();
            } 
            set 
            { 
                textBoxPhone.Text = value;
            }
        }

        private void CountryChoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            CountryName = CountryChoices.SelectedValue.ToString();
        }

        public string CountryName { get; set; }

        public string CityName { get { return textBoxCity.Text; } set { textBoxCity.Text = value; } }

        public string PostalCode { get { return textBoxPostal.Text; } set { textBoxPostal.Text = value; } }

        public string CustomerName { get { return textBoxName.Text; } set { textBoxName.Text = value; } }

        private List<String> GetAllCountryNamesInTheWorld()
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            return cultures
                .Select(cult => (new RegionInfo(cult.LCID)).DisplayName)
                .Distinct()
                .OrderBy(c => c)
                .ToList();
        }
    }
}
