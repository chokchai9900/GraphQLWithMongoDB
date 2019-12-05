using GraphQLWithMongoDB.models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWithMongoDB.Services
{
    public class UserService
    {
        private readonly IMongoCollection<userModel> _user;

        public UserService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _user = database.GetCollection<userModel>(settings.CollectionName);
        }
        public List<userModel> GetAllUser() =>
            _user.Find(user => true).ToList();
        public userModel GetUserByID(string id) =>
            _user.Find(user => user._id == id).FirstOrDefault();
        public List<userModel> GetUserByActive(bool userIsActive) =>
            _user.Find(user => user.isActive == userIsActive).ToList();

    }
}

