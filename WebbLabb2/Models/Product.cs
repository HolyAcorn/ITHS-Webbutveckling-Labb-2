using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebbLabb2.Models;

public class Product
{
    
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonElement("productName")]
    public string ProductName { get; set; }
    [BsonElement("stock")]
    public int Stock { get; set; }

    [BsonElement("priceSEK")]
    public double PriceSEK { get; set; }

    [BsonElement("priceUSD")]
    public double PriceUSD { get; set; }

    [BsonElement("priceEUR")]
    public double PriceEUR { get; set; }
}