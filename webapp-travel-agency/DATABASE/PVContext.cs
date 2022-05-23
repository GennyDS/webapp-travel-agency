using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.DATABASE
{
    public class PVContext : DbContext
    {

        public DbSet<PacchettoViaggio> PacchettoViaggio { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database= Mia_Agenzia_Viaggi;Integrated Security=True");
        }

    }
}
