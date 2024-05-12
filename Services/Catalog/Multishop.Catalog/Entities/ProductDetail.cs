using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Multishop.Catalog.Entities;

public class ProductDetail
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ProductDetailId { get; set; }
    
    public string ProductDescription { get; set; }
    
    public string ProductInfo { get; set; }

    public string ProductId { get; set; }
    [BsonIgnore]
    private Product Product { get; set; }
    
}