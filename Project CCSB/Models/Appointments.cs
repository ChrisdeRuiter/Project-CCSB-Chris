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
        public string OphalenId { get; set; }
        public int AppointmentId { get; set; }
        public DateTime TimeAndMoment { get; set; }
        public string Action { get; set; }
        public string CustomerName { get; set; }
        public int Id { get; internal set; }
        public DateTime EndDate { get;  set; }
        public DateTime StartDate { get;  set; }
        public string CustomerId { get; internal set; }
    }
}
