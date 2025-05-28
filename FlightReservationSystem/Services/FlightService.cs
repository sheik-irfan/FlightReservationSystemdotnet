using AutoMapper;
using FlightReservationSystem.DTOs;
using FlightReservationSystem.Models;
using FlightReservationSystem.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightReservationSystem.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _repository;
        private readonly IFlightPriceRepository _priceRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<FlightService> _logger;

        public FlightService(
            IFlightRepository repository,
            IFlightPriceRepository priceRepository,
            IMapper mapper,
            ILogger<FlightService> logger)
        {
            _repository = repository;
            _priceRepository = priceRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<FlightDto>> GetAllAsync()
        {
            var flights = await _repository.GetAllAsync();
            return _mapper.Map<List<FlightDto>>(flights);
        }

        public async Task<FlightDto?> GetByIdAsync(decimal id)
        {
            var flight = await _repository.GetByIdAsync(id);
            return flight == null ? null : _mapper.Map<FlightDto>(flight);
        }

        public async Task<FlightDto> CreateAsync(FlightCreateDto dto)
        {
            var flight = _mapper.Map<Flights>(dto);
            var created = await _repository.CreateAsync(flight);
            _logger.LogInformation("Created flight with ID {Id}", created.Id);

            return _mapper.Map<FlightDto>(created);
        }

        public async Task<bool> UpdateAsync(decimal id, FlightUpdateDto dto)
        {
            var flight = await _repository.GetByIdAsync(id);
            if (flight == null) return false;
            _mapper.Map(dto, flight);

            return await _repository.UpdateAsync(flight);
        }

        public async Task<bool> DeleteAsync(decimal id) =>
            await _repository.DeleteAsync(id);

        public async Task<FlightPriceDto> AddPriceAsync(FlightPriceCreateDto dto)
        {
            var flight = await _repository.GetByIdAsync(dto.FlightId);
            if (flight == null)
                throw new InvalidOperationException($"Flight with ID {dto.FlightId} does not exist.");

            var existing = await _priceRepository.GetByFlightIdAndClassAsync(dto.FlightId, dto.FlightClass);
            if (existing != null)
                throw new InvalidOperationException("Price already exists for this flight and class. Use update instead.");

            var entity = _mapper.Map<FlightPrices>(dto);
            var added = await _priceRepository.AddAsync(entity);
            _logger.LogInformation("Added price {Price} for flight {FlightId} with class {FlightClass}", dto.Price, dto.FlightId, dto.FlightClass);
            return _mapper.Map<FlightPriceDto>(added);
        }

        public async Task<FlightPriceDto> UpdatePriceAsync(FlightPriceCreateDto dto)
        {
            var existing = await _priceRepository.GetByFlightIdAndClassAsync(dto.FlightId, dto.FlightClass);

            if (existing == null)
                throw new InvalidOperationException("No price found to update for the given flight and class.");

            existing.Price = dto.Price;
            await _priceRepository.UpdateAsync(existing);

            return _mapper.Map<FlightPriceDto>(existing);
        }

        public async Task<List<FlightPriceDto>> GetPricesAsync(decimal flightId)
        {
            var prices = await _priceRepository.GetByFlightIdAsync(flightId);
            return _mapper.Map<List<FlightPriceDto>>(prices);
        }

        public async Task<List<FlightDto>> SearchAsync(int sourceAirportId, int destinationAirportId)
        {
            var flights = await _repository.SearchAsync(sourceAirportId, destinationAirportId);
            return _mapper.Map<List<FlightDto>>(flights);
        }
    }
}
