using MongoDB.Driver;
using TourAgencyAPIMongodb.Config;
using TourAgencyAPIMongodb.Models;

namespace TourAgencyAPIMongodb.Services
{
    public class CityService
    {
        private readonly IMongoCollection<City> _city;

        public CityService(ITourAgencySettings settings)
        {
            var city = new MongoClient(settings.ConnectionString);
            var database = city.GetDatabase(settings.DatabaseName);
            _city = database.GetCollection<City>(settings.CityCollectionName);
        }

        public List<City> Get() => _city.Find(c => true).ToList();

        public City Get(string Id) => _city.Find<City>(c => c.Id == Id).FirstOrDefault();

        public City Create(City city)
        {
            _city.InsertOne(city);
            return city;
        }

        public void Update(string id, City city) => _city.ReplaceOne(c => c.Id == id, city);

        public void Delete(string id) => _city.DeleteOne(c => c.Id == id);
        public void Delete(City city) => _city.DeleteOne(c => c.Id == city.Id);
    }
}
