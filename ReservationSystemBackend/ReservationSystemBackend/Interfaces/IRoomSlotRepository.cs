using ReservationSystemBackend.Entities;

namespace ReservationSystemBackend.Interfaces
{
    public interface IRoomSlotRepository
    {
        public Task AddRangeAsync(List<RoomSlot> roomSlots);
    }
}
