
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

            MongoCRUD db = new MongoCRUD("MyDB");

            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapGet("/api/authors", async () =>
            {
                var testDB = await db.GetAuthors();
                return Results.Ok(testDB);
            });

            app.MapGet("/api/author", async (string id) =>
            {
                var author = await db.GetAuthorById(id);
                return Results.Ok(author);
            });

            app.MapPost("/api/author", async (Author author) =>
            {
                await db.AddAuthor(author);
                return Results.Ok($"Author {author.FirstName} added");
            });

            app.MapPut("/api/author", async (string id, Author author) =>
            {
                await db.UpdateAuthor(id, author);
                return Results.Ok("Author updated");
            });
            
            app.MapDelete("api/author", async (string id) =>
            {
                await db.RemoveAuthorById(id);
                return Results.Ok("Author removed");
            });
            
            app.Run();
        }
    }
}
