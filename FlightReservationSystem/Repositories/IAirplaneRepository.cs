using FlightReservationSystem.Models;

namespace FlightReservationSystem.Repositories
{
    public interface IAirplaneRepository
    {
        Task<List<Airplanes>> GetAllAsync();
        Task<Airplanes?> GetByIdAsync(decimal id);
        Task<Airplanes> CreateAsync(Airplanes airplane);
        Task<bool> UpdateAsync(Airplanes airplane);
        Task<bool> DeleteAsync(decimal id);
    }
}
