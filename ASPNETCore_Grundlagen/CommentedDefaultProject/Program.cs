//Seperation of  -> Aufgabenteilung 
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


// ASP.NET Core 3.1 und .NET 5 -> IHostBuilder ist unter builder.Host zu finden 
//builder.Host 


// ASP.NET Core 2.1 -> IWebHostBuilder 
//builder.WebHost



// Add services to the container.
builder.Services.AddRazorPages();

//für MVC
//builder.Services.AddControllersWithViews();

//für MVC und RazorPage (AddRazorPages + AddControllersWithViews)
//builder.Services.AddMvc(); 


//Nach builder.Build() kann der IOC Container nicht mehr initiiert werden 
WebApplication app = builder.Build();


//Wie verwenden wir, welche Dienste 

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
