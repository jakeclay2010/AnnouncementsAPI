using Announcements.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AnnouncementsAPI",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Jacob Claytor",
            Email = "jacob.c.claytor@gmail.com",
            Url = new Uri("https://github.com/jakeclay2010/AnnouncementsAPI")
        },
    });
});
builder.Services.AddScoped<IAnnouncementRepository, AnnouncementLocalStorage>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "AnnouncementsAPI V1");
    c.RoutePrefix = "swagger";
});

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();