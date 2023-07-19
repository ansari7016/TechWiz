using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TechWizProject.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TechWizProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TechWizProjectContext") ?? throw new InvalidOperationException("Connection string 'TechWizProjectContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Registers}/{action=Index}/{id?}");

app.Run();
