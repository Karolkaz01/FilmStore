using Shared.Models;

namespace Shared.Interfaces
{
    public interface IClientService
    {
        void DeleteClient(string id);
        IEnumerable<ClientDto> GetAllClients();
        ClientDto? GetSingleClient(string id);
        void AddOneRentedFilm(string clientId);
        void RemoveOneRentedFilm(string clientId);
        void RefreshData();
    }
}