using FlightReservationSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FlightReservationSystem.Repositories
{
    public class AirplaneRepository : IAirplaneRepository
    {
        private readonly FlightReservation _context;
        private readonly ILogger<AirplaneRepository> _logger;

        public AirplaneRepository(FlightReservation context, ILogger<AirplaneRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Airplanes>> GetAllAsync()
        {
            _logger.LogInformation("Querying all airplanes from database");
            var airplanes = await _context.Airplanes.ToListAsync();
            _logger.LogInformation("Retrieved {Count} airplanes from database", airplanes.Count);
            return airplanes;
        }

        public async Task<Airplanes?> GetByIdAsync(decimal id)
        {
            _logger.LogInformation("Querying airplane by ID {Id}", id);
            return await _context.Airplanes.FindAsync(id);
        }

        public async Task<Airplanes> CreateAsync(Airplanes airplane)
        {
            _logger.LogInformation("Adding airplane to context");
            _context.Airplanes.Add(airplane);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Saved new airplane with ID {Id}", airplane.Id);
            return airplane;
        }

        public async Task<bool> UpdateAsync(Airplanes airplane)
        {
            _logger.LogInformation("Updating airplane with ID {Id}", airplane.Id);
            _context.Airplanes.Update(airplane);
            var result = await _context.SaveChangesAsync();
            _logger.LogInformation("Update affected {Count} row(s)", result);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(decimal id)
        {
            _logger.LogInformation("Attempting to delete airplane with ID {Id}", id);
            var airplane = await _context.Airplanes.FindAsync(id);
            if (airplane == null)
            {
                _logger.LogWarning("Airplane with ID {Id} not found for deletion", id);
                return false;
            }

            _context.Airplanes.Remove(airplane);
            var result = await _context.SaveChangesAsync();
            _logger.LogInformation("Delete affected {Count} row(s)", result);
            return result > 0;
        }
    }
}
