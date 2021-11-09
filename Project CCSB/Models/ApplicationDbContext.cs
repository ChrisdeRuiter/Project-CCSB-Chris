using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_CCSB.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Appointment> Appointment { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Contract> Contract { get; set; }
        public DbSet<Factuur> Factuur { get; set; }
    }
}
