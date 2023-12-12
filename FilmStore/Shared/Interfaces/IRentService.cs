using Shared.Models;

namespace Shared.Interfaces
{
    public interface IRentService
    {
        IEnumerable<RentedFilmDto> GetAllRents();
        RentedFilmDto? GetSingleRent(string id);
        void ReturnFilm(string id);
        void RefreshData();
    }
}