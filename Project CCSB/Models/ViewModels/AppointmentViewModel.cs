using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_CCSB.Models.ViewModels
{
    public class AppointmentViewModel
    {
        public string OphalenId { get; set; }
        public int AppointmentId { get; set; }
        public DateTime TimeAndMoment { get; set; }
        public string Action { get; set; }

        public string CustomerName { get; set; }
        public object Description { get; internal set; }
        public int Id { get; internal set; }
        public DateTime StartDate { get;  set; }
        public DateTime EndDate { get;  set; }
    }
}
