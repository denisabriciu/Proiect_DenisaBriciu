using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proiect_DenisaBriciu.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Cars");
    options.Conventions.AuthorizeFolder("/Brands");
    options.Conventions.AuthorizeFolder("/Members");
    options.Conventions.AuthorizeFolder("/Categories");
    

});

builder.Services.AddDbContext<Proiect_DenisaBriciuContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Proiect_DenisaBriciuContext") ?? throw new InvalidOperationException("Connection string 'Proiect_DenisaBriciuContext' not found.")));



builder.Services.AddDbContext<LibraryIdentityContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("Proiect_DenisaBriciuContext") ?? throw new InvalidOperationException("Connection string 'Proiect_DenisaBriciuContext' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options =>options.SignIn.RequireConfirmedAccount = true)
 .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
