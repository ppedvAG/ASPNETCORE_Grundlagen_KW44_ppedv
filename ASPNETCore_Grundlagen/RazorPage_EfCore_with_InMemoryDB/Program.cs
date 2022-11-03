using Microsoft.EntityFrameworkCore;
using RazorPage_EfCore_with_InMemoryDB.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


//Internt wird EF Core als AddScoped hinzugefügt

builder.Services.AddDbContext<MovieDbContext>(options =>
{
    //Optionen erweitern sich mit weiteren EFCore-Packages

    //options.UseInMemoryDatabase("MovieDatagase");
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieDb"));

    //Lazy Loading -> wenn man EfCore.Proxies intstalliert, erweitert sich
    //options.UseLazyLoadingProxies
});

var app = builder.Build();


//früheste Zugriff auf IOC-Container 

//.NET 2.1

using (IServiceScope scope = app.Services.CreateScope())
{
    MovieDbContext movieDbContext = scope.ServiceProvider.GetRequiredService<MovieDbContext>();

    DataSeeder.SeedMoviesInDB(movieDbContext);
}

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
