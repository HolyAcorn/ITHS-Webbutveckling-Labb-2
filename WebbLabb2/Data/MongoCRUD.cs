using Azure.Identity;
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
        var mongoConnection = Environment.GetEnvironmentVariable("productConnection");
        var client = new MongoClient(mongoConnection);
        db = client.GetDatabase(database);
    }

    public async Task<List<Product>> GetProducts()
    {
        var collection = db.GetCollection<Product>("products");
        var products = collection.AsQueryable().ToList();
        return products;
    }

    public async Task<Product> GetProductById(string id)
    {
        var collection = db.GetCollection<Product>("products");
        var product = await collection.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
        return product;
    }

    public async Task AddProduct(Product product)
    {
        var collection = db.GetCollection<Product>("products");
        await collection.InsertOneAsync(product);
    }

    public async Task RemoveProductById(string id)
    {
        var collection = db.GetCollection<Product>("products");
        var products = collection.AsQueryable().ToList();
        await collection.DeleteOneAsync(product => product.Id == id);
    }

    public async Task UpdateProduct(string id, Product product)
    {
        
        var collection = db.GetCollection<Product>("products");
        await collection.ReplaceOneAsync(x => x.Id == id, product);
        
    }
}