using MySql.Data.MySqlClient;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using System.ComponentModel;
using System.Globalization;
using MySqlX.XDevAPI.Relational;
using System.Management;

namespace Appointment_Management_System
{
    internal class Database
    {
        public static string currentUser = "test";
        public static string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
        public static BindingList<Address> addresses = new BindingList<Address>();
        public static BindingList<User> users = new BindingList<User>();
        public static BindingList<Customer> customers = new BindingList<Customer>();
        public static BindingList<City> cities = new BindingList<City>();
        public static BindingList<Country> countries = new BindingList<Country>();
        public static bool loggedIn = false;

        public static BindingList<User> GetAllUsers()
        {
            MySqlConnection conn = new MySqlConnection(constr);
            
            using (conn)
            {
                try
                {
                    conn.Open();
                    String sqlString = "SELECT * FROM user";
                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);
                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        users.Add(new User(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), Convert.ToDateTime(dr[4]), dr[5].ToString(), Convert.ToDateTime(dr[6]), dr[7].ToString()));
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show(users.Count + "LOSER" + e);
                }

                return users;
            }
        }

        public static BindingList<Customer> GetAllCustomers() {
            MySqlConnection conn = new MySqlConnection(constr);
            
            using (conn)
            {
                try
                {
                    conn.Open();
                    String sqlString = "SELECT * FROM customer";
                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);
                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        customers.Add(new Customer(Int32.Parse(dr[0].ToString().Trim()), dr[1].ToString(), Int32.Parse(dr[2].ToString().Trim()), dr[3].ToString(), Convert.ToDateTime(dr[4]), dr[5].ToString(), Convert.ToDateTime(dr[6]), dr[7].ToString()));
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                return customers;
            }
        }

        public static BindingList<Appointment> GetAllAppointments()
        {
            MySqlConnection conn = new MySqlConnection(constr);
            BindingList<Appointment> appointments = new BindingList<Appointment>();
            using (conn)
            {
                try
                {
                    conn.Open();
                    String sqlString = "SELECT * FROM appointment";
                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);
                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        DateTime start = DateTime.ParseExact(Convert.ToDateTime(dr[9]).ToString("yyyy-MM-dd HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                        DateTime localStart = TimeZoneInfo.ConvertTimeFromUtc(start, TimeZoneInfo.Local);

                        DateTime end = DateTime.ParseExact(Convert.ToDateTime(dr[10]).ToString("yyyy-MM-dd HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                        DateTime localEnd = TimeZoneInfo.ConvertTimeFromUtc(end, TimeZoneInfo.Local);

                        DateTime created = DateTime.ParseExact(Convert.ToDateTime(dr[11]).ToString("yyyy-MM-dd HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                        DateTime localCreated = TimeZoneInfo.ConvertTimeFromUtc(created, TimeZoneInfo.Local);

                        DateTime updated = DateTime.ParseExact(Convert.ToDateTime(dr[13]).ToString("yyyy-MM-dd HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                        DateTime localUpdated = TimeZoneInfo.ConvertTimeFromUtc(updated, TimeZoneInfo.Local);

                        appointments.Add(new Appointment(Int32.Parse(dr[0].ToString()), Int32.Parse(dr[1].ToString()), Int32.Parse(dr[2].ToString()), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(),
                            dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), localStart, localEnd, localCreated, dr[12].ToString(), localUpdated, dr[14].ToString()));
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                return appointments;
            }
        }

        public static BindingList<Country> GetAllCountries()
        {
            MySqlConnection conn = new MySqlConnection(constr);
            using (conn)
            {
                try
                {
                    conn.Open();
                    String sqlString = "SELECT * FROM country";
                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);
                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        countries.Add(new Country(Int32.Parse(dr[0].ToString()), dr[1].ToString(), Convert.ToDateTime(dr[2]), dr[3].ToString(), Convert.ToDateTime(dr[4]), dr[5].ToString()));
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                return countries;
            }
        }

        public static BindingList<City> GetAllCities()
        {
            MySqlConnection conn = new MySqlConnection(constr);
            
            using (conn)
            {
                try
                {
                    conn.Open();
                    String sqlString = "SELECT * FROM city";
                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);
                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        cities.Add(new City(Int32.Parse(dr[0].ToString()), dr[1].ToString(), Int32.Parse(dr[2].ToString()), Convert.ToDateTime(dr[3]), dr[4].ToString(), Convert.ToDateTime(dr[5]), dr[6].ToString()));
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                return cities;
            }
        }

        public static BindingList<Address> getAllAddresses()
        {
            MySqlConnection conn = new MySqlConnection(constr);
            
            using (conn)
            {
                try
                {
                    conn.Open();
                    String sqlString = "SELECT * FROM address";
                    MySqlCommand cmd = new MySqlCommand( sqlString, conn);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while(dr.Read())
                    {
                        //MessageBox.Show(Int32.Parse(dr[0].ToString().Trim()).ToString() + "    " + (Int32.Parse(dr[0].ToString().Trim()).GetType()));
                        addresses.Add(new Address(Int32.Parse(dr[0].ToString().Trim()), dr[1].ToString(), dr[2].ToString(), Int32.Parse(dr[3].ToString().Trim()),
                            dr[4].ToString(), dr[5].ToString(), Convert.ToDateTime(dr[6]), dr[7].ToString(),
                            Convert.ToDateTime(dr[8]), dr[9].ToString()));
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString()); 
                }
                return addresses;
            }
        }

        public static int AddCustomer(Customer customer)
        {
            MySqlConnection conn = new MySqlConnection(constr);
            //BindingList<Appointment> appointments = new BindingList<Appointment>();
            using (conn)
            {
                try
                {
                    conn.Open();
                    String sqlString = $"INSERT INTO `customer` VALUES ('{customer.id}', '{customer.name}', '{customer.addressId}', '{Int32.Parse(customer.active)}', " +
                        $"'{customer.createDate.ToUniversalTime().ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo)}',  '{customer.createdBy}'," +
                        $"'{customer.lastUpdate.ToUniversalTime().ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo)}', '{customer.LastUpdatedBy}')";
                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                return -1;
            }
        }

        public static int AddCountry(Country country)
        {
            MySqlConnection conn = new MySqlConnection(constr);
            using (conn)
            {
                try
                {
                    conn.Open();
                    String sqlString = $"INSERT INTO `country` VALUES ({country.countryId}, '{country.countryName}', '{country.createDate.ToUniversalTime().ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo)}'," +
                        $" '{country.createdBy}', '{country.lastUpdate.ToUniversalTime().ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo)}', '{country.lastUpdateBy}')";
                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);
                    cmd.ExecuteNonQuery();
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                return -1;
            }
            
        }

        public static int AddCity(City city)
        {
            MySqlConnection conn = new MySqlConnection(constr);
            using (conn)
            {
                try
                {
                    conn.Open();
                    //String sqlString = $"INSERT INTO `city` VALUES ({city.cityId}, '{city.cityName}', {city.countryId}, '{city.createDate.ToUniversalTime().ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo)}'," +
                    String sqlString = $"INSERT INTO `city` VALUES ({city.cityId}, '{city.cityName}', {city.countryId}, '{city.createDate.ToUniversalTime().ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo)}'," +
                        $" '{city.createdBy}', '{city.lastUpdate.ToUniversalTime().ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo)}', '{city.lastUpdatedBy}')";
                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                return -1;
            }
        }

        public static int AddAddress(Address address)
        {
            MySqlConnection conn = new MySqlConnection(constr);
            using (conn)
            {
                try
                {
                    conn.Open();
                    String sqlString = $"INSERT INTO `address` VALUES ({address.addressId}, '{address.address}', '{address.address2}', {address.cityId}, " +
                        $"'{address.postalCode}', '{address.phone}', '{address.createDate.ToUniversalTime().ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo)}'," +
                        $" '{address.createdBy}', '{address.lastUpdate.ToUniversalTime().ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo)}', '{address.lastUpdatedBy}')";
                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                return -1;
            }
        }

        /// <summary>
        /// Takes Max int of given column in given table. Default is 1 if query is 0 or less.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public static int NextIndex(String column, String table)
        {
            MySqlConnection conn = new MySqlConnection(constr);
            int next_index = 1;
            using (conn)
            {
                try
                {
                    conn.Open();
                    String sqlString = $"SELECT MAX({column}) FROM {table}";
                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        next_index = Convert.ToInt32(dr[0]);
                    }
                    return next_index + 1;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                return -1;
            }
        }

        /// <summary>
        /// Checks if a field is in a table. You do need the column name the field would appear under.
        /// </summary>
        /// <param name="field"></param>
        /// <param name="column"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public static bool IsInTable(String field, String column, String table)
        {
            MySqlConnection conn = new MySqlConnection(constr);
            bool exists = false;
            using (conn)
            {
                try
                {
                    conn.Open();
                    String sqlString = $"SELECT * FROM {table} WHERE {column}='{field}'";
                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        exists = true;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                return exists;
            }
        }

        public static string SingleSelectQuery(String query)
        {
            MySqlConnection conn = new MySqlConnection(constr);
            string result = "";
            using (conn)
            {
                try
                {
                    conn.Open();
                    String sqlString = query;
                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        result = dr[0].ToString();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                return result;
            }
        }
        public static void UpdateTable(String oldField, String newField, String ID, String IDCol, String column, String table)
        {
            MySqlConnection conn = new MySqlConnection(constr);
            using (conn)
            {
                try
                {
                    conn.Open();
                    String sqlString = $"UPDATE {table} SET {column} = '{newField}' WHERE {column} = '{oldField}' AND {IDCol} = {ID}";
                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            return;
        }

        public static void DeleteCustomer(CustomerView customer)
        {
            MySqlConnection conn = new MySqlConnection(constr);
            using (conn)
            {
                try
                {
                    conn.Open();
                    String sqlString = $"DELETE FROM customer WHERE customerId = {customer.ID}";
                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);
                    cmd.ExecuteNonQuery();
                }
                catch(Exception e) 
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }

        public static void DeleteAppointment(AppointmentView appointment)
        {
            MySqlConnection conn = new MySqlConnection(constr);
            using (conn)
            {
                try
                {
                    conn.Open();
                    var result = MessageBox.Show($"Are you sure you want to delete the appointment for {appointment.Contact}?", "Confirm", MessageBoxButtons.YesNo);
                    if (result != DialogResult.Yes)
                    {
                        return;
                    }
                    String sqlString = $"DELETE FROM appointment WHERE appointmentId = {appointment.ID}";
                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }

        public static void AddAppointment(Appointment appointment)
        {
            
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                try
                {
                    conn.Open();
                    String sqlString = $"INSERT INTO `appointment` VALUES ({appointment.appointmentId}, {appointment.customerId}, {appointment.userId}, '{appointment.title}', " +
                        $"'{appointment.description}', '{appointment.location}', '{appointment.contact}'," +
                        $" '{appointment.type}', '{appointment.url}', '{appointment.start.ToUniversalTime().ToString("yyyy/MM/dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', '{appointment.end.ToUniversalTime().ToString("yyyy/MM/dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', '{appointment.createDate.ToUniversalTime().ToString("yyyy/MM/dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', '{appointment.createdBy}'," +
                        $"'{appointment.lastUpdate.ToUniversalTime().ToString("yyyy/MM/dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', '{appointment.lastUpdatedBy}')";
                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }

        public static void ModifyAppointment(AppointmentView appointment)
        {
            
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                try
                {
                    conn.Open();
                    String sqlString = $"UPDATE `appointment` SET contact = '{appointment.Contact}', title = '{appointment.Title}', " +
                        $"description = '{appointment.Description}', location = '{appointment.Location}', type = '{appointment.Type}'," +
                        $" url = '{appointment.URL}', start = '{appointment.StartTime.ToUniversalTime().ToString("yyyy/MM/dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', end = '{appointment.EndTime.ToUniversalTime().ToString("yyyy/MM/dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}'," +
                        $" lastUpdate = '{DateTime.Now.ToUniversalTime().ToString("yyyy/MM/dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', lastUpdateBy = '{Database.currentUser}' WHERE appointmentId = {appointment.ID}";
                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    MessageBox.Show("SUCCESS+ " + rowsAffected);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public static void UpdateCity(CustomerView customer)
        {
            
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                try
                {
                    conn.Open();
                    String sqlString = $"UPDATE `address` SET cityId = {SingleSelectQuery($"SELECT cityId FROM city WHERE city = '{customer.City}'")} WHERE " +
                        $"addressId = {SingleSelectQuery($"SELECT addressId FROM customer WHERE customerId = {customer.ID}")}";
                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);
                    int rowsAffected = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public static void UpdateCustomer(CustomerView customer)
        {
            
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                try
                {
                    conn.Open();
                    String customerUpdate = $"UPDATE `customer` SET customerName = '{customer.Name}'," +
                        $" lastUpdate = '{DateTime.Now.ToUniversalTime().ToString("yyyy/MM/dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}'," +
                        $" lastUpdateBy = '{Database.currentUser}' WHERE customerId = {customer.ID}";
                    MySqlCommand cmd = new MySqlCommand(customerUpdate, conn);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    String addressUpdate = $"UPDATE `address` SET address = '{customer.Address}', postalCode = '{customer.PostalCode}', " +
                        $"lastUpdate = '{DateTime.Now.ToUniversalTime().ToString("yyyy/MM/dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', lastUpdateBy = '{currentUser}' " +
                        $"WHERE addressId = {Convert.ToInt32(SingleSelectQuery($"SELECT addressId FROM customer WHERE customerId = {Convert.ToInt32(customer.ID)}"))}";
                    MySqlCommand cmd2 = new MySqlCommand(addressUpdate, conn);
                    rowsAffected = cmd2.ExecuteNonQuery();
                    MessageBox.Show(customer.City + "     " + addressUpdate);

                    if (SingleSelectQuery($"SELECT * FROM city WHERE city = '{customer.City}'").Equals(""))
                    {
                        MessageBox.Show($"The city: \"{customer.City}\" doesn't exist. If this was intentional, create a record...");
                    }
                    else
                    {
                        UpdateCity(customer);
                    }

                    String countryUpdate = $"lastUpdate = '{DateTime.Now.ToUniversalTime().ToString("yyyy/MM/dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}'";
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public static void UserLoggedIn()
        {
            int flag;
            if (loggedIn)
            {
                flag = 0;
            }
            else
            {
                flag = 1;
            }
            
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                try
                {
                    conn.Open();
                    String sqlString = $"UPDATE `user` SET active = {flag} WHERE userName = '{currentUser}'";
                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);
                    int rowsAffected = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public static DataTable Report(int type)
        {
            DataTable dt = new DataTable();
            MySqlConnection conn = new MySqlConnection(constr);

            using (conn)
            {
                try
                {
                    conn.Open();
                    String sqlString = "";

                    if (type == 0)
                    {
                        sqlString = "SELECT MONTHNAME(`start`) As 'Month', COUNT(*) AS Count FROM appointment GROUP BY MONTHNAME(`start`)";
                    }
                    else if (type == 1)
                    {
                        sqlString = "SELECT userName As 'User', COUNT(appointmentId) As Count FROM user LEFT JOIN appointment ON user.userId = appointment.userId GROUP BY userName";
                    }
                    else if (type == 2)
                    {
                        sqlString = "SELECT `type` AS Type, COUNT(*) As Count FROM appointment GROUP BY `type`";
                    }
                    

                    MySqlCommand cmd = new MySqlCommand(sqlString, conn);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                     
                }
                catch (Exception e)
                {
                    MessageBox.Show(users.Count + " " + e);
                }

                return dt;
            }
        }
    }
}
