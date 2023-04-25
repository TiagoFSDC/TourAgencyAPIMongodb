using System.Net;
using MongoDB.Driver;
using TourAgencyAPIMongodb.Config;
using TourAgencyAPIMongodb.Models;

namespace TourAgencyAPIMongodb.Services
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _customer;
        private readonly IMongoCollection<Address> _address;

        public CustomerService(ITourAgencySettings settings)
        {
            var customer = new MongoClient(settings.ConnectionString);
            var database = customer.GetDatabase(settings.DatabaseName);
            _customer = database.GetCollection<Customer>(settings.CustomerCollectionName);
            _address = database.GetCollection<Address>(settings.AddressCollectionName);
        }

        public List<Customer> Get() => _customer.Find(c => true).ToList();

        public Customer Get(string Id) => _customer.Find<Customer>(c => c.Id == Id).FirstOrDefault();

        public Customer Create(Customer customer)
        {
            _customer.InsertOne(customer);
            return customer;
        }

        public void Update(string id, Customer customer) => _customer.ReplaceOne(c => c.Id == id, customer);

        public void Delete(string id) => _customer.DeleteOne(c => c.Id == id);
        public void Delete(Customer customer) => _customer.DeleteOne(c => c.Id == customer.Id);
    }
}
