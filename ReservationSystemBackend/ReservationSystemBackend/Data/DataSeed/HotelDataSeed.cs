using ReservationSystemBackend.Entities;

namespace ReservationSystemBackend.Data.DataSeed
{
    public class HotelDataSeed
    {
        public static List<Hotel> Data => new()
    {
        new Hotel
        {
            Id = 1,
            Name = "Hilton"
        },
        new Hotel
        {
            Id = 2,
            Name = "Marriott"
        }
    };
    }
}
