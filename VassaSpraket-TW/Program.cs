using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using VassaSpraket_TW.Data;
using VassaSpraket_TW.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<VassaSpraket_TWDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TeacherDatabase"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("*") // Angular app's URL
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddScoped<IChaptersRepository, ChaptersRepository>();
builder.Services.AddScoped<IPageTemplateRepository, PageTemplateRepository>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
   
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

}
else{
 var dbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<VassaSpraket_TWDbContext>();

// Ensure the database is created
    dbContext.Database.Migrate();
}

app.UseCors("AllowSpecificOrigin");

if (app.Environment.IsDevelopment())
{
    var folder = builder.Configuration.GetSection("Path:Teacher_local").Value;
    if (!Directory.Exists(folder))
    { Directory.CreateDirectory(folder); }


    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(folder),
        RequestPath = new PathString(@"/" + builder.Configuration.GetSection("Path:TeacherUrl_local").Value)
    });

    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();



app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
});

app.MapFallbackToFile("index.html"); ;

app.Run();
