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
        private IEnumerable<FilmDto> _filmList;

        public FilmStoreService()
        {
            var context = new FilmStoreDBContext();
            _dbContext = context.GetMongoDbContext();
            var collection = _dbContext.GetDatabase("FilmStoreDB").GetCollection<FilmDto>("Films");
            var filters = Builders<FilmDto>.Filter.Empty;
            _filmList = collection.Find(filters).ToList();
        }

        public IEnumerable<FilmDto> GetAllFilms()
        {
            return _filmList;
        }

        public FilmDto? GetSingleFilm(string id)
        {
            return _filmList.FirstOrDefault(f => f.Id == id);
        }

        public void RefreshData()
        {
            var collection = _dbContext.GetDatabase("FilmStoreDB").GetCollection<FilmDto>("Films");
            var filters = Builders<FilmDto>.Filter.Empty;
            _filmList = collection.Find(filters).ToList();
        }
    }
}
