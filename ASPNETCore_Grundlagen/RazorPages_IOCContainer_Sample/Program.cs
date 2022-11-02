using RazorPages_IOCContainer_Sample.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<ITimeService, TimeService>();

WebApplication app = builder.Build();

#region Frühster Zugriff
//.NET 2.1 
using (IServiceScope scope = app.Services.CreateScope())
{
    ITimeService? timeService = scope.ServiceProvider.GetService<ITimeService>();
    TimeService timeService2 = scope.ServiceProvider.GetRequiredService<TimeService>(); 
}

ITimeService? timeService3 = app.Services.GetService<ITimeService>();
ITimeService timeService34 = app.Services.GetRequiredService<ITimeService>();
#endregion


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
