using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightReservationSystem.Migrations
{
    /// <inheritdoc />
    public partial class FixAirportFKs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MYAPPUSER");

            migrationBuilder.CreateSequence(
                name: "AIRPLANES_SEQ",
                schema: "MYAPPUSER");

            migrationBuilder.CreateSequence(
                name: "AIRPORTS_SEQ",
                schema: "MYAPPUSER");

            migrationBuilder.CreateSequence(
                name: "BOOKED_TICKETS_SEQ",
                schema: "MYAPPUSER");

            migrationBuilder.CreateSequence(
                name: "BOOKINGS_SEQ",
                schema: "MYAPPUSER");

            migrationBuilder.CreateSequence(
                name: "FLIGHT_PRICES_SEQ",
                schema: "MYAPPUSER");

            migrationBuilder.CreateSequence(
                name: "FLIGHTS_SEQ",
                schema: "MYAPPUSER");

            migrationBuilder.CreateSequence(
                name: "PASSENGERS_SEQ",
                schema: "MYAPPUSER");

            migrationBuilder.CreateSequence(
                name: "REVIEWS_SEQ",
                schema: "MYAPPUSER");

            migrationBuilder.CreateSequence(
                name: "USERS_SEQ",
                schema: "MYAPPUSER");

            migrationBuilder.CreateSequence(
                name: "WALLET_TRANSACTIONS_SEQ",
                schema: "MYAPPUSER");

            migrationBuilder.CreateSequence(
                name: "WALLET_TX_SEQ",
                schema: "MYAPPUSER");

            migrationBuilder.CreateSequence(
                name: "WALLETS_SEQ",
                schema: "MYAPPUSER");

            migrationBuilder.CreateTable(
                name: "AIRPLANES",
                schema: "MYAPPUSER",
                columns: table => new
                {
                    ID = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false, defaultValueSql: "AIRPLANES_SEQ.NEXTVAL"),
                    AIRPLANE_NUMBER = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    MODEL = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    TOTAL_SEATS = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    ECONOMY_SEATS = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    BUSINESS_SEATS = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIRPLANES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AIRPORTS",
                schema: "MYAPPUSER",
                columns: table => new
                {
                    ID = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false, defaultValueSql: "AIRPORTS_SEQ.NEXTVAL"),
                    NAME = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    CITY = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    COUNTRY = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    AIRPORT_CODE = table.Column<string>(type: "NCHAR(3)", fixedLength: true, maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIRPORTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                schema: "MYAPPUSER",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    UserId = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    FlightId = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    BookingTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                schema: "MYAPPUSER",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    BookingId = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    FirstName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Gender = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Age = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    AadhaarNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                schema: "MYAPPUSER",
                columns: table => new
                {
                    ID = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false, defaultValueSql: "USERS_SEQ.NEXTVAL"),
                    NAME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    PASSWORD = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    ROLE = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    GENDER = table.Column<string>(type: "CHAR(1)", nullable: false),
                    MOBILE_NUMBER = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    DOB = table.Column<DateTime>(type: "DATE", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "TIMESTAMP", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                schema: "MYAPPUSER",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    UserId = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Balance = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WalletTransactions",
                schema: "MYAPPUSER",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    WalletId = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    TransactionType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    TransactionTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    Status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletTransactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FLIGHTS",
                schema: "MYAPPUSER",
                columns: table => new
                {
                    ID = table.Column<decimal>(type: "DECIMAL(10)", precision: 10, nullable: false, defaultValueSql: "FLIGHTS_SEQ.NEXTVAL"),
                    FLIGHT_NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AIRPLANE_ID = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    SOURCE_AIRPORT_ID = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    DESTINATION_AIRPORT_ID = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    DEPARTURE_TIME = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ARRIVAL_TIME = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    STATUS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AirplanesId = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    AirportsId = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    AirportsId1 = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C008287", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FLIGHTS_AIRPLANE",
                        column: x => x.AIRPLANE_ID,
                        principalSchema: "MYAPPUSER",
                        principalTable: "AIRPLANES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FLIGHTS_AIRPLANES_AirplanesId",
                        column: x => x.AirplanesId,
                        principalSchema: "MYAPPUSER",
                        principalTable: "AIRPLANES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_FLIGHTS_AIRPORTS_AirportsId",
                        column: x => x.AirportsId,
                        principalSchema: "MYAPPUSER",
                        principalTable: "AIRPORTS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_FLIGHTS_AIRPORTS_AirportsId1",
                        column: x => x.AirportsId1,
                        principalSchema: "MYAPPUSER",
                        principalTable: "AIRPORTS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_FLIGHTS_DESTINATION_AIRPORT",
                        column: x => x.DESTINATION_AIRPORT_ID,
                        principalSchema: "MYAPPUSER",
                        principalTable: "AIRPORTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FLIGHTS_SOURCE_AIRPORT",
                        column: x => x.SOURCE_AIRPORT_ID,
                        principalSchema: "MYAPPUSER",
                        principalTable: "AIRPORTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookedTickets",
                schema: "MYAPPUSER",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    BookingId = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    PassengerId = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    FlightClass = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CancellationTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookedTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookedTickets_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalSchema: "MYAPPUSER",
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FLIGHT_PRICES",
                schema: "MYAPPUSER",
                columns: table => new
                {
                    ID = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false, defaultValueSql: "FLIGHT_PRICES_SEQ.NEXTVAL"),
                    FLIGHT_ID = table.Column<decimal>(type: "DECIMAL(10)", nullable: false),
                    FLIGHT_CLASS = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    PRICE = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FLIGHT_PRICES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FLIGHT_PRICES_FLIGHTS",
                        column: x => x.FLIGHT_ID,
                        principalSchema: "MYAPPUSER",
                        principalTable: "FLIGHTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookedTickets_PassengerId",
                schema: "MYAPPUSER",
                table: "BookedTickets",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_FLIGHT_PRICES_FLIGHT_ID",
                schema: "MYAPPUSER",
                table: "FLIGHT_PRICES",
                column: "FLIGHT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLIGHTS_AIRPLANE_ID",
                schema: "MYAPPUSER",
                table: "FLIGHTS",
                column: "AIRPLANE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLIGHTS_AirplanesId",
                schema: "MYAPPUSER",
                table: "FLIGHTS",
                column: "AirplanesId");

            migrationBuilder.CreateIndex(
                name: "IX_FLIGHTS_AirportsId",
                schema: "MYAPPUSER",
                table: "FLIGHTS",
                column: "AirportsId");

            migrationBuilder.CreateIndex(
                name: "IX_FLIGHTS_AirportsId1",
                schema: "MYAPPUSER",
                table: "FLIGHTS",
                column: "AirportsId1");

            migrationBuilder.CreateIndex(
                name: "IX_FLIGHTS_DESTINATION_AIRPORT_ID",
                schema: "MYAPPUSER",
                table: "FLIGHTS",
                column: "DESTINATION_AIRPORT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FLIGHTS_SOURCE_AIRPORT_ID",
                schema: "MYAPPUSER",
                table: "FLIGHTS",
                column: "SOURCE_AIRPORT_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookedTickets",
                schema: "MYAPPUSER");

            migrationBuilder.DropTable(
                name: "Bookings",
                schema: "MYAPPUSER");

            migrationBuilder.DropTable(
                name: "FLIGHT_PRICES",
                schema: "MYAPPUSER");

            migrationBuilder.DropTable(
                name: "USERS",
                schema: "MYAPPUSER");

            migrationBuilder.DropTable(
                name: "Wallets",
                schema: "MYAPPUSER");

            migrationBuilder.DropTable(
                name: "WalletTransactions",
                schema: "MYAPPUSER");

            migrationBuilder.DropTable(
                name: "Passengers",
                schema: "MYAPPUSER");

            migrationBuilder.DropTable(
                name: "FLIGHTS",
                schema: "MYAPPUSER");

            migrationBuilder.DropTable(
                name: "AIRPLANES",
                schema: "MYAPPUSER");

            migrationBuilder.DropTable(
                name: "AIRPORTS",
                schema: "MYAPPUSER");

            migrationBuilder.DropSequence(
                name: "AIRPLANES_SEQ",
                schema: "MYAPPUSER");

            migrationBuilder.DropSequence(
                name: "AIRPORTS_SEQ",
                schema: "MYAPPUSER");

            migrationBuilder.DropSequence(
                name: "BOOKED_TICKETS_SEQ",
                schema: "MYAPPUSER");

            migrationBuilder.DropSequence(
                name: "BOOKINGS_SEQ",
                schema: "MYAPPUSER");

            migrationBuilder.DropSequence(
                name: "FLIGHT_PRICES_SEQ",
                schema: "MYAPPUSER");

            migrationBuilder.DropSequence(
                name: "FLIGHTS_SEQ",
                schema: "MYAPPUSER");

            migrationBuilder.DropSequence(
                name: "PASSENGERS_SEQ",
                schema: "MYAPPUSER");

            migrationBuilder.DropSequence(
                name: "REVIEWS_SEQ",
                schema: "MYAPPUSER");

            migrationBuilder.DropSequence(
                name: "USERS_SEQ",
                schema: "MYAPPUSER");

            migrationBuilder.DropSequence(
                name: "WALLET_TRANSACTIONS_SEQ",
                schema: "MYAPPUSER");

            migrationBuilder.DropSequence(
                name: "WALLET_TX_SEQ",
                schema: "MYAPPUSER");

            migrationBuilder.DropSequence(
                name: "WALLETS_SEQ",
                schema: "MYAPPUSER");
        }
    }
}
