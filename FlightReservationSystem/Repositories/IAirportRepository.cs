using FlightReservationSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightReservationSystem.Repositories
{
    public interface IAirportRepository
    {
        Task<List<Airports>> GetAllAsync();
        Task<Airports?> GetByIdAsync(decimal id);
        Task<Airports> AddAsync(Airports airport);   // must return the added entity
        Task<bool> UpdateAsync(Airports airport);
        Task<bool> DeleteAsync(decimal id);
    }
}
