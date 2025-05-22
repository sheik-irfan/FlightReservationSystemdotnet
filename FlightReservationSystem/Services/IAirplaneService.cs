using FlightReservationSystem.Models.DTOs;

namespace FlightReservationSystem.Services
{
    public interface IAirplaneService
    {
        Task<IEnumerable<AirplaneDto>> GetAllAirplanesAsync();
        Task<AirplaneDto?> GetAirplaneByIdAsync(decimal id);
        Task<AirplaneDto> CreateAirplaneAsync(AirplaneDto airplaneDto);
        Task<bool> UpdateAirplaneAsync(decimal id, AirplaneDto airplaneDto);
        Task<bool> DeleteAirplaneAsync(decimal id);
    }
}
