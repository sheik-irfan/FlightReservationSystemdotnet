using FlightReservationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace FlightReservationSystem.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly FlightReservation _context;

        public FlightRepository(FlightReservation context)
        {
            _context = context;
        }

        public async Task<List<Flights>> GetAllAsync() =>
            await _context.Flights
                .Include(f => f.Airplane)
                .Include(f => f.SourceAirport)
                .Include(f => f.DestinationAirport)
                .Include(f => f.FlightPrices)
                .ToListAsync();

        public async Task<Flights?> GetByIdAsync(decimal id) =>
            await _context.Flights
                .Include(f => f.Airplane)
                .Include(f => f.SourceAirport)
                .Include(f => f.DestinationAirport)
                .Include(f => f.FlightPrices)
                .FirstOrDefaultAsync(f => f.Id == id);

        public async Task<Flights> CreateAsync(Flights flight)
        {
            flight.Id = await GetNextFlightIdAsync();
            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();
            return flight;
        }

        private async Task<decimal> GetNextFlightIdAsync()
        {
            using var command = _context.Database.GetDbConnection().CreateCommand();
            command.CommandText = "SELECT FLIGHTS_SEQ.NEXTVAL FROM dual";

            if (command.Connection.State != System.Data.ConnectionState.Open)
                await command.Connection.OpenAsync();

            var result = await command.ExecuteScalarAsync();
            return Convert.ToDecimal(result);
        }

        public async Task<bool> UpdateAsync(Flights flight)
        {
            _context.Entry(flight).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(decimal id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight == null) return false;

            _context.Flights.Remove(flight);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Flights>> SearchAsync(int sourceAirportId, int destinationAirportId)
        {
            return await _context.Flights
                .Include(f => f.Airplane)
                .Include(f => f.SourceAirport)
                .Include(f => f.DestinationAirport)
                .Include(f => f.FlightPrices)
                .Where(f => f.SourceAirportId == sourceAirportId && f.DestinationAirportId == destinationAirportId)
                .ToListAsync();
        }
    }
}
