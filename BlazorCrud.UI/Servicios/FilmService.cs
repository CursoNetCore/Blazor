using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCrud.Model;
using BlazorCRUD.Data.Dapper.Repositories;
using BlazorCrud.UI.Data;
using BlazorCrud.UI.Interface;

namespace BlazorCrud.UI.Servicios
{

    public class FilmService : IFilmService
    {
        private readonly SqlConfiguration _configuration;
        private IFilmRepository _repo;

        public FilmService(SqlConfiguration configuration)
        {
            _configuration = configuration;
            _repo = new FilmRepository(configuration.ConnectionString);
        }

        public Task<bool> DeleteFilm(int filmId)
        {
            return _repo.DeleteFilm(filmId);
        }

        public Task<IEnumerable<Film>> GetAllFims()
        {
            return _repo.GetAllFims();
        }

        public Task<Film> GetFilmDetails(int id)
        {
            return _repo.GetFilmDetails(id);
        }

        public Task<bool> SaveFilm(Film film)
        {
            if (film.Id == 0)
                return _repo.InsertFilm(film);

            return _repo.updateFilm(film);
        }
    }
}
