using FlightReservationSystem.Models;

namespace FlightReservationSystem.Repositories
{
    public interface IAirplaneRepository
    {
        Task<IEnumerable<Airplanes>> GetAllAsync();
        Task<Airplanes?> GetByIdAsync(decimal id);
        Task AddAsync(Airplanes airplane);
        void Update(Airplanes airplane);
        void Delete(Airplanes airplane);
        Task SaveChangesAsync();
    }
}
