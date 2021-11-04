using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project_CCSB.Models
{
    public class Factuur
    {
        [Key]
        public int FactuurNummer { get; set; }
        public DateTime FactuurDatum { get; set; }
        public double Bedrag { get; set; }
        public int ContractId { get; set; }
        public Contract Contract { get; set; }
    }
}
