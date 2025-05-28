using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightReservationSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedKeyTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedTickets_Passengers_PassengerId",
                schema: "MYAPPUSER",
                table: "BookedTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_FLIGHTS_AIRPLANES_AirplanesId",
                schema: "MYAPPUSER",
                table: "FLIGHTS");

            migrationBuilder.DropForeignKey(
                name: "FK_FLIGHTS_AIRPORTS_AirportsId",
                schema: "MYAPPUSER",
                table: "FLIGHTS");

            migrationBuilder.DropForeignKey(
                name: "FK_FLIGHTS_AIRPORTS_AirportsId1",
                schema: "MYAPPUSER",
                table: "FLIGHTS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WalletTransactions",
                schema: "MYAPPUSER",
                table: "WalletTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallets",
                schema: "MYAPPUSER",
                table: "Wallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passengers",
                schema: "MYAPPUSER",
                table: "Passengers");

            migrationBuilder.DropPrimaryKey(
                name: "SYS_C008287",
                schema: "MYAPPUSER",
                table: "FLIGHTS");

            migrationBuilder.DropIndex(
                name: "IX_FLIGHTS_AirplanesId",
                schema: "MYAPPUSER",
                table: "FLIGHTS");

            migrationBuilder.DropIndex(
                name: "IX_FLIGHTS_AirportsId",
                schema: "MYAPPUSER",
                table: "FLIGHTS");

            migrationBuilder.DropIndex(
                name: "IX_FLIGHTS_AirportsId1",
                schema: "MYAPPUSER",
                table: "FLIGHTS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                schema: "MYAPPUSER",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookedTickets",
                schema: "MYAPPUSER",
                table: "BookedTickets");

            migrationBuilder.DropIndex(
                name: "IX_BookedTickets_PassengerId",
                schema: "MYAPPUSER",
                table: "BookedTickets");

            migrationBuilder.DropColumn(
                name: "TransactionTime",
                schema: "MYAPPUSER",
                table: "WalletTransactions");

            migrationBuilder.DropColumn(
                name: "AirplanesId",
                schema: "MYAPPUSER",
                table: "FLIGHTS");

            migrationBuilder.DropColumn(
                name: "AirportsId",
                schema: "MYAPPUSER",
                table: "FLIGHTS");

            migrationBuilder.DropColumn(
                name: "AirportsId1",
                schema: "MYAPPUSER",
                table: "FLIGHTS");

            migrationBuilder.RenameTable(
                name: "WalletTransactions",
                schema: "MYAPPUSER",
                newName: "WALLETTRANSACTIONS",
                newSchema: "MYAPPUSER");

            migrationBuilder.RenameTable(
                name: "Wallets",
                schema: "MYAPPUSER",
                newName: "WALLETS",
                newSchema: "MYAPPUSER");

            migrationBuilder.RenameTable(
                name: "Passengers",
                schema: "MYAPPUSER",
                newName: "PASSENGERS",
                newSchema: "MYAPPUSER");

            migrationBuilder.RenameTable(
                name: "Bookings",
                schema: "MYAPPUSER",
                newName: "BOOKINGS",
                newSchema: "MYAPPUSER");

            migrationBuilder.RenameTable(
                name: "BookedTickets",
                schema: "MYAPPUSER",
                newName: "BOOKED_TICKETS",
                newSchema: "MYAPPUSER");

            migrationBuilder.RenameColumn(
                name: "Status",
                schema: "MYAPPUSER",
                table: "WALLETTRANSACTIONS",
                newName: "STATUS");

            migrationBuilder.RenameColumn(
                name: "Amount",
                schema: "MYAPPUSER",
                table: "WALLETTRANSACTIONS",
                newName: "AMOUNT");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "MYAPPUSER",
                table: "WALLETTRANSACTIONS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "WalletId",
                schema: "MYAPPUSER",
                table: "WALLETTRANSACTIONS",
                newName: "WALLET_ID");

            migrationBuilder.RenameColumn(
                name: "TransactionType",
                schema: "MYAPPUSER",
                table: "WALLETTRANSACTIONS",
                newName: "TRANSACTION_TYPE");

            migrationBuilder.RenameColumn(
                name: "Balance",
                schema: "MYAPPUSER",
                table: "WALLETS",
                newName: "BALANCE");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "MYAPPUSER",
                table: "WALLETS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "MYAPPUSER",
                table: "WALLETS",
                newName: "USER_ID");

            migrationBuilder.RenameColumn(
                name: "Gender",
                schema: "MYAPPUSER",
                table: "PASSENGERS",
                newName: "GENDER");

            migrationBuilder.RenameColumn(
                name: "Age",
                schema: "MYAPPUSER",
                table: "PASSENGERS",
                newName: "AGE");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "MYAPPUSER",
                table: "PASSENGERS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "MYAPPUSER",
                table: "PASSENGERS",
                newName: "LAST_NAME");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "MYAPPUSER",
                table: "PASSENGERS",
                newName: "FIRST_NAME");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                schema: "MYAPPUSER",
                table: "PASSENGERS",
                newName: "BOOKING_ID");

            migrationBuilder.RenameColumn(
                name: "AadhaarNumber",
                schema: "MYAPPUSER",
                table: "PASSENGERS",
                newName: "AADHAAR_NUMBER");

            migrationBuilder.RenameColumn(
                name: "Status",
                schema: "MYAPPUSER",
                table: "BOOKINGS",
                newName: "STATUS");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "MYAPPUSER",
                table: "BOOKINGS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "MYAPPUSER",
                table: "BOOKINGS",
                newName: "USER_ID");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                schema: "MYAPPUSER",
                table: "BOOKINGS",
                newName: "TOTAL_PRICE");

            migrationBuilder.RenameColumn(
                name: "FlightId",
                schema: "MYAPPUSER",
                table: "BOOKINGS",
                newName: "FLIGHT_ID");

            migrationBuilder.RenameColumn(
                name: "BookingTime",
                schema: "MYAPPUSER",
                table: "BOOKINGS",
                newName: "BOOKING_TIME");

            migrationBuilder.RenameColumn(
                name: "Status",
                schema: "MYAPPUSER",
                table: "BOOKED_TICKETS",
                newName: "STATUS");

            migrationBuilder.RenameColumn(
                name: "Price",
                schema: "MYAPPUSER",
                table: "BOOKED_TICKETS",
                newName: "PRICE");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "MYAPPUSER",
                table: "BOOKED_TICKETS",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PassengerId",
                schema: "MYAPPUSER",
                table: "BOOKED_TICKETS",
                newName: "PASSENGER_ID");

            migrationBuilder.RenameColumn(
                name: "FlightClass",
                schema: "MYAPPUSER",
                table: "BOOKED_TICKETS",
                newName: "FLIGHT_CLASS");

            migrationBuilder.RenameColumn(
                name: "CancellationTime",
                schema: "MYAPPUSER",
                table: "BOOKED_TICKETS",
                newName: "CANCELLATION_TIME");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                schema: "MYAPPUSER",
                table: "BOOKED_TICKETS",
                newName: "BOOKING_ID");

            migrationBuilder.CreateSequence(
                name: "WALLETTRANS_SEQ",
                schema: "MYAPPUSER");

            migrationBuilder.AlterColumn<string>(
                name: "STATUS",
                schema: "MYAPPUSER",
                table: "WALLETTRANSACTIONS",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AMOUNT",
                schema: "MYAPPUSER",
                table: "WALLETTRANSACTIONS",
                type: "NUMBER(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ID",
                schema: "MYAPPUSER",
                table: "WALLETTRANSACTIONS",
                type: "DECIMAL(18, 2)",
                nullable: false,
                defaultValueSql: "WALLETTRANS_SEQ.NEXTVAL",
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "WALLET_ID",
                schema: "MYAPPUSER",
                table: "WALLETTRANSACTIONS",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_AT",
                schema: "MYAPPUSER",
                table: "WALLETTRANSACTIONS",
                type: "TIMESTAMP",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<decimal>(
                name: "BALANCE",
                schema: "MYAPPUSER",
                table: "WALLETS",
                type: "NUMBER(10,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ID",
                schema: "MYAPPUSER",
                table: "WALLETS",
                type: "DECIMAL(18, 2)",
                nullable: false,
                defaultValueSql: "WALLETS_SEQ.NEXTVAL",
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "USER_ID",
                schema: "MYAPPUSER",
                table: "WALLETS",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ID",
                schema: "MYAPPUSER",
                table: "USERS",
                type: "DECIMAL(18, 2)",
                nullable: false,
                defaultValueSql: "USERS_SEQ.NEXTVAL",
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldDefaultValueSql: "USERS_SEQ.NEXTVAL");

            migrationBuilder.AlterColumn<int>(
                name: "AGE",
                schema: "MYAPPUSER",
                table: "PASSENGERS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ID",
                schema: "MYAPPUSER",
                table: "PASSENGERS",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "BOOKING_ID",
                schema: "MYAPPUSER",
                table: "PASSENGERS",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SOURCE_AIRPORT_ID",
                schema: "MYAPPUSER",
                table: "FLIGHTS",
                type: "DECIMAL(18,0)",
                precision: 18,
                scale: 0,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DESTINATION_AIRPORT_ID",
                schema: "MYAPPUSER",
                table: "FLIGHTS",
                type: "DECIMAL(18,0)",
                precision: 18,
                scale: 0,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DEPARTURE_TIME",
                schema: "MYAPPUSER",
                table: "FLIGHTS",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ARRIVAL_TIME",
                schema: "MYAPPUSER",
                table: "FLIGHTS",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AIRPLANE_ID",
                schema: "MYAPPUSER",
                table: "FLIGHTS",
                type: "DECIMAL(18,0)",
                precision: 18,
                scale: 0,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PRICE",
                schema: "MYAPPUSER",
                table: "FLIGHT_PRICES",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "FLIGHT_ID",
                schema: "MYAPPUSER",
                table: "FLIGHT_PRICES",
                type: "DECIMAL(18,0)",
                precision: 18,
                scale: 0,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(10)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ID",
                schema: "MYAPPUSER",
                table: "FLIGHT_PRICES",
                type: "DECIMAL(18, 2)",
                nullable: false,
                defaultValueSql: "FLIGHT_PRICES_SEQ.NEXTVAL",
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldDefaultValueSql: "FLIGHT_PRICES_SEQ.NEXTVAL");

            migrationBuilder.AlterColumn<string>(
                name: "STATUS",
                schema: "MYAPPUSER",
                table: "BOOKINGS",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ID",
                schema: "MYAPPUSER",
                table: "BOOKINGS",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "USER_ID",
                schema: "MYAPPUSER",
                table: "BOOKINGS",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TOTAL_PRICE",
                schema: "MYAPPUSER",
                table: "BOOKINGS",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "FLIGHT_ID",
                schema: "MYAPPUSER",
                table: "BOOKINGS",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BOOKING_TIME",
                schema: "MYAPPUSER",
                table: "BOOKINGS",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AIRPORT_CODE",
                schema: "MYAPPUSER",
                table: "AIRPORTS",
                type: "CHAR(3)",
                fixedLength: true,
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NCHAR(3)",
                oldFixedLength: true,
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "ID",
                schema: "MYAPPUSER",
                table: "AIRPORTS",
                type: "DECIMAL(18, 2)",
                nullable: false,
                defaultValueSql: "AIRPORTS_SEQ.NEXTVAL",
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldDefaultValueSql: "AIRPORTS_SEQ.NEXTVAL");

            migrationBuilder.AlterColumn<int>(
                name: "TOTAL_SEATS",
                schema: "MYAPPUSER",
                table: "AIRPLANES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "ECONOMY_SEATS",
                schema: "MYAPPUSER",
                table: "AIRPLANES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "BUSINESS_SEATS",
                schema: "MYAPPUSER",
                table: "AIRPLANES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ID",
                schema: "MYAPPUSER",
                table: "AIRPLANES",
                type: "DECIMAL(18, 2)",
                nullable: false,
                defaultValueSql: "AIRPLANES_SEQ.NEXTVAL",
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)",
                oldDefaultValueSql: "AIRPLANES_SEQ.NEXTVAL");

            migrationBuilder.AlterColumn<string>(
                name: "STATUS",
                schema: "MYAPPUSER",
                table: "BOOKED_TICKETS",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PRICE",
                schema: "MYAPPUSER",
                table: "BOOKED_TICKETS",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ID",
                schema: "MYAPPUSER",
                table: "BOOKED_TICKETS",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "PASSENGER_ID",
                schema: "MYAPPUSER",
                table: "BOOKED_TICKETS",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BOOKING_ID",
                schema: "MYAPPUSER",
                table: "BOOKED_TICKETS",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WALLETTRANSACTIONS",
                schema: "MYAPPUSER",
                table: "WALLETTRANSACTIONS",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WALLETS",
                schema: "MYAPPUSER",
                table: "WALLETS",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PASSENGERS",
                schema: "MYAPPUSER",
                table: "PASSENGERS",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FLIGHTS",
                schema: "MYAPPUSER",
                table: "FLIGHTS",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BOOKINGS",
                schema: "MYAPPUSER",
                table: "BOOKINGS",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BOOKED_TICKETS",
                schema: "MYAPPUSER",
                table: "BOOKED_TICKETS",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_WALLETTRANSACTIONS_WALLET_ID",
                schema: "MYAPPUSER",
                table: "WALLETTRANSACTIONS",
                column: "WALLET_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WALLETS_USER_ID",
                schema: "MYAPPUSER",
                table: "WALLETS",
                column: "USER_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WALLETS_USERS",
                schema: "MYAPPUSER",
                table: "WALLETS",
                column: "USER_ID",
                principalSchema: "MYAPPUSER",
                principalTable: "USERS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WALLETTRANSACTIONS_WALLETS",
                schema: "MYAPPUSER",
                table: "WALLETTRANSACTIONS",
                column: "WALLET_ID",
                principalSchema: "MYAPPUSER",
                principalTable: "WALLETS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WALLETS_USERS",
                schema: "MYAPPUSER",
                table: "WALLETS");

            migrationBuilder.DropForeignKey(
                name: "FK_WALLETTRANSACTIONS_WALLETS",
                schema: "MYAPPUSER",
                table: "WALLETTRANSACTIONS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WALLETTRANSACTIONS",
                schema: "MYAPPUSER",
                table: "WALLETTRANSACTIONS");

            migrationBuilder.DropIndex(
                name: "IX_WALLETTRANSACTIONS_WALLET_ID",
                schema: "MYAPPUSER",
                table: "WALLETTRANSACTIONS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WALLETS",
                schema: "MYAPPUSER",
                table: "WALLETS");

            migrationBuilder.DropIndex(
                name: "IX_WALLETS_USER_ID",
                schema: "MYAPPUSER",
                table: "WALLETS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PASSENGERS",
                schema: "MYAPPUSER",
                table: "PASSENGERS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FLIGHTS",
                schema: "MYAPPUSER",
                table: "FLIGHTS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BOOKINGS",
                schema: "MYAPPUSER",
                table: "BOOKINGS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BOOKED_TICKETS",
                schema: "MYAPPUSER",
                table: "BOOKED_TICKETS");

            migrationBuilder.DropColumn(
                name: "CREATED_AT",
                schema: "MYAPPUSER",
                table: "WALLETTRANSACTIONS");

            migrationBuilder.DropSequence(
                name: "WALLETTRANS_SEQ",
                schema: "MYAPPUSER");

            migrationBuilder.RenameTable(
                name: "WALLETTRANSACTIONS",
                schema: "MYAPPUSER",
                newName: "WalletTransactions",
                newSchema: "MYAPPUSER");

            migrationBuilder.RenameTable(
                name: "WALLETS",
                schema: "MYAPPUSER",
                newName: "Wallets",
                newSchema: "MYAPPUSER");

            migrationBuilder.RenameTable(
                name: "PASSENGERS",
                schema: "MYAPPUSER",
                newName: "Passengers",
                newSchema: "MYAPPUSER");

            migrationBuilder.RenameTable(
                name: "BOOKINGS",
                schema: "MYAPPUSER",
                newName: "Bookings",
                newSchema: "MYAPPUSER");

            migrationBuilder.RenameTable(
                name: "BOOKED_TICKETS",
                schema: "MYAPPUSER",
                newName: "BookedTickets",
                newSchema: "MYAPPUSER");

            migrationBuilder.RenameColumn(
                name: "STATUS",
                schema: "MYAPPUSER",
                table: "WalletTransactions",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "AMOUNT",
                schema: "MYAPPUSER",
                table: "WalletTransactions",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "ID",
                schema: "MYAPPUSER",
                table: "WalletTransactions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "WALLET_ID",
                schema: "MYAPPUSER",
                table: "WalletTransactions",
                newName: "WalletId");

            migrationBuilder.RenameColumn(
                name: "TRANSACTION_TYPE",
                schema: "MYAPPUSER",
                table: "WalletTransactions",
                newName: "TransactionType");

            migrationBuilder.RenameColumn(
                name: "BALANCE",
                schema: "MYAPPUSER",
                table: "Wallets",
                newName: "Balance");

            migrationBuilder.RenameColumn(
                name: "ID",
                schema: "MYAPPUSER",
                table: "Wallets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "USER_ID",
                schema: "MYAPPUSER",
                table: "Wallets",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "GENDER",
                schema: "MYAPPUSER",
                table: "Passengers",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "AGE",
                schema: "MYAPPUSER",
                table: "Passengers",
                newName: "Age");

            migrationBuilder.RenameColumn(
                name: "ID",
                schema: "MYAPPUSER",
                table: "Passengers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LAST_NAME",
                schema: "MYAPPUSER",
                table: "Passengers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "FIRST_NAME",
                schema: "MYAPPUSER",
                table: "Passengers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "BOOKING_ID",
                schema: "MYAPPUSER",
                table: "Passengers",
                newName: "BookingId");

            migrationBuilder.RenameColumn(
                name: "AADHAAR_NUMBER",
                schema: "MYAPPUSER",
                table: "Passengers",
                newName: "AadhaarNumber");

            migrationBuilder.RenameColumn(
                name: "STATUS",
                schema: "MYAPPUSER",
                table: "Bookings",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "ID",
                schema: "MYAPPUSER",
                table: "Bookings",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "USER_ID",
                schema: "MYAPPUSER",
                table: "Bookings",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "TOTAL_PRICE",
                schema: "MYAPPUSER",
                table: "Bookings",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "FLIGHT_ID",
                schema: "MYAPPUSER",
                table: "Bookings",
                newName: "FlightId");

            migrationBuilder.RenameColumn(
                name: "BOOKING_TIME",
                schema: "MYAPPUSER",
                table: "Bookings",
                newName: "BookingTime");

            migrationBuilder.RenameColumn(
                name: "STATUS",
                schema: "MYAPPUSER",
                table: "BookedTickets",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "PRICE",
                schema: "MYAPPUSER",
                table: "BookedTickets",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "ID",
                schema: "MYAPPUSER",
                table: "BookedTickets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PASSENGER_ID",
                schema: "MYAPPUSER",
                table: "BookedTickets",
                newName: "PassengerId");

            migrationBuilder.RenameColumn(
                name: "FLIGHT_CLASS",
                schema: "MYAPPUSER",
                table: "BookedTickets",
                newName: "FlightClass");

            migrationBuilder.RenameColumn(
                name: "CANCELLATION_TIME",
                schema: "MYAPPUSER",
                table: "BookedTickets",
                newName: "CancellationTime");

            migrationBuilder.RenameColumn(
                name: "BOOKING_ID",
                schema: "MYAPPUSER",
                table: "BookedTickets",
                newName: "BookingId");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "MYAPPUSER",
                table: "WalletTransactions",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                schema: "MYAPPUSER",
                table: "WalletTransactions",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(10,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Id",
                schema: "MYAPPUSER",
                table: "WalletTransactions",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldDefaultValueSql: "WALLETTRANS_SEQ.NEXTVAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "WalletId",
                schema: "MYAPPUSER",
                table: "WalletTransactions",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "TransactionTime",
                schema: "MYAPPUSER",
                table: "WalletTransactions",
                type: "TIMESTAMP(7)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                schema: "MYAPPUSER",
                table: "Wallets",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "NUMBER(10,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Id",
                schema: "MYAPPUSER",
                table: "Wallets",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldDefaultValueSql: "WALLETS_SEQ.NEXTVAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "UserId",
                schema: "MYAPPUSER",
                table: "Wallets",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ID",
                schema: "MYAPPUSER",
                table: "USERS",
                type: "DECIMAL(18,2)",
                nullable: false,
                defaultValueSql: "USERS_SEQ.NEXTVAL",
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldDefaultValueSql: "USERS_SEQ.NEXTVAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Age",
                schema: "MYAPPUSER",
                table: "Passengers",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Id",
                schema: "MYAPPUSER",
                table: "Passengers",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "BookingId",
                schema: "MYAPPUSER",
                table: "Passengers",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SOURCE_AIRPORT_ID",
                schema: "MYAPPUSER",
                table: "FLIGHTS",
                type: "DECIMAL(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,0)",
                oldPrecision: 18,
                oldScale: 0,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DESTINATION_AIRPORT_ID",
                schema: "MYAPPUSER",
                table: "FLIGHTS",
                type: "DECIMAL(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,0)",
                oldPrecision: 18,
                oldScale: 0,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DEPARTURE_TIME",
                schema: "MYAPPUSER",
                table: "FLIGHTS",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ARRIVAL_TIME",
                schema: "MYAPPUSER",
                table: "FLIGHTS",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AIRPLANE_ID",
                schema: "MYAPPUSER",
                table: "FLIGHTS",
                type: "DECIMAL(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,0)",
                oldPrecision: 18,
                oldScale: 0,
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AirplanesId",
                schema: "MYAPPUSER",
                table: "FLIGHTS",
                type: "DECIMAL(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AirportsId",
                schema: "MYAPPUSER",
                table: "FLIGHTS",
                type: "DECIMAL(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AirportsId1",
                schema: "MYAPPUSER",
                table: "FLIGHTS",
                type: "DECIMAL(18,2)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PRICE",
                schema: "MYAPPUSER",
                table: "FLIGHT_PRICES",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "FLIGHT_ID",
                schema: "MYAPPUSER",
                table: "FLIGHT_PRICES",
                type: "DECIMAL(10)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,0)",
                oldPrecision: 18,
                oldScale: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "ID",
                schema: "MYAPPUSER",
                table: "FLIGHT_PRICES",
                type: "DECIMAL(18,2)",
                nullable: false,
                defaultValueSql: "FLIGHT_PRICES_SEQ.NEXTVAL",
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldDefaultValueSql: "FLIGHT_PRICES_SEQ.NEXTVAL");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "MYAPPUSER",
                table: "Bookings",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Id",
                schema: "MYAPPUSER",
                table: "Bookings",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "UserId",
                schema: "MYAPPUSER",
                table: "Bookings",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                schema: "MYAPPUSER",
                table: "Bookings",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "FlightId",
                schema: "MYAPPUSER",
                table: "Bookings",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BookingTime",
                schema: "MYAPPUSER",
                table: "Bookings",
                type: "TIMESTAMP(7)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<string>(
                name: "AIRPORT_CODE",
                schema: "MYAPPUSER",
                table: "AIRPORTS",
                type: "NCHAR(3)",
                fixedLength: true,
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(3)",
                oldFixedLength: true,
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "ID",
                schema: "MYAPPUSER",
                table: "AIRPORTS",
                type: "DECIMAL(18,2)",
                nullable: false,
                defaultValueSql: "AIRPORTS_SEQ.NEXTVAL",
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldDefaultValueSql: "AIRPORTS_SEQ.NEXTVAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "TOTAL_SEATS",
                schema: "MYAPPUSER",
                table: "AIRPLANES",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ECONOMY_SEATS",
                schema: "MYAPPUSER",
                table: "AIRPLANES",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BUSINESS_SEATS",
                schema: "MYAPPUSER",
                table: "AIRPLANES",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ID",
                schema: "MYAPPUSER",
                table: "AIRPLANES",
                type: "DECIMAL(18,2)",
                nullable: false,
                defaultValueSql: "AIRPLANES_SEQ.NEXTVAL",
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldDefaultValueSql: "AIRPLANES_SEQ.NEXTVAL");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "MYAPPUSER",
                table: "BookedTickets",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                schema: "MYAPPUSER",
                table: "BookedTickets",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Id",
                schema: "MYAPPUSER",
                table: "BookedTickets",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "PassengerId",
                schema: "MYAPPUSER",
                table: "BookedTickets",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BookingId",
                schema: "MYAPPUSER",
                table: "BookedTickets",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WalletTransactions",
                schema: "MYAPPUSER",
                table: "WalletTransactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallets",
                schema: "MYAPPUSER",
                table: "Wallets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passengers",
                schema: "MYAPPUSER",
                table: "Passengers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "SYS_C008287",
                schema: "MYAPPUSER",
                table: "FLIGHTS",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                schema: "MYAPPUSER",
                table: "Bookings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookedTickets",
                schema: "MYAPPUSER",
                table: "BookedTickets",
                column: "Id");

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
                name: "IX_BookedTickets_PassengerId",
                schema: "MYAPPUSER",
                table: "BookedTickets",
                column: "PassengerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookedTickets_Passengers_PassengerId",
                schema: "MYAPPUSER",
                table: "BookedTickets",
                column: "PassengerId",
                principalSchema: "MYAPPUSER",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FLIGHTS_AIRPLANES_AirplanesId",
                schema: "MYAPPUSER",
                table: "FLIGHTS",
                column: "AirplanesId",
                principalSchema: "MYAPPUSER",
                principalTable: "AIRPLANES",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FLIGHTS_AIRPORTS_AirportsId",
                schema: "MYAPPUSER",
                table: "FLIGHTS",
                column: "AirportsId",
                principalSchema: "MYAPPUSER",
                principalTable: "AIRPORTS",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FLIGHTS_AIRPORTS_AirportsId1",
                schema: "MYAPPUSER",
                table: "FLIGHTS",
                column: "AirportsId1",
                principalSchema: "MYAPPUSER",
                principalTable: "AIRPORTS",
                principalColumn: "ID");
        }
    }
}
