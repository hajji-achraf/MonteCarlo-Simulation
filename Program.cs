using MonteCarlo_Simulation.Models;

var builder = WebApplication.CreateBuilder(args);

// Ajouter les services n�cessaires au container
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurer le pipeline de requ�tes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Recommand� pour la production
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Mappage des contr�leurs
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
