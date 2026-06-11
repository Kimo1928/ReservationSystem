using Microsoft.EntityFrameworkCore;
using ReservationSystemBackend.Data;
using ReservationSystemBackend.Entities;
using ReservationSystemBackend.Interfaces;

namespace ReservationSystemBackend.Repositories
{
    public class HotelRepository : IHotelRepository
    {

        private readonly AppDbContext _context;

        public HotelRepository(AppDbContext context)
        {
            _context = context;
        }

            public  void AddHotel(Hotel hotel)
        {
             _context.Hotels.Add(hotel);
        }

        public async Task<List<Hotel>> GetAllHotels() {
        return await _context.Hotels
                    .Include(x=>x.Rooms)
                    .ThenInclude(x=>x.RoomSlots)
                    .ToListAsync();
        }
    }
}
