using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReservationSystemBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    HotelId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelId1",
                        column: x => x.HotelId1,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserTopicAvaliabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AvaliabilityFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvaliabilityTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTopicAvaliabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTopicAvaliabilities_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTopicAvaliabilities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTopicAvaliabilities_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoomSlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoomId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomSlots_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomSlots_Rooms_RoomId1",
                        column: x => x.RoomId1,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomSlotId = table.Column<int>(type: "int", nullable: false),
                    InvestorId = table.Column<int>(type: "int", nullable: false),
                    PresenterId = table.Column<int>(type: "int", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    RoomSlotId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_RoomSlots_RoomSlotId",
                        column: x => x.RoomSlotId,
                        principalTable: "RoomSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_RoomSlots_RoomSlotId1",
                        column: x => x.RoomSlotId1,
                        principalTable: "RoomSlots",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservations_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_InvestorId",
                        column: x => x.InvestorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_PresenterId",
                        column: x => x.PresenterId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hilton" },
                    { 2, "Marriott" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Finance" },
                    { 2, "IT" },
                    { 3, "Restaurants" },
                    { 4, "Real Estate" },
                    { 5, "Retail" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Mobile", "Name", "UserType" },
                values: new object[,]
                {
                    { 1, "01000000000", "Admin", 1 },
                    { 2, "01011111111", "CIB", 2 },
                    { 3, "01022222222", "EFG Hermes", 2 },
                    { 4, "01033333333", "Oltob", 3 },
                    { 5, "01044444444", "Tech Solutions", 3 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "HotelId", "HotelId1", "Name" },
                values: new object[,]
                {
                    { 1, 1, null, "Conference Room 1" },
                    { 2, 1, null, "Conference Room 2" },
                    { 3, 2, null, "Conference Room A" }
                });

            migrationBuilder.InsertData(
                table: "UserTopicAvaliabilities",
                columns: new[] { "Id", "AvaliabilityFrom", "AvaliabilityTo", "TopicId", "UserId", "UserId1" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 6, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, null },
                    { 2, new DateTime(2026, 6, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, null },
                    { 3, new DateTime(2026, 6, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, null },
                    { 4, new DateTime(2026, 6, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, null },
                    { 5, new DateTime(2026, 6, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, null }
                });

            migrationBuilder.InsertData(
                table: "RoomSlots",
                columns: new[] { "Id", "RoomId", "RoomId1", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2026, 6, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, null, new DateTime(2026, 6, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, null, new DateTime(2026, 6, 1, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, null, new DateTime(2026, 6, 1, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, null, new DateTime(2026, 6, 1, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 3, null, new DateTime(2026, 6, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 3, null, new DateTime(2026, 6, 1, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 3, null, new DateTime(2026, 6, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_InvestorId",
                table: "Reservations",
                column: "InvestorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PresenterId",
                table: "Reservations",
                column: "PresenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomSlotId",
                table: "Reservations",
                column: "RoomSlotId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomSlotId1",
                table: "Reservations",
                column: "RoomSlotId1",
                unique: true,
                filter: "[RoomSlotId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TopicId",
                table: "Reservations",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId1",
                table: "Rooms",
                column: "HotelId1");

            migrationBuilder.CreateIndex(
                name: "IX_RoomSlots_RoomId",
                table: "RoomSlots",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomSlots_RoomId1",
                table: "RoomSlots",
                column: "RoomId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserTopicAvaliabilities_TopicId",
                table: "UserTopicAvaliabilities",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTopicAvaliabilities_UserId",
                table: "UserTopicAvaliabilities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTopicAvaliabilities_UserId1",
                table: "UserTopicAvaliabilities",
                column: "UserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "UserTopicAvaliabilities");

            migrationBuilder.DropTable(
                name: "RoomSlots");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
