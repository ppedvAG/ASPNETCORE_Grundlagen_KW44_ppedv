using ConfigurationSamples.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(); //Werden grundlegende Dienst in den IOC Container hinzugefügt, die in Razor Pages relevant sind -> Logging, Configurations

//1.) Wir binden eine weitere Konfigurationsquelle hinzu

//IConfiguration wird erweitert 
//https://learn.microsoft.com/de-de/aspnet/core/fundamentals/configuration/options?view=aspnetcore-6.0
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    //Optionale Einstellung 
    config.AddJsonFile("GameSettings.json", true, true);
});

//Mappen die Klasse GameSettings mit den Konfigurations-Abschnitt "GameSettings" 
builder.Services.Configure<GameSettings>(builder.Configuration.GetSection("GameSettings"));



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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
