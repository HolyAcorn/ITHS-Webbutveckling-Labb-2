using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using WebbLabb2.Models;

namespace WebbLabb2.Data;

public class MongoCRUD
{
    private IMongoDatabase db;

    public MongoCRUD(string database)
    {
        var client = new MongoClient();
        db = client.GetDatabase(database);
    }

    public async Task<List<Author>> GetAuthors()
    {
        var collection = db.GetCollection<Author>("Authors");
        var authors = collection.AsQueryable().ToList();
        return authors;
    }

    public async Task<Author> GetAuthorById(string id)
    {
        var collection = db.GetCollection<Author>("Authors");
        var author = await collection.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
        return author;
    }

    public async Task AddAuthor(Author author)
    {
        var collection = db.GetCollection<Author>("Authors");
        await collection.InsertOneAsync(author);
    }

    public async Task RemoveAuthorById(string id)
    {
        var collection = db.GetCollection<Author>("Authors");
        var authors = collection.AsQueryable().ToList();
        await collection.DeleteOneAsync(author => author.Id == id);
    }

    public async Task UpdateAuthor(string id, Author author)
    {
        
        var collection = db.GetCollection<Author>("Authors");
        await collection.ReplaceOneAsync(x => x.Id == id, author);
        
    }
}