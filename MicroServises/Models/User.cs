using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MicroServises.UserService.Models
{
    public class User
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId MyProperty { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}
