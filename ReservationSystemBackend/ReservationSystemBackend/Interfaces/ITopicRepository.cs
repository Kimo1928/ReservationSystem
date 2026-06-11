using ReservationSystemBackend.Entities;

namespace ReservationSystemBackend.Interfaces
{
    public interface ITopicRepository
    {
        public Task<List<Topic>> GetAllTopics();
    }
}
