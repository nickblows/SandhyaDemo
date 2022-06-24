using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using SandhyaDemo.DbModels;
using Microsoft.Extensions.DependencyInjection;
using SandhyaDemo.Data;

//Create some data
DataGenerator.Initialize();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FruitContext>(options =>
    options.UseInMemoryDatabase(databaseName: "InMemoryFruitbowl"));


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Fruits}/{action=Index}/{id?}");

app.Run();


public class DataGenerator
{
    public static void Initialize()
    {
        var options = new DbContextOptionsBuilder<FruitContext>()
         .UseInMemoryDatabase(databaseName: "InMemoryFruitbowl")
         .Options;

        using (var context = new FruitContext(options))
        {
            // Look for any board games.
            if (context.Fruit.Any())
            {
                return;   // Data was already seeded
            }

            context.Fruit.AddRange(
                new Fruit
                {                   
                    Id = 1,
                    Name = "Orange",
                    Type = "A"
                },
                new Fruit
                {
                    Id = 2,
                    Name = "Mango",
                    Type = "B"
                },
                new Fruit
                {
                    Id = 3,
                    Name = "Apple",
                    Type = "C"
                },
                new Fruit
                {
                    Id = 4,
                    Name = "Pear",
                    Type = "D"
                },
                new Fruit
                {
                    Id = 5,
                    Name = "Kiwi",
                    Type = "A"
                });

            context.SaveChanges();
        }
    }
}