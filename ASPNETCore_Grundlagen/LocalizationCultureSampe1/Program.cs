using LocalizationCultureSampe1.Services;
using Microsoft.Extensions.Options;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddViewLocalization();;




//Werden Localizaion hinzufügen 
builder.Services.AddLocalization(options => options.ResourcesPath = "Ressources");

builder.Services.AddSingleton<CommonLocalizationService>();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    CultureInfo[] supportedCultures = new[]
    {
        new CultureInfo("en"),
        new CultureInfo("de"),
        new CultureInfo("fr"),
        new CultureInfo("es"),
        new CultureInfo("ru"),
        new CultureInfo("ja"),
        new CultureInfo("ar"),
        new CultureInfo("zh"),
        new CultureInfo("en-GB")
    };

    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-GB");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

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

RequestLocalizationOptions localizationOptions  = app.Services.GetService<IOptions<RequestLocalizationOptions>>().Value;
app.UseRequestLocalization(localizationOptions);


app.UseAuthorization();

app.MapRazorPages();

app.Run();
