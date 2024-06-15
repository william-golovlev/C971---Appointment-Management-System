using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Management_System
{
    public class Country
    {
        public Country(int countryId, string countryName, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdateBy) 
        {
            this.countryId = countryId;
            this.countryName = countryName;
            this.createDate = createDate;
            this.createdBy = createdBy;
            this.lastUpdate = lastUpdate;
            this.lastUpdateBy = lastUpdateBy;
        }
        public int countryId {  get; set; }
        public string countryName { get; set; }
        public DateTime createDate { get; set; }
        public string createdBy { get; set; }
        public DateTime lastUpdate {  get; set; }
        public string lastUpdateBy { get; set; }

    }
}
