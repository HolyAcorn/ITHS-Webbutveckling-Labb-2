
using WebbLabb2.Data;
using WebbLabb2.Models;

namespace WebbLabb2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            MongoCRUD db = new MongoCRUD("labb3Store_db");

            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapGet("/api/products", async () =>
            {
                var testDB = await db.GetProducts();
                return Results.Ok(testDB);
            });

            app.MapGet("/api/product", async (string id) =>
            {
                var Product = await db.GetProductById(id);
                return Results.Ok(Product);
            });

            app.MapPost("/api/product", async (Product Product) =>
            {
                await db.AddProduct(Product);
                return Results.Ok($"Product {Product.ProductName} added");
            });

            app.MapPut("/api/product", async (string id, Product Product) =>
            {
                await db.UpdateProduct(id, Product);
                return Results.Ok("Product updated");
            });
            
            app.MapDelete("api/product", async (string id) =>
            {
                await db.RemoveProductById(id);
                return Results.Ok("Product removed");
            });
            
            app.Run();
        }
    }
}
