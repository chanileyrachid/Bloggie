using Bloggie.WEB.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Inject the DbContext inside the services of our application
//After use tools > nuget package manager; to  create our database
/*
 commands
- Add-Migration "Name of Migration"
- update-Database

after the command a migration folder will be created and a databas will be created in our server
 */
builder.Services.AddDbContext<BloggieDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("BloggieDbConnectionString")));

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
