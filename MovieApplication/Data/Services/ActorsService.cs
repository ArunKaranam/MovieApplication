using Microsoft.EntityFrameworkCore;
using MovieApplication.Models;

namespace MovieApplication.Data.Services
{
    public class ActorsService : IActorsService
    {
        private AppDBContext _context;
        public ActorsService(AppDBContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result=await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);
            _context.Actors.Remove(result);
            await _context.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var result = await _context.Actors.ToListAsync();
            return result;
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);
            return result;
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            _context.Update(newActor);
            await _context.SaveChangesAsync();
            return newActor;
        }
    }
}
