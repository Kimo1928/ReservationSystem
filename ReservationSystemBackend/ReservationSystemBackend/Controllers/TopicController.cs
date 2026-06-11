using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationSystemBackend.Data.DTOs;
using ReservationSystemBackend.Interfaces;

namespace ReservationSystemBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TopicController(IUnitOfWork unitOfWork) { 
        _unitOfWork = unitOfWork;   
        }

        [HttpGet("GettingAllTopics")]
         public async Task<IActionResult> GetAllTopics() { 
       var topics = await _unitOfWork.TopicRepository.GetAllTopics();
            var returnedTopics = topics.Select(x=>new TopicDTO { 
                Id = x.Id,
                Name = x.Name
            
            }).ToList();
        if (returnedTopics != null ) return Ok(returnedTopics);
        return BadRequest("Can't find specified Topics");
        }
    }
}
