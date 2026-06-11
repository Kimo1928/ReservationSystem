using ReservationSystemBackend.Data;
using ReservationSystemBackend.Entities;
using ReservationSystemBackend.Interfaces;

namespace ReservationSystemBackend.Repositories
{
    public class RoomRepository : IRoomRepository
    {

        private readonly AppDbContext _context; 

        public RoomRepository(AppDbContext context) { _context = context; }

        public async Task AddRangeAsync(List<Room> rooms) {
            await _context.Rooms.AddRangeAsync(rooms);
        }

       
    }
}
