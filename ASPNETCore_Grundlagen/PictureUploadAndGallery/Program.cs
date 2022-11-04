using PictureUploadAndGallery.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

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
AppDomain.CurrentDomain.SetData("BildVerzeichnis", app.Environment.WebRootPath);
app.UseAuthorization();



//Middleware wird aktiv, wenn im Request "imagegen" angegeben wird
app.MapWhen(context => context.Request.Path.ToString().Contains("imagegen"), subapp =>
{
    subapp.UseThumbnailGen(); //Invoke - Methode wir automatisch ausgeführt                     
});



app.MapRazorPages();

app.Run();
