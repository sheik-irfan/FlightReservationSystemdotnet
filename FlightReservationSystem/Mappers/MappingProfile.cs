using AutoMapper;
using FlightReservationSystem.DTOs;
using FlightReservationSystem.Models;

namespace FlightReservationSystem.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Airport
            CreateMap<Airports, AirportDto>();
            CreateMap<AirportCreateDto, Airports>();
            CreateMap<AirportUpdateDto, Airports>();

            // Airplane
            CreateMap<Airplanes, AirplaneDto>().ReverseMap();
            CreateMap<AirplaneCreateDto, Airplanes>();
            CreateMap<AirplaneUpdateDto, Airplanes>();

            // Flight
            CreateMap<Flights, FlightDto>().ReverseMap();
            CreateMap<FlightCreateDto, Flights>().ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<FlightUpdateDto, Flights>();

            // FlightPrice
            CreateMap<FlightPriceCreateDto, FlightPrices>().ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<FlightPrices, FlightPriceDto>();

            // Wallets and Transactions
            CreateMap<Wallets, WalletDto>();
            CreateMap<WalletTransaction, WalletTransactionDto>();

            // Booking
            CreateMap<Bookings, BookingDto>().ReverseMap();

            // Passenger
            CreateMap<Passengers, PassengerDto>()
                .ForMember(dest => dest.FlightClass, opt => opt.Ignore()) // From BookedTickets
                .ForMember(dest => dest.Price, opt => opt.Ignore());      // From BookedTickets
            CreateMap<PassengerDto, Passengers>();

            // Booked Ticket (optional - if you need to expose or map tickets separately)
            CreateMap<BookedTickets, TicketDto>().ReverseMap();

            // reviews 
            
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDto, Review>();
            CreateMap<CreateReviewDto, Review>()
                    // Set CreatedAt explicitly in the service; ignore here.
                    .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
            
        }
    }
}
