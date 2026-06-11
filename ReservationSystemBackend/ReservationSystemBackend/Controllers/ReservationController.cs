using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationSystemBackend.Data.DTOs;
using ReservationSystemBackend.Entities;
using ReservationSystemBackend.Interfaces;

namespace ReservationSystemBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase { 
   
        private readonly IUnitOfWork _unitOfWork;

        public ReservationController(IUnitOfWork unitOfWork) {

            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAvaliableRooms")]
        public async Task<IActionResult> GetAvaliableRooms([FromQuery] int topicId, int investorId, int presenterId) {

            var slots = await _unitOfWork.ReservationRepository.GetAvailableRoomSlotsAsync(topicId, investorId, presenterId);
            var slotsReturned =
                slots.Select(x => new RoomSlotDetailsDTO
                {
                    RoomSlotId = x.Id,
                    RoomName = x.Room.Name,
                    HotelName = x.Room.Hotel.Name,
                    StartTime = x.StartTime,
                    EndTime = x.StartTime.AddHours(1)



                });
            if (slotsReturned == null) {
                return NotFound();
            }
            return Ok(slotsReturned);


        




    }
        [HttpPost("AddReservation")]
        public async Task<IActionResult> CreateReservation(CreateReservationDTO createReservationDTO) {

            var reservation = new Reservation
            {
                RoomSlotId = createReservationDTO.RoomSlotId,
                InvestorId = createReservationDTO.InvestorId,
                PresenterId = createReservationDTO.PresenterId,
                TopicId = createReservationDTO.TopicId

            };
            await _unitOfWork.ReservationRepository.AddReservationAsync(reservation);
            if (await _unitOfWork.SaveChangesAsync())
                return Ok( new { 
                success=true,
                message="Reservation Created Successfully"
            });
            return BadRequest(new
            {
                success = false,
                message = "Failed To Create Reservation"
            });


        }

    }
}
