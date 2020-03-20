using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BlazorCrud.Model;
namespace BlazorCRUD.Data.Dapper.Repositories
{
    public interface IFilmRepository
    {
        Task<IEnumerable<Film>> GetAllFims();
        Task<Film> GetFilmDetails(int id);
        Task<bool> InsertFilm(Film film);
        Task<bool> updateFilm(Film film);
        Task<bool> DeleteFilm(int filmId);

    }
}
