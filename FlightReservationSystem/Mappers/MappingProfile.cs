using AutoMapper;
using FlightReservationSystem.Models;
using FlightReservationSystem.Models.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FlightReservationSystem.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Airplanes, AirplaneDto>().ReverseMap();
            // Add other mappings here#
        }
    }
}
