using ReservationSystemBackend.Data;
using ReservationSystemBackend.Entities;
using ReservationSystemBackend.Interfaces;

namespace ReservationSystemBackend.Repositories
{
    public class RoomSlotRepository : IRoomSlotRepository

    {
        private readonly AppDbContext _context;
        public RoomSlotRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddRangeAsync(List<RoomSlot> roomSlots)
        {
            await _context.RoomSlots.AddRangeAsync(roomSlots);
        }
    }
}
