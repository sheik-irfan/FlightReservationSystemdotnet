using FlightReservationSystem.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightReservationSystem.Services
{
    public interface IFlightService
    {
        Task<List<FlightDto>> GetAllAsync();
        Task<FlightDto?> GetByIdAsync(decimal id);
        Task<FlightDto> CreateAsync(FlightCreateDto dto);
        Task<bool> UpdateAsync(decimal id, FlightUpdateDto dto);
        Task<bool> DeleteAsync(decimal id);

        Task<FlightPriceDto> AddPriceAsync(FlightPriceCreateDto dto);
        Task<FlightPriceDto> UpdatePriceAsync(FlightPriceCreateDto dto);  // Make sure return type is Task<FlightPriceDto>
        Task<List<FlightPriceDto>> GetPricesAsync(decimal flightId);
        Task<List<FlightDto>> SearchAsync(int sourceAirportId, int destinationAirportId);

    }
}
