using FlightReservationSystem.DTOs;

namespace FlightReservationSystem.Services
{
    public interface IAirplaneService
    {
        Task<List<AirplaneDto>> GetAllAsync();
        Task<AirplaneDto?> GetByIdAsync(decimal id);
        Task<AirplaneDto> CreateAsync(AirplaneCreateDto dto);
        Task<bool> UpdateAsync(decimal id, AirplaneUpdateDto dto);
        Task<bool> DeleteAsync(decimal id);
    }
}
