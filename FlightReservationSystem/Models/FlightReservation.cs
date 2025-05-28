using System;
using Microsoft.EntityFrameworkCore;
using FlightReservationSystem.Models;

namespace FlightReservationSystem.Models
{
    public partial class FlightReservation : DbContext
    {
        public FlightReservation(DbContextOptions<FlightReservation> options)
            : base(options)
        {
        }

        public virtual DbSet<Airplanes> Airplanes { get; set; }
        public virtual DbSet<Airports> Airports { get; set; }
        public virtual DbSet<BookedTickets> BookedTickets { get; set; }
        public virtual DbSet<Bookings> Bookings { get; set; }
        public virtual DbSet<FlightPrices> FlightPrices { get; set; }
        public virtual DbSet<Flights> Flights { get; set; }
        public virtual DbSet<Passengers> Passengers { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WalletTransaction> WalletTransactions { get; set; }
        public virtual DbSet<Wallets> Wallets { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDefaultSchema("MYAPPUSER")
                .UseCollation("USING_NLS_COMP");

            // Airports
            modelBuilder.Entity<Airports>(entity =>
            {
                entity.ToTable("AIRPORTS");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("AIRPORTS_SEQ.NEXTVAL")
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("NAME");
                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("CITY");
                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("COUNTRY");
                entity.Property(e => e.AirportCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength()
                    .HasColumnName("AIRPORT_CODE");
            });

            // Airplanes
            modelBuilder.Entity<Airplanes>(entity =>
            {
                entity.ToTable("AIRPLANES");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("AIRPLANES_SEQ.NEXTVAL")
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.AirplaneNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("AIRPLANE_NUMBER");
                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("MODEL");
                entity.Property(e => e.TotalSeats)
                    .HasColumnName("TOTAL_SEATS");
                entity.Property(e => e.EconomySeats)
                    .HasColumnName("ECONOMY_SEATS");
                entity.Property(e => e.BusinessSeats)
                    .HasColumnName("BUSINESS_SEATS");
            });

            // Flights
            modelBuilder.Entity<Flights>(entity =>
            {
                entity.ToTable("FLIGHTS");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                .HasColumnName("ID")
                .HasPrecision(10)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("FLIGHTS_SEQ.NEXTVAL");


                entity.Property(e => e.FlightName)
                    .HasColumnName("FLIGHT_NAME")
                    .IsRequired();

                // Ensure the FK properties have the same type as principal keys (decimal)
                entity.Property(e => e.AirplaneId)
                    .HasColumnName("AIRPLANE_ID")
                    .HasPrecision(18, 0);

                entity.Property(e => e.SourceAirportId)
                    .HasColumnName("SOURCE_AIRPORT_ID")
                    .HasPrecision(18, 0);

                entity.Property(e => e.DestinationAirportId)
                    .HasColumnName("DESTINATION_AIRPORT_ID")
                    .HasPrecision(18, 0);

                entity.Property(e => e.DepartureTime)
                    .HasColumnName("DEPARTURE_TIME");

                entity.Property(e => e.ArrivalTime)
                    .HasColumnName("ARRIVAL_TIME");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .IsRequired();

                // Foreign Key Relationships
                entity.HasOne(d => d.Airplane)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.AirplaneId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_FLIGHTS_AIRPLANE");

                entity.HasOne(d => d.SourceAirport)
                    .WithMany()
                    .HasForeignKey(d => d.SourceAirportId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_FLIGHTS_SOURCE_AIRPORT");

                entity.HasOne(d => d.DestinationAirport)
                    .WithMany()
                    .HasForeignKey(d => d.DestinationAirportId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_FLIGHTS_DESTINATION_AIRPORT");
            });

            // FlightPrices
            modelBuilder.Entity<FlightPrices>(entity =>
            {
                entity.ToTable("FLIGHT_PRICES");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("FLIGHT_PRICES_SEQ.NEXTVAL");

                entity.Property(e => e.FlightId)
                    .HasColumnName("FLIGHT_ID")
                    .HasPrecision(18, 0);

                entity.Property(e => e.FlightClass)
                    .HasColumnName("FLIGHT_CLASS")
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price)
                    .HasColumnName("PRICE");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.FlightPrices)
                    .HasForeignKey(d => d.FlightId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_FLIGHT_PRICES_FLIGHTS");
            });

            // Users
            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("USERS");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("USERS_SEQ.NEXTVAL");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("NAME");
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("EMAIL");
                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("PASSWORD");
                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ROLE");
                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("CHAR(1)")
                    .HasColumnName("GENDER");
                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("MOBILE_NUMBER");
                entity.Property(e => e.Dob)
                    .IsRequired()
                    .HasColumnType("DATE")
                    .HasColumnName("DOB");
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("TIMESTAMP")
                    .HasColumnName("CREATED_AT");
            });

            // Wallets
            modelBuilder.Entity<Wallets>(entity =>
            {
                entity.ToTable("WALLETS");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("WALLETS_SEQ.NEXTVAL");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .IsRequired();

                entity.Property(e => e.Balance)
                    .HasColumnName("BALANCE")
                    .HasColumnType("NUMBER(10,2)");

                entity.HasOne<Users>()
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .HasConstraintName("FK_WALLETS_USERS")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // WalletTransactions
            modelBuilder.Entity<WalletTransaction>(entity =>
            {
                entity.ToTable("WALLETTRANSACTIONS");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("ID")
                      .HasDefaultValueSql("WALLETTRANS_SEQ.NEXTVAL")  // Correct sequence name
                      .ValueGeneratedOnAdd();


                entity.Property(e => e.WalletId)
                      .HasColumnName("WALLET_ID")
                      .IsRequired();

                entity.Property(e => e.TransactionType)
                    .HasColumnName("TRANSACTION_TYPE")
                    .IsRequired();

                entity.Property(e => e.Amount)
                    .HasColumnName("AMOUNT")
                    .HasColumnType("NUMBER(10,2)");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .IsRequired();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("CREATED_AT")
                    .HasColumnType("TIMESTAMP");

                entity.HasOne<Wallets>()
                    .WithMany()
                    .HasForeignKey(e => e.WalletId)
                    .HasConstraintName("FK_WALLETTRANSACTIONS_WALLETS")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // reviews
            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("REVIEWS");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("REVIEWS_SEQ.NEXTVAL");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .IsRequired();

                entity.Property(e => e.BookingId)
                    .HasColumnName("BOOKING_ID")
                    .IsRequired();

                entity.Property(e => e.Rating)
                    .HasColumnName("RATING")
                    .IsRequired();

                entity.Property(e => e.ReviewComment)
                    .HasColumnName("REVIEW_COMMENT");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("CREATED_AT")
                    .HasColumnType("TIMESTAMP")
                    .HasDefaultValueSql("SYSTIMESTAMP")
                    .IsRequired();
            });



            // Add sequences if you use them
            modelBuilder.HasSequence("AIRPLANES_SEQ");
            modelBuilder.HasSequence("AIRPORTS_SEQ");
            modelBuilder.HasSequence("BOOKED_TICKETS_SEQ");
            modelBuilder.HasSequence("BOOKINGS_SEQ");
            modelBuilder.HasSequence("FLIGHT_PRICES_SEQ");
            modelBuilder.HasSequence("FLIGHTS_SEQ");
            modelBuilder.HasSequence("PASSENGERS_SEQ");
            modelBuilder.HasSequence("REVIEWS_SEQ");
            modelBuilder.HasSequence("USERS_SEQ");
            modelBuilder.HasSequence("WALLET_TRANSACTIONS_SEQ");
            modelBuilder.HasSequence("WALLET_TX_SEQ");
            modelBuilder.HasSequence("WALLETS_SEQ");
            modelBuilder.HasSequence("WALLETTRANS_SEQ");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
