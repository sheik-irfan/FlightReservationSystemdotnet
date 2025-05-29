using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FlightReservationSystem.Models;

namespace FlightReservationSystem.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseOracle("User Id=MyAppUser;Password=mypassword;Data Source=localhost/XEPDB1");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDefaultSchema("MYAPPUSER")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("SYS_C008358");

                entity.ToTable("REVIEWS");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID");

                entity.Property(e => e.BookingId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BOOKING_ID");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(6)
                    .HasDefaultValueSql("SYSTIMESTAMP")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.Rating)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RATING");

                entity.Property(e => e.ReviewComment)
                    .HasColumnType("CLOB")
                    .HasColumnName("REVIEW_COMMENT");

                entity.Property(e => e.UserEmail)
                    .HasColumnType("VARCHAR2(255)")
                    .HasColumnName("USER_EMAIL");
            });

            modelBuilder.HasSequence("AIRPLANES_SEQ");
            modelBuilder.HasSequence("AIRPORTS_SEQ");
            modelBuilder.HasSequence("BOOKED_TICKETS_SEQ");
            modelBuilder.HasSequence("BOOKINGS_SEQ");
            modelBuilder.HasSequence("FLIGHT_PRICES_SEQ");
            modelBuilder.HasSequence("FLIGHTPRICE_SEQ");
            modelBuilder.HasSequence("FLIGHTPRICES_SEQ");
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
