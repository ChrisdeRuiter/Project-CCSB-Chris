using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_CCSB.Models.ViewModels
{
    public class VehicleViewModel
    {
        [DisplayName("Merk")]
        public string VehicleBrand { get; set; }
        [DisplayName("Type voertuig")]
        public string VehicleType { get; set; }
        [DisplayName("Lengte Voertuig")]
        public decimal Length { get; set; }
        [DisplayName("Soort Voertuig")]
        public string VehicleKind { get; set; }
        [DisplayName("Kenteken")]
        public string Licenseplate { get; set; }
        [DisplayName("Klant")]
        public string CustomerName { get; set; }
    }
}
