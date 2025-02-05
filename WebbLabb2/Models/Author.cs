using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebbLabb2.Models;

public class Author
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Birth { get; set; }
    public int Death { get; set; }
    public string[] Books { get; set; }
    public string Gender { get; set; }
}