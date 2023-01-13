using Microsoft.EntityFrameworkCore;
using MovieApplication.Data.Base;
using MovieApplication.Models;

namespace MovieApplication.Data.Services
{
    public class ActorsService :EntityBaseRepository<Actor>, IActorsService
    {
        public ActorsService(AppDBContext context) : base(context) { }
       
    }
}
