using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorCrud.Model;

namespace BlazorCrud.UI.Interface
{
    public interface IFilmService
    {
        Task<IEnumerable<Film>> GetAllFims();
        Task<Film> GetFilmDetails(int id);
        Task<bool> SaveFilm(Film film);
        Task<bool> DeleteFilm(int filmId);
    }
}
