using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservationSystemBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovingReservationError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_RoomSlots_RoomSlotId1",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RoomSlotId1",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "RoomSlotId1",
                table: "Reservations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomSlotId1",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomSlotId1",
                table: "Reservations",
                column: "RoomSlotId1",
                unique: true,
                filter: "[RoomSlotId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_RoomSlots_RoomSlotId1",
                table: "Reservations",
                column: "RoomSlotId1",
                principalTable: "RoomSlots",
                principalColumn: "Id");
        }
    }
}
