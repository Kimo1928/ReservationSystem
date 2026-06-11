using Microsoft.EntityFrameworkCore;
using ReservationSystemBackend.Data;
using ReservationSystemBackend.Entities;
using ReservationSystemBackend.Interfaces;

namespace ReservationSystemBackend.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly AppDbContext _context;
        public ReservationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddReservationAsync(Reservation reservation)
        {
           await _context.Reservations.AddAsync(reservation);
        }

        public async Task<List<RoomSlot>> GetAvailableRoomSlotsAsync(int topicId, int investorId, int presenterId)
        {
            var investorAvaliabity = await
                _context.UserTopicAvaliabilities
                .FirstOrDefaultAsync(x => x.TopicId == topicId && x.UserId == investorId);

            var presenterAvaliablity = await
                _context.UserTopicAvaliabilities
                .FirstOrDefaultAsync(x => x.TopicId == topicId && x.UserId == presenterId);
                    
            
             var overlapStart = investorAvaliabity.AvaliabilityFrom >
                               presenterAvaliablity.AvaliabilityFrom
                                ? investorAvaliabity.AvaliabilityFrom
                                : presenterAvaliablity.AvaliabilityFrom;

             var overlapEnd = investorAvaliabity.AvaliabilityTo <
                              presenterAvaliablity.AvaliabilityTo
                                ? investorAvaliabity.AvaliabilityTo
                                : presenterAvaliablity.AvaliabilityTo;

            var slots = await _context.RoomSlots
                .Include(x=>x.Room)
                .ThenInclude(x=>x.Hotel)
                .Where(
                x=>x.StartTime >= overlapStart &&
                x.StartTime.AddHours(1) <= overlapEnd
                && !_context.Reservations.Any(r=>r.RoomSlotId==x.Id)
                ).ToListAsync();


            return slots;


        }
    }
}
