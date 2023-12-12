using MongoDB.Bson.Serialization.Attributes;
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
    public class ClientService : IClientService
    {
        private IMongoClient _dbContext { get; set; }
        private IEnumerable<ClientDto> clients;

        public ClientService()
        {
            var context = new FilmStoreDBContext();
            _dbContext = context.GetMongoDbContext();
            var collection = _dbContext.GetDatabase("FilmStoreDB").GetCollection<ClientDto>("Clients");
            var filters = Builders<ClientDto>.Filter.Empty;
            clients = collection.Find(filters).ToList();
        }

        public IEnumerable<ClientDto> GetAllClients()
        {
            return clients;
        }

        public ClientDto? GetSingleClient(string id)
        {
            return clients.FirstOrDefault(f => f.Id == id);
        }

        public void DeleteClient(string id)
        {
            var collection = _dbContext.GetDatabase("FilmStoreDB").GetCollection<ClientDto>("Clients");
            var filters = Builders<ClientDto>.Filter.Eq(r => r.Id, id);
            collection.DeleteOne(filters);
            RefreshData();
        }

        public void AddOneRentedFilm(string clientId)
        {
            var collection = _dbContext.GetDatabase("FilmStoreDB").GetCollection<ClientDto>("Clients");
            var filters = Builders<ClientDto>.Filter.Eq(c => c.Id, clientId);
            var updates = Builders<ClientDto>.Update.Inc(c => c.RentedFilms,1);
            collection.UpdateOne(filters, updates);
            RefreshData();
        }

        public void RemoveOneRentedFilm(string clientId)
        {
            var collection = _dbContext.GetDatabase("FilmStoreDB").GetCollection<ClientDto>("Clients");
            var filters = Builders<ClientDto>.Filter.Eq(c => c.Id, clientId);
            var updates = Builders<ClientDto>.Update.Inc(c => c.RentedFilms, -1);
            collection.UpdateOne(filters, updates);
            RefreshData();
        }

        public void RefreshData()
        {
            var collection = _dbContext.GetDatabase("FilmStoreDB").GetCollection<ClientDto>("Clients");
            var filters = Builders<ClientDto>.Filter.Empty;
            clients = collection.Find(filters).ToList();
        }
    }
}
