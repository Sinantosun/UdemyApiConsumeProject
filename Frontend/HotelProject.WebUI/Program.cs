using FluentValidation;
using FluentValidation.AspNetCore;
using HotelProject.DataAccsessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.ValidatonRules.GuestRules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddHttpClient();



builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddControllersWithViews(opts =>
{
    opts.Filters.Add(new AuthorizeFilter());
});

builder.Services.ConfigureApplicationCookie(options => { options.LoginPath = "/Login/Index"; options.AccessDeniedPath = "/ErrorPages/Page403"; options.Cookie.Name = Guid.NewGuid().ToString(); options.ExpireTimeSpan = TimeSpan.FromMinutes(1); options.SlidingExpiration = true; options.LogoutPath = "/Login/LogOut/"; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
