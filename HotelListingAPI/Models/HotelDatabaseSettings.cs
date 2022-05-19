namespace HotelListingAPI.Models
{
    public class HotelDatabaseSettings
    {
        public string DbConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string HotelCollectionName { get; set; } = null!;
    }
}
