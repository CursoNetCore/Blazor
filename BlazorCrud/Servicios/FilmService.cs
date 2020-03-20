using BlazorCrud.Interfaces;
using BlazorCrud.Model;
using BlazorCrud.Data;
using BlazorCRUD.Data.Dapper.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCrud.Servicios
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
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Film>> GetAllFims()
        {
            throw new NotImplementedException();
        }

        public Task<Film> GetFilmDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveFilm(Film film)
        {
            if (film.Id == 0)
                return _repo.InsertFilm(film);

            return _repo.updateFilm(film);
        }
    }
}
