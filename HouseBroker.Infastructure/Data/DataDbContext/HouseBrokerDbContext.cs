using Microsoft.EntityFrameworkCore;
using HouseBroker.Core.Models;

namespace HouseBroker.Infastructure.Data.DataDbContext
{
    public class HouseBrokerDbContext : DbContext
    {
        public HouseBrokerDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-PG83KRS\\SQLEXPRESS;Database=HouseBrokerDb;Trusted_Connection=True;TrustServerCertificate=Yes");
        }
        public DbSet<Property> Properties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>().HasData(
                 new Property
                 {
                     PropertyId = Guid.NewGuid(),
                     PropertyName = "Bag Durbar",
                     State = "Bagmati",
                     District = "Kathmandu",
                     Municipality = "Kathmandu",
                     WardNo = 2,
                     Location = "Nakkhu",
                     PropertyDescription = "Description",
                     PropertyType = "Mansion",
                     AskingPrice = "300K",
                     DateCreated = DateTime.Now
                 }
            );

        }
    }
}
