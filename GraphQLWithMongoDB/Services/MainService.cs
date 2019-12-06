using GraphQLWithMongoDB.models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWithMongoDB.Services
{
    public class MainService
    {
        private readonly IMongoCollection<userModel> _user;
        private readonly IMongoCollection<companyModel> _company;

        public MainService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _user = database.GetCollection<userModel>(settings.UserCollectionName);
            _company = database.GetCollection<companyModel>(settings.CompanyCollectionName);
        }
        public List<userModel> GetAllUser() =>
            _user.Find(user => true).ToList();
        public userModel GetUserByID(string id) =>
            _user.Find(user => user._id == id).FirstOrDefault();

        public List<companyModel> GetAllCompany() =>
            _company.Find(company => true).ToList();
        public companyModel GetCompanyByID(string id) =>
            _company.Find(company => company._id == id).FirstOrDefault();

    }
}

