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
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
  
    }
}
