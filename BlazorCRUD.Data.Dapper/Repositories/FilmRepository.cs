using BlazorCrud.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Data.Dapper.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private string ConnectionString;

        public FilmRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected SqlConnection dbConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public async Task<bool> DeleteFilm(int filmId)
        {
            try
            {
                var db = dbConnection();
                var query = @"DELETE FROM dbo.Films WHERE Id=@Id";
                var result =  await db.ExecuteAsync(query.ToString(), new { Id = filmId });
                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Film>> GetAllFims()
        {
            var db = dbConnection();
            var sql = @"SELECT Id, Title, Director, ReleaseDate FROM dbo.Films";
            try
            {
                return await db.QueryAsync<Film>(sql.ToString(), new { });
            }
            catch(Exception)
            {
                return null;
            }
        }

        public async Task<Film> GetFilmDetails(int id)
        {
            try
            {
                var db = dbConnection();
                var query = @"SELECT Id, Title, Director, ReleaseDate FROM dbo.Films WHERE Id=@Id";
                return await db.QueryFirstOrDefaultAsync<Film>(query.ToString(), new { Id = id });
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> InsertFilm(Film film)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO Films (Title, Director, ReleaseDate) 
                        VALUES (@Title, @Director, @ReleaseDate)";
            try {  
            var result = await db.ExecuteAsync(sql.ToString(), new { film.Title, film.Director, film.ReleaseDate });
            return result > 0;
            }catch(Exception e)
            {

                return false;
            }
        }

        public async Task<bool> updateFilm(Film film)
        {
            var db = dbConnection();
            var sql = @"UPDATE Films SET 
                            Title = @Title,  
                            Director = @Director, 
                            ReleaseDate= @ReleaseDate 
                        WHERE Id=@Id";
            try
            {
                var result = await db.ExecuteAsync(sql.ToString(), new { film.Title, film.Director, film.ReleaseDate, Id=film.Id });
                return result > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
