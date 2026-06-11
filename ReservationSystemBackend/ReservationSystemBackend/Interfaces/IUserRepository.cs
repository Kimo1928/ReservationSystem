using ReservationSystemBackend.Entities;

namespace ReservationSystemBackend.Interfaces
{
    public interface IUserRepository
    {
        public void AddUser(User user);
        public Task AddInvestorAsync(User investor);

        public Task AddPresenterAsync(User presenter);

        public Task<List<User>> GetInterestedPresenterAsync(int topicId,int investorId);

        public Task<UserTopicAvaliability> GetInvestorAvailabilityAsync(int investorId, int topicId);


        public Task<List<User>> GetAllInvestors();
        public Task<List<User>> GetAllPresenters();
    }
}
