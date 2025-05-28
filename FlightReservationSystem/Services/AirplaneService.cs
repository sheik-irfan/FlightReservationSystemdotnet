using AutoMapper;
using FlightReservationSystem.DTOs;
using FlightReservationSystem.Models;
using FlightReservationSystem.Repositories;
using Microsoft.Extensions.Logging;

namespace FlightReservationSystem.Services
{
    public class AirplaneService : IAirplaneService
    {
        private readonly IAirplaneRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<AirplaneService> _logger;

        public AirplaneService(IAirplaneRepository repository, IMapper mapper, ILogger<AirplaneService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<AirplaneDto>> GetAllAsync()
        {
            _logger.LogInformation("Fetching all airplanes...");
            var airplanes = await _repository.GetAllAsync();
            _logger.LogInformation("Fetched {Count} airplanes", airplanes.Count);
            return _mapper.Map<List<AirplaneDto>>(airplanes);
        }

        public async Task<AirplaneDto?> GetByIdAsync(decimal id)
        {
            _logger.LogInformation("Fetching airplane with ID {Id}", id);
            var airplane = await _repository.GetByIdAsync(id);
            if (airplane == null)
            {
                _logger.LogWarning("Airplane with ID {Id} not found", id);
                return null;
            }

            _logger.LogInformation("Fetched airplane with ID {Id}", id);
            return _mapper.Map<AirplaneDto>(airplane);
        }

        public async Task<AirplaneDto> CreateAsync(AirplaneCreateDto dto)
        {
            _logger.LogInformation("Creating new airplane");
            var airplane = _mapper.Map<Airplanes>(dto);
            var created = await _repository.CreateAsync(airplane);
            _logger.LogInformation("Created airplane with ID {Id}", created.Id);
            return _mapper.Map<AirplaneDto>(created);
        }

        public async Task<bool> UpdateAsync(decimal id, AirplaneUpdateDto dto)
        {
            _logger.LogInformation("Updating airplane with ID {Id}", id);
            var airplane = await _repository.GetByIdAsync(id);
            if (airplane == null)
            {
                _logger.LogWarning("Airplane with ID {Id} not found for update", id);
                return false;
            }

            _mapper.Map(dto, airplane);
            var success = await _repository.UpdateAsync(airplane);
            _logger.LogInformation("Update status for airplane with ID {Id}: {Success}", id, success);
            return success;
        }

        public async Task<bool> DeleteAsync(decimal id)
        {
            _logger.LogInformation("Deleting airplane with ID {Id}", id);
            var success = await _repository.DeleteAsync(id);
            if (success)
                _logger.LogInformation("Deleted airplane with ID {Id}", id);
            else
                _logger.LogWarning("Failed to delete airplane with ID {Id} (not found)", id);

            return success;
        }
    }
}
