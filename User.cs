using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Management_System
{
    internal class User
    {
        public User(int id, string username, string password, string active, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdateBy) 
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.active = active;
            this.createDate = createDate;
            this.lastUpdate = lastUpdate;
            this.lastUpdatedBy = lastUpdateBy;
        }
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string active {  get; set; }
        public DateTime createDate { get; set; }
        public string createdBy { get; set; }
        public DateTime lastUpdate {  get; set; }
        public string lastUpdatedBy { get; set; }
    }
}
