using Exercitii_laborator_18.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercitii_laborator_18.Data
{
    internal class CarDealerContextDB : DbContext
    {
        public DbSet<Autovehicle> Autovehicles { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Key> Keys { get; set; }
        public DbSet<VehicleIdentificationCard> VehicleIdentificationCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-42S4FFT\\SQLEXPRESS;Initial Catalog=CarDealerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
