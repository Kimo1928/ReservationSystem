namespace ReservationSystemBackend.Interfaces
{
    public interface IUnitOfWork
    {
        public IHotelRepository HotelRepository { get; }
        public IRoomRepository RoomRepository { get; }

        public IRoomSlotRepository RoomSlotRepository { get; }
        public IUserRepository UserRepository { get; }

        public IReservationRepository ReservationRepository { get;}

        public ITopicRepository TopicRepository { get; }
        public Task<bool> SaveChangesAsync();

    }
}
