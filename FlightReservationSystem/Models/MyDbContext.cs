using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationSystem.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
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

    public virtual DbSet<WalletTransactions> WalletTransactions { get; set; }

    public virtual DbSet<Wallets> Wallets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("User Id=MyAppUser;Password=mypassword;Data Source=localhost/XEPDB1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("MYAPPUSER")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Airplanes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008277");

            entity.ToTable("AIRPLANES");

            entity.HasIndex(e => e.AirplaneNumber, "SYS_C008278").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.AirplaneNumber)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AIRPLANE_NUMBER");
            entity.Property(e => e.BusinessSeats)
                .HasColumnType("NUMBER")
                .HasColumnName("BUSINESS_SEATS");
            entity.Property(e => e.EconomySeats)
                .HasColumnType("NUMBER")
                .HasColumnName("ECONOMY_SEATS");
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MODEL");
            entity.Property(e => e.TotalSeats)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTAL_SEATS");
        });

        modelBuilder.Entity<Airports>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008270");

            entity.ToTable("AIRPORTS");

            entity.HasIndex(e => e.AirportCode, "SYS_C008271").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.AirportCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AIRPORT_CODE");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CITY");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("COUNTRY");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<BookedTickets>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008320");

            entity.ToTable("BOOKED_TICKETS");

            entity.HasIndex(e => e.BookingId, "IDX_TICKET_BOOKING_ID");

            entity.HasIndex(e => e.PassengerId, "IDX_TICKET_PASSENGER_ID");

            entity.Property(e => e.Id)
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.BookingId)
                .HasColumnType("NUMBER")
                .HasColumnName("BOOKING_ID");
            entity.Property(e => e.CancellationTime)
                .HasPrecision(6)
                .HasDefaultValueSql("NULL")
                .HasColumnName("CANCELLATION_TIME");
            entity.Property(e => e.FlightClass)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FLIGHT_CLASS");
            entity.Property(e => e.PassengerId)
                .HasColumnType("NUMBER")
                .HasColumnName("PASSENGER_ID");
            entity.Property(e => e.Price)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("PRICE");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("'BOOKED' ")
                .HasColumnName("STATUS");

            entity.HasOne(d => d.Booking).WithMany(p => p.BookedTickets)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C008321");

            entity.HasOne(d => d.Passenger).WithMany(p => p.BookedTickets)
                .HasForeignKey(d => d.PassengerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C008322");
        });

        modelBuilder.Entity<Bookings>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008302");

            entity.ToTable("BOOKINGS");

            entity.HasIndex(e => e.FlightId, "IDX_FLIGHT_ID");

            entity.HasIndex(e => e.UserId, "IDX_USER_ID");

            entity.Property(e => e.Id)
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.BookingTime)
                .HasPrecision(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("BOOKING_TIME");
            entity.Property(e => e.FlightId)
                .HasColumnType("NUMBER")
                .HasColumnName("FLIGHT_ID");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("'PENDING' ")
                .HasColumnName("STATUS");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("TOTAL_PRICE");
            entity.Property(e => e.UserId)
                .HasColumnType("NUMBER")
                .HasColumnName("USER_ID");

            entity.HasOne(d => d.Flight).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.FlightId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C008304");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C008303");
        });

        modelBuilder.Entity<FlightPrices>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008295");

            entity.ToTable("FLIGHT_PRICES");

            entity.HasIndex(e => e.FlightId, "IDX_FLIGHT_PRICE_FLIGHT_ID");

            entity.HasIndex(e => new { e.FlightId, e.FlightClass }, "SYS_C008296").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.FlightClass)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("FLIGHT_CLASS");
            entity.Property(e => e.FlightId)
                .HasColumnType("NUMBER")
                .HasColumnName("FLIGHT_ID");
            entity.Property(e => e.Price)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("PRICE");

            entity.HasOne(d => d.Flight).WithMany(p => p.FlightPrices)
                .HasForeignKey(d => d.FlightId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C008297");
        });

        modelBuilder.Entity<Flights>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008287");

            entity.ToTable("FLIGHTS");

            entity.HasIndex(e => e.AirplaneId, "IDX_AIRPLANE_ID");

            entity.Property(e => e.Id)
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.AirplaneId)
                .HasColumnType("NUMBER")
                .HasColumnName("AIRPLANE_ID");
            entity.Property(e => e.ArrivalTime)
                .HasPrecision(6)
                .HasColumnName("ARRIVAL_TIME");
            entity.Property(e => e.DepartureTime)
                .HasPrecision(6)
                .HasColumnName("DEPARTURE_TIME");
            entity.Property(e => e.DestinationAirportId)
                .HasColumnType("NUMBER")
                .HasColumnName("DESTINATION_AIRPORT_ID");
            entity.Property(e => e.FlightName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FLIGHT_NAME");
            entity.Property(e => e.SourceAirportId)
                .HasColumnType("NUMBER")
                .HasColumnName("SOURCE_AIRPORT_ID");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("STATUS");

            entity.HasOne(d => d.Airplane).WithMany(p => p.Flights)
                .HasForeignKey(d => d.AirplaneId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C008288");

            entity.HasOne(d => d.DestinationAirport).WithMany(p => p.FlightsDestinationAirport)
                .HasForeignKey(d => d.DestinationAirportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C008290");

            entity.HasOne(d => d.SourceAirport).WithMany(p => p.FlightsSourceAirport)
                .HasForeignKey(d => d.SourceAirportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C008289");
        });

        modelBuilder.Entity<Passengers>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008311");

            entity.ToTable("PASSENGERS");

            entity.HasIndex(e => e.AadhaarNumber, "SYS_C008312").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.AadhaarNumber)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AADHAAR_NUMBER");
            entity.Property(e => e.Age)
                .HasColumnType("NUMBER")
                .HasColumnName("AGE");
            entity.Property(e => e.BookingId)
                .HasColumnType("NUMBER")
                .HasColumnName("BOOKING_ID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GENDER");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LAST_NAME");

            entity.HasOne(d => d.Booking).WithMany(p => p.Passengers)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C008313");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008252");

            entity.ToTable("USERS");

            entity.HasIndex(e => e.Email, "SYS_C008253").IsUnique();

            entity.HasIndex(e => e.AadhaarNumber, "SYS_C008254").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.AadhaarNumber)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AADHAAR_NUMBER");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP\n")
                .HasColumnName("CREATED_AT");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GENDER");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Role)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROLE");
        });

        modelBuilder.Entity<WalletTransactions>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008264");

            entity.ToTable("WALLET_TRANSACTIONS");

            entity.HasIndex(e => e.WalletId, "IDX_WALLET_ID");

            entity.Property(e => e.Id)
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Amount)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("AMOUNT");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("'COMPLETED' ")
                .HasColumnName("STATUS");
            entity.Property(e => e.TransactionTime)
                .HasPrecision(6)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("TRANSACTION_TIME");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TRANSACTION_TYPE");
            entity.Property(e => e.WalletId)
                .HasColumnType("NUMBER")
                .HasColumnName("WALLET_ID");

            entity.HasOne(d => d.Wallet).WithMany(p => p.WalletTransactions)
                .HasForeignKey(d => d.WalletId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C008265");
        });

        modelBuilder.Entity<Wallets>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008256");

            entity.ToTable("WALLETS");

            entity.HasIndex(e => e.UserId, "SYS_C008257").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Balance)
                .HasDefaultValueSql("0.00")
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("BALANCE");
            entity.Property(e => e.UserId)
                .HasColumnType("NUMBER")
                .HasColumnName("USER_ID");

            entity.HasOne(d => d.User).WithOne(p => p.Wallets)
                .HasForeignKey<Wallets>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SYS_C008258");
        });
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
        modelBuilder.HasSequence("WALLETS_SEQ");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
