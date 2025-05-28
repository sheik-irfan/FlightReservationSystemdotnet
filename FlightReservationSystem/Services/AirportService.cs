using AutoMapper;
using FlightReservationSystem.DTOs;
using FlightReservationSystem.Models;
using FlightReservationSystem.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightReservationSystem.Services
{
    public class AirportService : IAirportService
    {
        private readonly IAirportRepository _repository;
        private readonly IMapper _mapper;

        public AirportService(IAirportRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AirportDto>> GetAllAsync()
        {
            var airports = await _repository.GetAllAsync();
            return _mapper.Map<List<AirportDto>>(airports);
        }

        public async Task<AirportDto?> GetByIdAsync(decimal id)
        {
            var airport = await _repository.GetByIdAsync(id);
            return airport == null ? null : _mapper.Map<AirportDto>(airport);
        }

        public async Task<AirportDto> CreateAsync(AirportCreateDto dto)
        {
            var airport = _mapper.Map<Airports>(dto);
            var created = await _repository.AddAsync(airport);
            return _mapper.Map<AirportDto>(created);
        }

        public async Task<bool> UpdateAsync(decimal id, AirportUpdateDto dto)
        {
            var airport = _mapper.Map<Airports>(dto);
            airport.Id = id;
            return await _repository.UpdateAsync(airport);
        }

        public async Task<bool> DeleteAsync(decimal id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
