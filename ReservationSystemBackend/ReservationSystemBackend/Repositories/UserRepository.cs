using Microsoft.EntityFrameworkCore;
using ReservationSystemBackend.Data;
using ReservationSystemBackend.Entities;
using ReservationSystemBackend.Interfaces;

namespace ReservationSystemBackend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddUser(User user) {
        
        _context.Users.Add(user);
        }
        public async Task AddInvestorAsync(User investor)
        {
            await _context.Users.AddAsync(investor);
        }

        public async Task AddPresenterAsync(User presenter)
        {
            await _context.Users.AddAsync(presenter);
        }


        public async Task<List<User>> GetInterestedPresenterAsync(int topicId,int investorId) {
            var investorAvaliabity = await
                  _context.UserTopicAvaliabilities
                  .FirstOrDefaultAsync(x => x.TopicId == topicId && x.UserId == investorId);
            if (investorAvaliabity == null)
                return new List<User>();
            return await _context.Users
                .Where(u => u.UserType == UserTypes.Presenter)
                .Where(u => u.UserTopicAvaliabilities.Any(a =>
                    a.TopicId == topicId &&
                    a.AvaliabilityFrom < investorAvaliabity.AvaliabilityTo &&
                    a.AvaliabilityTo > investorAvaliabity.AvaliabilityFrom))
                .Include(x=>x.UserTopicAvaliabilities)
                .ToListAsync();




        }

        public async Task<UserTopicAvaliability> GetInvestorAvailabilityAsync(int investorId, int topicId) {

            return  await _context.UserTopicAvaliabilities
                .SingleOrDefaultAsync(x => x.TopicId == topicId && x.UserId == investorId);
        
        }


        public async Task<List<User>> GetAllInvestors() { 
            return await _context.Users.Where(x=>x.UserType==UserTypes.Investor)
                .Include(x=>x.UserTopicAvaliabilities)
                .ToListAsync();
        
        }

        public async Task<List<User>> GetAllPresenters() { 
        
            return await _context.Users.Where(x=>x.UserType==UserTypes.Presenter)
                    .Include(x=>x.UserTopicAvaliabilities)
                    .ToListAsync();
        }
    }
}
