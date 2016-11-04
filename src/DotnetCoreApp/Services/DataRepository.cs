using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotnetCoreApp.Entities;
using DotnetCoreApp.Helper;

namespace DotnetCoreApp.Services
{
    public class DataRepository : IDataRepository
    {
        private readonly DotnetCoreAppDbContext _context;
        private readonly CacheHelper _cacheHelper;
        private const string ALL_MOVIES = "allMovies";

        public DataRepository(DotnetCoreAppDbContext context, CacheHelper cacheHelper)
        {
            _context = context;
            _cacheHelper = cacheHelper;
        }

      
        public IQueryable<MovieData> GetAll()
        {

            var allMovies = _cacheHelper.GetFromCache<IQueryable<MovieData>>(ALL_MOVIES);

            if (allMovies == null)
            {

                allMovies = _context.Movies.ToList().AsQueryable();
                _cacheHelper.SaveTocache(ALL_MOVIES, allMovies, DateTime.Now.AddHours(24));
            }

            return allMovies;
        }

        public MovieData Get(int id)
        {
            try
            {
                var allMovies = GetAll();
                var movie = allMovies.FirstOrDefault(r => r.MovieId == id);
                if (movie == null)
                {
                    movie = _context.Movies.FirstOrDefault(x => x.MovieId == id);
                    if (movie != null)
                        return movie;
                    return null;
                }
                return movie;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public MovieData Create(MovieData newMovie)
        {
            _context.Add(newMovie);
            _context.SaveChanges();
            _cacheHelper.RemoveFromCache(ALL_MOVIES);
            return newMovie;
        }

        public bool Update(MovieData movie)
        {
            throw new NotImplementedException();
        }
    }
}
