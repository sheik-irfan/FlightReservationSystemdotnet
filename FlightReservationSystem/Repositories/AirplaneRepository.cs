using FlightReservationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationSystem.Repositories
{
    public class AirplaneRepository : IAirplaneRepository
    {
        private readonly MyDbContext _context;

        public AirplaneRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Airplanes>> GetAllAsync()
        {
            return await _context.Airplanes.ToListAsync();
        }

        public async Task<Airplanes?> GetByIdAsync(decimal id)
        {
            return await _context.Airplanes.FindAsync(id);
        }

        public async Task AddAsync(Airplanes airplane)
        {
            await _context.Airplanes.AddAsync(airplane);
        }

        public void Update(Airplanes airplane)
        {
            _context.Airplanes.Update(airplane);
        }

        public void Delete(Airplanes airplane)
        {
            _context.Airplanes.Remove(airplane);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
