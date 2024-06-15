using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Management_System
{
    public class City
    {
        public City(int cityId, string cityName, int countryId, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdatedBy) 
        {
            this.cityId = cityId;
            this.cityName = cityName;
            this.countryId = countryId;
            this.createDate = createDate;
            this.createdBy = createdBy;
            this.lastUpdate = lastUpdate;
            this.lastUpdatedBy = lastUpdatedBy;
        }
        public int cityId { get; set; }
        public string cityName { get; set; }
        public int countryId { get; set; }
        public DateTime createDate { get; set; }
        public string createdBy { get; set; }
        public DateTime lastUpdate {  get; set; }
        public string lastUpdatedBy { get; set; }

    }
}
