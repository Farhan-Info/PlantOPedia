using Microsoft.EntityFrameworkCore;
using PlantOPedia.Data;
using PlantOPedia.Engine;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddCors(option =>
{
    option.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

                      });

});
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PlantdbContext>(opts => opts.UseSqlServer(configuration["ConnectionStrings:PlantDB"]));
builder.Services.AddControllers();
builder.Services.AddTransient<ILoginEngine, LoginEngine>();
builder.Services.AddTransient<IProductEngine, ProductEngine>();
builder.Services.AddTransient<IOrderEngine, OrderEngine>();
builder.Services.AddTransient<ICartEngine, CartEngine>();
builder.Services.AddTransient<IUserEngine, UserEngine>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();


