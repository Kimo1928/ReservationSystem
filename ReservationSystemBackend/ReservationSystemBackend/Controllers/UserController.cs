using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationSystemBackend.Data.DTOs;
using ReservationSystemBackend.Services;

namespace ReservationSystemBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserService _userService;

        public UserController(UserService userService) { 
        _userService = userService;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserDTO createUserDTO) {
            if (await _userService.CreateUser(createUserDTO))
                  return Ok(new
                {
                    success = true,
                    message = "User Created Successfully"
                });
            return BadRequest(new
            {
                success = false,
                message = "Failed To Create User"
            });


        }


        [HttpGet("GetMatchingPresenter")]
        public async Task<IActionResult> GetPresenters([FromQuery] int topic, int investor) { 
           var presenters= await _userService.GetMatchingPresenters(topic, investor);
            if(presenters==null)
                return NotFound();
            return Ok(presenters);
        
        
        }


        [HttpGet("GettingAllInvestors")]
        public async Task<IActionResult> GetInvestors() {
        
        var investors=await _userService.GetAllInvestors();
            if(investors==null)
                return NotFound();
            return Ok(investors);
        
        }

        [HttpGet("GettingAllPresenters")]
        public async Task<IActionResult> GetPresenters()
        {

            var presenters = await _userService.GetAllPresenters();
            if (presenters == null)
                return NotFound();
            return Ok(presenters);

        }
    }
}
