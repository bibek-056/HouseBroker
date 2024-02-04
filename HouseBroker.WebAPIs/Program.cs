using HouseBroker.Infastructure.Data.DataDbContext;
using HouseBroker.Infastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HouseBrokerDbContext>();

builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
