using HotelListingAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HotelListingAPI.Services
{
    public class HotelService
    {
        private readonly IMongoCollection<Hotel> _hotelCollection;
        private readonly ILogger<HotelService> _logger;

        public HotelService(IOptions<HotelDatabaseSettings> options, ILogger<HotelService> logger)
        {
            var mongoClient = new MongoClient(options.Value.DbConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);
            _hotelCollection = mongoDatabase.GetCollection<Hotel>(options.Value.HotelCollectionName);
            _logger = logger;
            _logger.LogInformation("HotelService initialized...");
        }

        public Task CreateHotel(Hotel hotel)
        {
            return _hotelCollection.InsertOneAsync(hotel);
        }

        public async Task<List<Hotel>> GetAll()
        {
            var result = await _hotelCollection.FindAsync(_ => true);
            return result.ToList();
        }

        public async Task<List<Hotel>> GetAsync() =>
            await _hotelCollection.Find(_ => true).ToListAsync();

        public async Task<Hotel?> GetById(string id) =>
            await _hotelCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }
}
