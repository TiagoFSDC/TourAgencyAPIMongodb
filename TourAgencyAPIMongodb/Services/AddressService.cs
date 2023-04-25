using MongoDB.Bson;
using MongoDB.Driver;
using TourAgencyAPIMongodb.Config;
using TourAgencyAPIMongodb.Models;

namespace TourAgencyAPIMongodb.Services
{
    public class AddressService
    {
        private readonly IMongoCollection<Address> _address;
        private readonly IMongoCollection<City> _city;

        public AddressService(ITourAgencySettings settings)
        {
            var Address = new MongoClient(settings.ConnectionString);
            var database = Address.GetDatabase(settings.DatabaseName);
            _address = database.GetCollection<Address>(settings.AddressCollectionName);
            _city = database.GetCollection<City>(settings.CityCollectionName);
        }

        public List<Address> Get() => _address.Find(c => true).ToList();

        public Address Get(string Id) => _address.Find<Address>(c => c.Id == Id).FirstOrDefault();

        public Address Create(Address address)
        {
            //if(!address.city.Description.Equals(_city.Find(x => x.Description == address.city.Description)))
            //{
            //    _city.InsertOne(address.city);
            //    //var c = _city.Find(x => x.Description == address.city.Description).FirstOrDefault();
            //    //address.city = c;
            //}

            address.city = _city.Find(x => x.Id == address.city.Id).FirstOrDefault();

            _address.InsertOne(address);
            return address;
        }

        public void Update(string id, Address address) => _address.ReplaceOne(c => c.Id == id, address);

        public void Delete(string id) => _address.DeleteOne(c => c.Id == id);
        public void Delete(Address address) => _address.DeleteOne(c => c.Id == address.Id);
    }
}
