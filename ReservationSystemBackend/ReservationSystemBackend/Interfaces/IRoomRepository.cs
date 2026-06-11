using ReservationSystemBackend.Entities;

namespace ReservationSystemBackend.Interfaces
{
    public interface IRoomRepository
    {
        Task AddRangeAsync(List<Room> rooms); 
    }
}
