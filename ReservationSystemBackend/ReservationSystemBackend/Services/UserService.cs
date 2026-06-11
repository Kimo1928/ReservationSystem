using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using ReservationSystemBackend.Data.DTOs;
using ReservationSystemBackend.Entities;
using ReservationSystemBackend.Interfaces;

namespace ReservationSystemBackend.Services
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        public async Task<bool> CreateUser(CreateUserDTO createUserDTO) {

            var user = new User
            {
                Name = createUserDTO.Name,
                Mobile = createUserDTO.Mobile,
                UserType = (UserTypes)createUserDTO.UserType,
                UserTopicAvaliabilities = createUserDTO.UserTopicAvaliabilityDTOs
            .Select(u => new UserTopicAvaliability
            {
                TopicId = u.TopicId,
                AvaliabilityFrom = u.AvaliabilityFrom,
                AvaliabilityTo = u.AvaliabilityTo,
            }).ToList()

            };
            _unitOfWork.UserRepository.AddUser(user);
            return await _unitOfWork.SaveChangesAsync();
        }


        public async Task<List<PresenterMatchDTO>> GetMatchingPresenters(
     int topicId,
     int investorId)
        {
            var investorAvailability = await _unitOfWork.UserRepository
                .GetInvestorAvailabilityAsync(investorId, topicId);

            if (investorAvailability == null)
                return new List<PresenterMatchDTO>();

            var presenters = await _unitOfWork.UserRepository
                .GetInterestedPresenterAsync(topicId, investorId);

            return presenters.Select(x =>
            {
                var presenterAvailability = x.UserTopicAvaliabilities
                    .First(a => a.TopicId == topicId);

                var overlapFrom =
                    investorAvailability.AvaliabilityFrom > presenterAvailability.AvaliabilityFrom
                        ? investorAvailability.AvaliabilityFrom
                        : presenterAvailability.AvaliabilityFrom;

                var overlapTo =
                    investorAvailability.AvaliabilityTo < presenterAvailability.AvaliabilityTo
                        ? investorAvailability.AvaliabilityTo
                        : presenterAvailability.AvaliabilityTo;

                return new PresenterMatchDTO
                {
                    UserId = x.Id,
                    Name = x.Name,
                    Mobile = x.Mobile,
                    OverlapFrom = overlapFrom,
                    OverlapTo = overlapTo
                };
            }).ToList();
        }


        public async Task<List<UserDTO>> GetAllInvestors() { 
        
            var investors= await _unitOfWork.UserRepository.GetAllInvestors();
            var returnedInvestors = investors.Select(x => new UserDTO
            {

                Id = x.Id,
                Name = x.Name,
                Mobile = x.Mobile,
                UserTopicAvaliabilityDTOs = x.UserTopicAvaliabilities.Select(y=>new UserTopicAvaliabilityDTO { 
                
                AvaliabilityFrom = y.AvaliabilityFrom,
                AvaliabilityTo = y.AvaliabilityTo,
                TopicId = y.TopicId,
                
                }).ToList(),

            }).ToList();
            return returnedInvestors;  
        }


        public async Task<List<UserDTO>> GetAllPresenters()
        {

            var presenters = await _unitOfWork.UserRepository.GetAllPresenters();
            var returnedPresenters = presenters.Select(x => new UserDTO
            {

                Id = x.Id,
                Name = x.Name,
                Mobile = x.Mobile,
                UserTopicAvaliabilityDTOs = x.UserTopicAvaliabilities.Select(y => new UserTopicAvaliabilityDTO
                {

                    AvaliabilityFrom = y.AvaliabilityFrom,
                    AvaliabilityTo = y.AvaliabilityTo,
                    TopicId = y.TopicId,

                }).ToList(),

            }).ToList();
            return returnedPresenters;
        }

    }
}
