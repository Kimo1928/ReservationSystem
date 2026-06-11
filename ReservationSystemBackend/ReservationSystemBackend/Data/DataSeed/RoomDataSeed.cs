using ReservationSystemBackend.Entities;

namespace ReservationSystemBackend.Data.DataSeed
{
    public class RoomDataSeed
    {
        public static List<Room> Data => new()
    {
        new Room
        {
            Id = 1,
            Name = "Conference Room 1",
            HotelId = 1
        },
        new Room
        {
            Id = 2,
            Name = "Conference Room 2",
            HotelId = 1
        },
        new Room
        {
            Id = 3,
            Name = "Conference Room A",
            HotelId = 2
        }
    };

    }
}
