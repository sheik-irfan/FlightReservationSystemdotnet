using FlightReservationSystem.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FlightReservationSystem.Repositories
{
    public interface IFlightPriceRepository
    {
        Task<FlightPrices> AddAsync(FlightPrices price);
        Task<List<FlightPrices>> GetByFlightIdAsync(decimal flightId);
        Task<FlightPrices?> GetByFlightIdAndClassAsync(decimal flightId, string flightClass);

        // Add this method:
        Task UpdateAsync(FlightPrices price);
    }
}
