using Microsoft.EntityFrameworkCore;
using HouseBroker.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace HouseBroker.Infastructure.Data.DataDbContext
{
    public class HouseBrokerDbContext : IdentityDbContext<ApplicationUser>
    {
        public HouseBrokerDbContext(DbContextOptions<HouseBrokerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }

        //    protected override void OnModelCreating(ModelBuilder modelBuilder)
        //    {
        //        modelBuilder.Entity<Property>().HasData(
        //             new Property
        //             {
        //                 PropertyId = Guid.NewGuid(),
        //                 PropertyName = "Bag Durbar",
        //                 State = "Bagmati",
        //                 District = "Kathmandu",
        //                 Municipality = "Kathmandu",
        //                 WardNo = 2,
        //                 Location = "Nakkhu",
        //                 PropertyDescription = "Description",
        //                 PropertyType = "Mansion",
        //                 AskingPrice = "300K",
        //                 DateCreated = DateTime.Now
        //             }
        //        );

        //    }
        //}
    }
}

