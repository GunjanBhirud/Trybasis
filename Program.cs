using Microsoft.EntityFrameworkCore;
using Realestate.Areas.Admin.Models;
using Realestate.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();


builder.Services.AddDbContext<Signupdatacontext>(options => { 
    options.UseSqlServer(builder.Configuration.GetConnectionString("Con")); 
});

builder.Services.AddDbContext<SaleHomeContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("Con"));
});


builder.Services.AddDbContext<BuyHomeContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("Con"));
});

builder.Services.AddDbContext<AdminContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("Con"));
});


builder.Services.AddDbContext<FeedbackContext>(options => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("Con"));
});

builder.Services.AddDbContext<CombomodelContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("Con"));
});

    builder.Services.AddDbContext<DummySaleDataContext>(options => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("Con"));
    });

builder.Services.AddDbContext<VerifySaledataContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("Con"));
});

builder.Services.AddDbContext<VerifyStatusContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("Con"));
});


builder.Services.AddDbContext<ComboSaleDummyContext>(options => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("Con"));
    });

builder.Services.AddDbContext<Combineforjoin>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("Con"));
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
