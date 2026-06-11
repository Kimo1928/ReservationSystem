using ReservationSystemBackend.Entities;

namespace ReservationSystemBackend.Data.DataSeed
{
    public class RoomSlotDataSeed
    {
        public static List<RoomSlot> Data => new()
    {
       
        new RoomSlot { Id = 1, RoomId = 1, StartTime = new DateTime(2026, 6, 1, 13, 0, 0) },
        new RoomSlot { Id = 2, RoomId = 1, StartTime = new DateTime(2026, 6, 1, 14, 0, 0) },
        new RoomSlot { Id = 3, RoomId = 1, StartTime = new DateTime(2026, 6, 1, 15, 0, 0) },

        
        new RoomSlot { Id = 4, RoomId = 2, StartTime = new DateTime(2026, 6, 1, 13, 0, 0) },
        new RoomSlot { Id = 5, RoomId = 2, StartTime = new DateTime(2026, 6, 1, 15, 0, 0) },

       
        new RoomSlot { Id = 6, RoomId = 3, StartTime = new DateTime(2026, 6, 1, 10, 0, 0) },
        new RoomSlot { Id = 7, RoomId = 3, StartTime = new DateTime(2026, 6, 1, 11, 0, 0) },
        new RoomSlot { Id = 8, RoomId = 3, StartTime = new DateTime(2026, 6, 1, 12, 0, 0) }
    };
    }
}
