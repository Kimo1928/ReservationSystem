using Microsoft.EntityFrameworkCore;
using ReservationSystemBackend.Data;
using ReservationSystemBackend.Entities;
using ReservationSystemBackend.Interfaces;

namespace ReservationSystemBackend.Repositories
{
    public class TopicRepository : ITopicRepository
    {   private readonly AppDbContext _context;

        public TopicRepository(AppDbContext context) { 
        _context = context;
        }
        public async Task<List<Topic>> GetAllTopics() { 
        
        return await _context.Topics.ToListAsync(); 
        
        }

       
    }
}
