using Microsoft.EntityFrameworkCore;
using Realestate.Areas.Admin.Models;
using Realestate.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();


builder.Services.AddDbContext<Signupdatacontext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("con");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
  //  options.UseMySql(builder.Configuration.GetConnectionString("Con")); 
});

builder.Services.AddDbContext<SaleHomeContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("con");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    //  options.UseSqlServer(builder.Configuration.GetConnectionString("Con"));
});


builder.Services.AddDbContext<BuyHomeContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("con");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    //options.UseSqlServer(builder.Configuration.GetConnectionString("Con"));
});

builder.Services.AddDbContext<AdminContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("con");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    //  options.UseSqlServer(builder.Configuration.GetConnectionString("Con"));
});


builder.Services.AddDbContext<FeedbackContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("con");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    //  options.UseSqlServer(builder.Configuration.GetConnectionString("Con"));
});

builder.Services.AddDbContext<CombomodelContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("con");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    //options.UseSqlServer(builder.Configuration.GetConnectionString("Con"));
});

    builder.Services.AddDbContext<DummySaleDataContext>(options => {
        var connectionString = builder.Configuration.GetConnectionString("con");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        //options.UseSqlServer(builder.Configuration.GetConnectionString("Con"));
    });

builder.Services.AddDbContext<VerifySaledataContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("con");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    //options.UseSqlServer(builder.Configuration.GetConnectionString("Con"));
});

builder.Services.AddDbContext<VerifyStatusContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("con");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    //options.UseSqlServer(builder.Configuration.GetConnectionString("Con"));
});


builder.Services.AddDbContext<ComboSaleDummyContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("con");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
   // options.UseSqlServer(builder.Configuration.GetConnectionString("Con"));
    });

builder.Services.AddDbContext<Combineforjoin>(options => {
    var connectionString = builder.Configuration.GetConnectionString("con");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    //options.UseSqlServer(builder.Configuration.GetConnectionString("Con"));
});
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(80);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Areas",
    pattern: "{Area=Admin}/{controller=DashBoard}/{action=Page}/{id?}");

app.Run();
