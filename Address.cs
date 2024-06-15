using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Management_System
{
    public class Address
    {
        public Address(int addressId, string address, string address2, int cityId, string postalCode, string phone, DateTime createDate,
            string createdBy, DateTime lastUpdate, string lastUpdatedBy) 
        {
            this.addressId = addressId;
            this.address = address;
            this.address2 = address2;
            this.cityId = cityId;
            this.postalCode = postalCode;
            this.phone = phone;
            this.createDate = createDate;
            this.createdBy = createdBy;
            this.lastUpdate = lastUpdate;
            this.lastUpdatedBy = lastUpdatedBy;
        }
        public int addressId { get; set; }
        public string address {  get; set; }
        public string address2 { get; set; }
        public int cityId { get; set; }
        public string postalCode {  get; set; }
        public string phone { get; set; }
        public DateTime createDate { get; set; }
        public string createdBy { get; set; }
        public DateTime lastUpdate {  get; set; }
        public string lastUpdatedBy { get; set; }
    }
}
