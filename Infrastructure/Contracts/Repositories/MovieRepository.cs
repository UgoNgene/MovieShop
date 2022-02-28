using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        protected new readonly MovieShopDbContext _db;
        public MovieRepository(MovieShopDbContext _con) : base(_con)
        {
            _db = _con;
        }

        public IEnumerable<Movie> Get30HighestRatedMovies()
        {
            DbSet<Movie> movie =  _db.Movies;
            DbSet<Review> review = _db.Reviews;

            var query = from m in movie
                        join r in review
                        on m.Id equals r.MovieId into r2
                         
                        select new
                        {
                            Movie = m,
                            Review = r2.OrderByDescending(r => r.Rating).Take(30)
                        };

            foreach (var dep in query)
            {
                Console.WriteLine($" {dep.Movie.Title}  :  {dep.Review}");
                    
            }


            return (IEnumerable<Movie>)query;
          
        }

        public IEnumerable<Movie> GetByGenre(int id)
        {
            return (IEnumerable<Movie>)_db.Set<Movie>().Find(id);
        }
    }
}
