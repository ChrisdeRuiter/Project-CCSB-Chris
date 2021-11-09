using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_CCSB.Models
{
    public class Appointment
    {

        #region Properties
     
        public int Id { get; set; }
        public string Action { get; set; }
        public DateTime TimeAndMoment { get; set; }
        public string CustomerId { get; set; }
        public string AdminId { get; set; }
        #endregion

    }
}
