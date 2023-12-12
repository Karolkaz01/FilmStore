using Shared.Models;
using Shared.Services;

namespace Shared.Interfaces
{
    public interface IFilmStoreService
    {
        IEnumerable<FilmDto> GetAllFilms();
        FilmDto? GetSingleFilm(string id);
        void RentFilm(string id);
        void ReturnFilm(string id);
        void DeleteFilm(string id);
        void RefreshData();
    }
}