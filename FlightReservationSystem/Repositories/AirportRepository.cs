using FlightReservationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightReservationSystem.Repositories
{
    public class AirportRepository : IAirportRepository
    {
        private readonly FlightReservation _context;

        public AirportRepository(FlightReservation context)
        {
            _context = context;
        }

        public async Task<List<Airports>> GetAllAsync()
        {
            return await _context.Airports.ToListAsync();
        }

        public async Task<Airports?> GetByIdAsync(decimal id)
        {
            return await _context.Airports.FindAsync(id);
        }

        public async Task<Airports> AddAsync(Airports airport)
        {
            _context.Airports.Add(airport);
            await _context.SaveChangesAsync();
            return airport;
        }

        public async Task<bool> UpdateAsync(Airports airport)
        {
            var existing = await _context.Airports.FindAsync(airport.Id);
            if (existing == null)
                return false;

            _context.Entry(existing).CurrentValues.SetValues(airport);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(decimal id)
        {
            var existing = await _context.Airports.FindAsync(id);
            if (existing == null)
                return false;

            _context.Airports.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
