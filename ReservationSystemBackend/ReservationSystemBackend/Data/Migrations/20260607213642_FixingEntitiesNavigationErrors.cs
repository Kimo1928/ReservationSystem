using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservationSystemBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixingEntitiesNavigationErrors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hotels_HotelId1",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomSlots_Rooms_RoomId1",
                table: "RoomSlots");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTopicAvaliabilities_Users_UserId1",
                table: "UserTopicAvaliabilities");

            migrationBuilder.DropIndex(
                name: "IX_UserTopicAvaliabilities_UserId1",
                table: "UserTopicAvaliabilities");

            migrationBuilder.DropIndex(
                name: "IX_RoomSlots_RoomId1",
                table: "RoomSlots");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_HotelId1",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserTopicAvaliabilities");

            migrationBuilder.DropColumn(
                name: "RoomId1",
                table: "RoomSlots");

            migrationBuilder.DropColumn(
                name: "HotelId1",
                table: "Rooms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "UserTopicAvaliabilities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId1",
                table: "RoomSlots",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotelId1",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "RoomSlots",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoomId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "RoomSlots",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoomId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "RoomSlots",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoomId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "RoomSlots",
                keyColumn: "Id",
                keyValue: 4,
                column: "RoomId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "RoomSlots",
                keyColumn: "Id",
                keyValue: 5,
                column: "RoomId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "RoomSlots",
                keyColumn: "Id",
                keyValue: 6,
                column: "RoomId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "RoomSlots",
                keyColumn: "Id",
                keyValue: 7,
                column: "RoomId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "RoomSlots",
                keyColumn: "Id",
                keyValue: 8,
                column: "RoomId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "HotelId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "HotelId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "HotelId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "UserTopicAvaliabilities",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "UserTopicAvaliabilities",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "UserTopicAvaliabilities",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "UserTopicAvaliabilities",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "UserTopicAvaliabilities",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserId1",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_UserTopicAvaliabilities_UserId1",
                table: "UserTopicAvaliabilities",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_RoomSlots_RoomId1",
                table: "RoomSlots",
                column: "RoomId1");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId1",
                table: "Rooms",
                column: "HotelId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Hotels_HotelId1",
                table: "Rooms",
                column: "HotelId1",
                principalTable: "Hotels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomSlots_Rooms_RoomId1",
                table: "RoomSlots",
                column: "RoomId1",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTopicAvaliabilities_Users_UserId1",
                table: "UserTopicAvaliabilities",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
