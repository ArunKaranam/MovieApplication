using MovieApplication.Data.Base;
using MovieApplication.Data.ViewModels;
using MovieApplication.Models;

namespace MovieApplication.Data.Services
{
    public interface IMoviesService :IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownValues();

        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);

    }
}
