using BlazorCrud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCrud.Interfaces
{
    public interface IFilmService
    {
        Task<IEnumerable<Film>> GetAllFims();
        Task<Film> GetFilmDetails(int id);
        Task<bool> SaveFilm(Film film);
        Task<bool> DeleteFilm(int filmId);

    }
}
