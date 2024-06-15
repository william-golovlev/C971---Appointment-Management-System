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
                        appointments.Add(new Appointment(Int32.Parse(dr[0].ToString()), Int32.Parse(dr[1].ToString()), Int32.Parse(dr[2].ToString()), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(),
                            dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), Convert.ToDateTime(dr[9]), Convert.ToDateTime(dr[10]), Convert.ToDateTime(dr[11]), dr[12].ToString(), Convert.ToDateTime(dr[13]), dr[14].ToString()));
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

        public static void AddAppointment(Appointment appointment)
        {
            MySqlConnection conn = new MySqlConnection(constr);
            using (conn)
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
    }
}
