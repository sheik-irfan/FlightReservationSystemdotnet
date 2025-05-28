using FlightReservationSystem.Models;

namespace FlightReservationSystem.Repositories
{
    public interface IFlightRepository
    {
        Task<List<Flights>> GetAllAsync();
        Task<Flights?> GetByIdAsync(decimal id);
        Task<Flights> CreateAsync(Flights flight);
        Task<bool> UpdateAsync(Flights flight);
        Task<bool> DeleteAsync(decimal id);
        Task<List<Flights>> SearchAsync(int sourceAirportId, int destinationAirportId);

    }
}