using ReservationSystemBackend.Entities;

namespace ReservationSystemBackend.Interfaces
{
    public interface IHotelRepository
    {
        public void AddHotel(Hotel hotel);

        public Task<List<Hotel>> GetAllHotels();
        
        
        
    }
}
