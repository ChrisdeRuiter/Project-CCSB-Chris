using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_CCSB.Models
{
    public class Appointments
    {
        [Key]
        public int AppointmentId { get; set; }
        public DateTime TimeAndMoment { get; set; }
        public string Action { get; set; }

        public List<Vehicle> Vehicles;
    }
}
