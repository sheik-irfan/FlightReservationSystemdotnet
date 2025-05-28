using FlightReservationSystem.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightReservationSystem.Services
{
    public interface IAirportService
    {
        Task<List<AirportDto>> GetAllAsync();
        Task<AirportDto?> GetByIdAsync(decimal id);
        Task<AirportDto> CreateAsync(AirportCreateDto dto);
        Task<bool> UpdateAsync(decimal id, AirportUpdateDto dto);
        Task<bool> DeleteAsync(decimal id);
    }
}
