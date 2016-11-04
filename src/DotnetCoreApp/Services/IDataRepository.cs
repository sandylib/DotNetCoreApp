using System.Linq;
using DotnetCoreApp.Entities;

namespace DotnetCoreApp.Services
{
    public interface IDataRepository
    {

        IQueryable<MovieData> GetAll();
        MovieData Get(int id);
        MovieData Create(MovieData newMovie);
        bool Update(MovieData movie);
        //bool DoesTitleAlreadyExist(string title);
    }
}