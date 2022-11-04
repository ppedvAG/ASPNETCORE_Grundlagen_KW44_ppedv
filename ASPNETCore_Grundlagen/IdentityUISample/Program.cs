using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IdentityUISample.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IdentityUISampleContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityUISampleContextConnection' not found.");

builder.Services.AddDbContext<IdentityUISampleContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<IdentityUISampleContext>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAuthentication();

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

//Reihenfolge ist hier besonders wichtig-> UseAuthentication VOR UseAuthorization
app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();

app.Run();
