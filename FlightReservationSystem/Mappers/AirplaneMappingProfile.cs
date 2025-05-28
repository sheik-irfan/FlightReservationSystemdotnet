using AutoMapper;
using FlightReservationSystem.DTOs;
using FlightReservationSystem.Models;

namespace FlightReservationSystem.Mappers
{
    public class AirplaneMappingProfile : Profile
    {
        public AirplaneMappingProfile()
        {
            CreateMap<Airplanes, AirplaneDto>();
            CreateMap<AirplaneCreateDto, Airplanes>();
            CreateMap<AirplaneUpdateDto, Airplanes>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // ensure ID isn't accidentally overwritten
                .ForMember(dest => dest.AirplaneNumber, opt => opt.Ignore()); // assume it's immutable
        }
    }
}
