using FlightReservationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightReservationSystem.Repositories
{
    public class FlightPriceRepository : IFlightPriceRepository
    {
        private readonly FlightReservation _context;

        public FlightPriceRepository(FlightReservation context)
        {
            _context = context;
        }

        public async Task<FlightPrices> AddAsync(FlightPrices price)
        {
            price.Id = 0; // Prevent EF from inserting the ID
            _context.FlightPrices.Add(price);
            await _context.SaveChangesAsync();
            return price;
        }

        public async Task<List<FlightPrices>> GetByFlightIdAsync(decimal flightId)
        {
            return await _context.FlightPrices
                .Where(p => p.FlightId == flightId)
                .ToListAsync();
        }

        public async Task<FlightPrices?> GetByFlightIdAndClassAsync(decimal flightId, string flightClass)
        {
            return await _context.FlightPrices
                .FirstOrDefaultAsync(p => p.FlightId == flightId && p.FlightClass == flightClass);
        }

        public async Task UpdateAsync(FlightPrices price)
        {
            _context.FlightPrices.Update(price);
            await _context.SaveChangesAsync();
        }
    }
}
