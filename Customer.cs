using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Management_System
{
    public class Customer
    {
        public Customer(int id, string name, int addressId, string active, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdateBy) 
        {
            this.id = id;
            this.name = name;
            this.addressId = addressId;
            this.active = active;
            this.createDate = createDate;
            this.createdBy = createdBy;
            this.lastUpdate = lastUpdate;
            this.LastUpdatedBy = lastUpdateBy;
        }
        public int id {  get; set; }
        public string name { get; set; }
        public int addressId { get; set; }
        public string active { get; set; }
        public DateTime createDate { get; set; }
        public string createdBy { get; set; }
        public DateTime lastUpdate {  get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
