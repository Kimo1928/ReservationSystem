using Microsoft.EntityFrameworkCore;
using ReservationSystemBackend.Data.DTOs;
using ReservationSystemBackend.Entities;
using ReservationSystemBackend.Interfaces;
using ReservationSystemBackend.Repositories;

namespace ReservationSystemBackend.Services
{
    public class HotelService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HotelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<bool> CreateHotel(CreateHotelDTO createHotelDto) {

            var hotel = new Hotel
            {
                Name = createHotelDto.Name,

                Rooms = createHotelDto.Rooms.Select(r => new Room
                {
                    Name = r.Name,
                    

                    RoomSlots = r.RoomSlots.Select(s => new RoomSlot
                    {
                       
                        StartTime = s.StartTime
                    }).ToList()

                }).ToList()
            };

             _unitOfWork.HotelRepository.AddHotel(hotel);

            return await _unitOfWork.SaveChangesAsync();
        }


        public async Task<List<HotelDTO>> GetAllHotels() { 
        
            var hotels = await _unitOfWork.HotelRepository.GetAllHotels();
            
                var returnedHotels = hotels.Select(x => new HotelDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Rooms = x.Rooms.Select(y=>new RoomDTO { 
                        
                    Name = y.Name,
                    RoomSlots = y.RoomSlots.Select(z =>new RoomSlotDTO { 
                    
                    StartTime= z.StartTime
                    }).ToList(),

                    }).ToList()

                }).ToList();
            return returnedHotels;
        
        }

    }
    }

