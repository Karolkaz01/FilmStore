using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Shared.Interfaces;
using Shared.Models;

namespace Shared.Services
{
    public class RentService : IRentService
    {
        private IMongoClient _dbContext { get; set; }
        private IEnumerable<RentedFilmDto> _rentsList;

        public RentService()
        {
            var context = new FilmStoreDBContext();
            _dbContext = context.GetMongoDbContext();
            var collection = _dbContext.GetDatabase("FilmStoreDB").GetCollection<RentedFilmDto>("Rents");
            var filters = Builders<RentedFilmDto>.Filter.Empty;
            _rentsList = collection.Find(filters).ToList();
        }

        public IEnumerable<RentedFilmDto> GetAllRents()
        {
            return _rentsList;
        }

        public RentedFilmDto? GetSingleRent(string id)
        {
            return _rentsList.FirstOrDefault(r => r.Id == id);
        }

        public void ReturnFilm(string id)
        {
            var collection = _dbContext.GetDatabase("FilmStoreDB").GetCollection<RentedFilmDto>("Rents");
            var filters = Builders<RentedFilmDto>.Filter.Eq(r => r.Id ,id);
            var updates = Builders<RentedFilmDto>.Update.Set(r => r.ReturnDate, DateTime.Now);
            collection.UpdateOne(filters, updates);
            RefreshData();
        }
        
        public void RefreshData()
        {
            var collection = _dbContext.GetDatabase("FilmStoreDB").GetCollection<RentedFilmDto>("Rents");
            var filters = Builders<RentedFilmDto>.Filter.Empty;
            _rentsList = collection.Find(filters).ToList();
        }
    }
}
