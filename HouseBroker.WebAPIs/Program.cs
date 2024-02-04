using HouseBroker.Infastructure.Data.DataDbContext;
using HouseBroker.Infastructure.Repositories;
using HouseBroker.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("HouseBrokerConnectionString") ?? throw new InvalidOperationException("Connection string 'HouseBrokerConnectionString' not found.");

builder.Services.AddDbContext<HouseBrokerDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<HouseBrokerDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<IGenericRepo, GenericRepo>();


builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(HouseBroker.Infastructure.DataMapper.MapperProfiles).Assembly);


var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    try
//    {
//        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
//        await DataInitializer(roleManager);
//    }
//    catch (Exception ex)
//    {
//        var logger = services.GetRequiredService<ILogger<Program>>();
//        logger.LogError(ex, "An error occurred while initializing roles.");
//    }
//}

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

app.Run();
