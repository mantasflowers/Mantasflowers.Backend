using AutoMapper;
using Mantasflowers.Contracts.User.Response;
using Mantasflowers.Services.DataAccess;
using Mantasflowers.Services.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Mantasflowers.Services.Services.User
{
    public class UserService : IUserService
    {
        private readonly FirebaseService.FirebaseService _fbService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(FirebaseService.FirebaseService fbService,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fbService = fbService;
        }

        public async Task<GetUserResponse> GetUserByUidAsync(string uid)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUidAsync(uid);
            if (user == null)
            {
                throw new FirebaseUidNotFoundException($"No user could be found for {nameof(uid)}");
            }
            
            var getUserResponse = _mapper.Map<GetUserResponse>(user);

            return getUserResponse;
        }

        public async Task<GetDetailedUserResponse> GetDetailedUserByUidAsync(string uid,
            string loginEmail,
            bool isLoginEmailVerified)
        {
            var user = await _unitOfWork.UserRepository.GetDetailedUserByUidAsync(uid);
            if (user == null)
            {
                throw new FirebaseUidNotFoundException($"No user could be found for {nameof(uid)}");
            }

            var getDetailedUserResponse = _mapper.Map<GetDetailedUserResponse>(user,
                o => o.AfterMap((source, destination) =>
                {
                    destination.LoginEmail = loginEmail;
                    destination.IsLoginEmailVerified = isLoginEmailVerified;
                }));

            return getDetailedUserResponse;
        }

        public async Task<GetDetailedUserResponse> GetDetailedUserByGuidAsync(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetDetailedUserByIdAsync(id);
            if (user == null)
            {
                throw new UserNotFoundException($"No user could be found for {nameof(id)}");
            }

            var userRecord = await _fbService.GetUserByUidAsync(user.Uid);

            var getDetailedUserResponse = _mapper.Map<GetDetailedUserResponse>(user,
                o => o.AfterMap((source, destination) =>
                {
                    destination.LoginEmail = userRecord.Email;
                    destination.IsLoginEmailVerified = userRecord.EmailVerified;
                }));

            return getDetailedUserResponse;
        }

        public async Task<string> GetUserUidByGuidAsync(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(id);

            return user?.Uid;
        }

        public async Task<PostCreateUserResponse> CreateUserAsync(string uid)
        {
            var user = new Domain.Entities.User
            {
                Uid = uid
            };

            try
            {
                await _unitOfWork.UserRepository.CreateAsync(user);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new FailedToAddDatabaseResourceException("Failed to create user");
            }

            var resposne = _mapper.Map<PostCreateUserResponse>(user);

            return resposne;
        }
    }
}
