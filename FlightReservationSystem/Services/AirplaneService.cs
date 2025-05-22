using AutoMapper;
using FlightReservationSystem.Models;
using FlightReservationSystem.Models.DTOs;
using FlightReservationSystem.Repositories;

namespace FlightReservationSystem.Services
{
    public class AirplaneService : IAirplaneService
    {
        private readonly IAirplaneRepository _repository;
        private readonly IMapper _mapper;

        public AirplaneService(IAirplaneRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AirplaneDto>> GetAllAirplanesAsync()
        {
            var airplanes = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AirplaneDto>>(airplanes);
        }

        public async Task<AirplaneDto?> GetAirplaneByIdAsync(decimal id)
        {
            var airplane = await _repository.GetByIdAsync(id);
            return airplane == null ? null : _mapper.Map<AirplaneDto>(airplane);
        }

        public async Task<AirplaneDto> CreateAirplaneAsync(AirplaneDto airplaneDto)
        {
            var airplane = _mapper.Map<Airplanes>(airplaneDto);
            await _repository.AddAsync(airplane);
            await _repository.SaveChangesAsync();
            return _mapper.Map<AirplaneDto>(airplane);
        }

        public async Task<bool> UpdateAirplaneAsync(decimal id, AirplaneDto airplaneDto)
        {
            var existingAirplane = await _repository.GetByIdAsync(id);
            if (existingAirplane == null)
                return false;

            _mapper.Map(airplaneDto, existingAirplane);
            _repository.Update(existingAirplane);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAirplaneAsync(decimal id)
        {
            var existingAirplane = await _repository.GetByIdAsync(id);
            if (existingAirplane == null)
                return false;

            _repository.Delete(existingAirplane);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
