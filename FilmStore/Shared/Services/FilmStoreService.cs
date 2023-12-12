using MongoDB.Driver;
using Shared.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services
{
    public class FilmStoreService : IFilmStoreService
    {
        private IMongoClient _dbContext { get; set; }
        private IEnumerable<FilmDto> filmList;

        public FilmStoreService()
        {
            var context = new FilmStoreDBContext();
            _dbContext = context.GetMongoDbContext();
            var collection = _dbContext.GetDatabase("FilmStoreDB").GetCollection<FilmDto>("Films");
            var filters = Builders<FilmDto>.Filter.Empty;
            filmList = collection.Find(filters).ToList();
        }

        public IEnumerable<FilmDto> GetAllFilms()
        {
            return filmList;
        }

        public FilmDto? GetSingleFilm(string id)
        {
            return filmList.FirstOrDefault(f => f.Id == id);
        }

        public void RentFilm(string id)
        {
            var collection = _dbContext.GetDatabase("FilmStoreDB").GetCollection<FilmDto>("Films");
            var filters = Builders<FilmDto>.Filter.Eq(f => f.Id, id);
            var updates = Builders<FilmDto>.Update.Set(f => f.IsInStock, false);
            collection.UpdateOne(filters, updates);
            RefreshData();
        }

        public void ReturnFilm(string id)
        {
            var collection = _dbContext.GetDatabase("FilmStoreDB").GetCollection<FilmDto>("Films");
            var filters = Builders<FilmDto>.Filter.Eq(f => f.Id, id);
            var updates = Builders<FilmDto>.Update.Set(f => f.IsInStock, true);
            collection.UpdateOne(filters, updates);
            RefreshData();
        }

        public void DeleteFilm(string id)
        {
            var collection = _dbContext.GetDatabase("FilmStoreDB").GetCollection<ClientDto>("Films");
            var filters = Builders<ClientDto>.Filter.Eq(r => r.Id, id);
            collection.DeleteOne(filters);
            RefreshData();
        }

        public void RefreshData()
        {
            var collection = _dbContext.GetDatabase("FilmStoreDB").GetCollection<FilmDto>("Films");
            var filters = Builders<FilmDto>.Filter.Empty;
            filmList = collection.Find(filters).ToList();
        }
    }
}
