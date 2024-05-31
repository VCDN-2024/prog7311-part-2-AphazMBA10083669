using AgriEnergy_PROG7311POE2_ST10083669.Models;

//Stack Overflow. (n.d.). ASP.NET Core This localhost page can’t be found.
//[online] Available at: https://stackoverflow.com/questions/43468715/asp-net-core-this-localhost-page-can-t-be-found
//[Accessed 31 May 2024].

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AgriEnergy_PROG7311POE2_ST10083669.Models.AgriEnergyConnectPlatformContext>();

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
