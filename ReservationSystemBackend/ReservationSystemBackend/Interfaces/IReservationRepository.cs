using ReservationSystemBackend.Entities;

namespace ReservationSystemBackend.Interfaces
{
    public interface IReservationRepository
    {


        public Task<List<RoomSlot>> GetAvailableRoomSlotsAsync(int topicId,int investerId,int presenterId);

        public Task AddReservationAsync(Reservation reservation);

    }
}
