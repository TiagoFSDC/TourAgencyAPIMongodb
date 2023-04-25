namespace TourAgencyAPIMongodb.Config
{
    public interface ITourAgencySettings
    {
        public string CityCollectionName { get; set; }
        public string AddressCollectionName { get; set; }
        public string CustomerCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
