using HouseBroker.Core.Models;
using HouseBroker.Infastructure.Data.DataDbContext;
using HouseBroker.Infastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HouseBroker.WebAPIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("HouseBrokerConnectionString") ?? throw new InvalidOperationException("Connection string 'HouseBrokerConnectionString' not found.");

            builder.Services.AddDbContext<HouseBrokerDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<HouseBrokerDbContext>();

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddScoped<IGenericRepo, GenericRepo>();


            builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(HouseBroker.Infastructure.DataMapper.MapperProfiles).Assembly);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Properties}/{action=Index}/{id?}");
            app.MapRazorPages();

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { "House Broker", "House Seeker" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                string brokerEmail = "admin@admin.com";
                string seekerEmail = "seeker@seeker.com";
                string password = "Test@1234";

                if (await userManager.FindByEmailAsync(brokerEmail) == null)
                {
                    var user = new ApplicationUser();
                    user.UserName = brokerEmail;
                    user.Email = brokerEmail;

                    await userManager.CreateAsync(user, password);

                    await userManager.AddToRoleAsync(user, "House Broker");
                }
                if (await userManager.FindByEmailAsync(seekerEmail) == null)
                {
                    var user = new ApplicationUser();
                    user.UserName = seekerEmail;
                    user.Email = seekerEmail;

                    await userManager.CreateAsync(user, password);

                    await userManager.AddToRoleAsync(user, "House Seeker");
                }
            }
            app.Run();
        }
    }
}
