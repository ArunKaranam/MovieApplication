using Microsoft.EntityFrameworkCore;
using MovieApplication.Data.Base;
using MovieApplication.Models;

namespace MovieApplication.Data.Services
{
    public class ActorsService :EntityBaseRepository<Actor>, IActorsService
    {
        private readonly AppDBContext _context;
        public ActorsService(AppDBContext context) : base(context) { }
       
    }
}
