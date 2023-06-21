using MicroServises.UserService.Models;
using MongoDB.Driver;

namespace MicroServises.UserService.Infrastructure
{
    public class MongoDBContext
    {
        public static void Add(User user)
        {
            var client = new MongoClient("mongodb://localhost");
            var db = client.GetDatabase("Users");
            var collection = db.GetCollection<User>("RegisteredUsers");
            collection.InsertOne(user);
        }

        public static User GetByName(string login)
        {
            var client = new MongoClient("mongodb://localhost");
            var db = client.GetDatabase("Users");
            var collection = db.GetCollection<User>("RegisteredUsers");
            return collection.Find(x => x.Login == login).FirstOrDefault();
        }
    }
}
