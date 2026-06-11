using ReservationSystemBackend.Data;
using ReservationSystemBackend.Interfaces;

namespace ReservationSystemBackend.Repositories
{
    public class UnitOfWork(AppDbContext context):IUnitOfWork
    {
        private IHotelRepository? _hotelRepository;
        private IUserRepository? _userRepository;
        private IRoomRepository? _roomRepository;
        private ITopicRepository? _topicRepository;

        private IRoomSlotRepository? _roomSlotRepository;

        private IReservationRepository? _reservationRepository;
        public IHotelRepository HotelRepository => _hotelRepository ?? new HotelRepository(context);

        public IRoomRepository RoomRepository => _roomRepository ?? new RoomRepository(context);

        public IUserRepository UserRepository => _userRepository ?? new UserRepository(context);
        public IRoomSlotRepository RoomSlotRepository => _roomSlotRepository ?? new RoomSlotRepository(context);
        public IReservationRepository ReservationRepository => _reservationRepository ?? new ReservationRepository(context);

        public ITopicRepository TopicRepository => _topicRepository ?? new TopicRepository(context);    

        public async Task<bool> SaveChangesAsync()
        {
           return await context.SaveChangesAsync()>0;
        }
    }
}
