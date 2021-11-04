using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_CCSB.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        public string VehicleBrand { get; set; }
        public string VehicleType { get; set; }
        public decimal Length { get; set; }
        public string VehicleKind { get; set; }
        public string LicensePlate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
