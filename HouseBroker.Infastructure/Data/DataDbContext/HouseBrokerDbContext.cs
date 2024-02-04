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

    }
}


