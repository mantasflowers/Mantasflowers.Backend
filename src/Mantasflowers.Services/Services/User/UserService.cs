using AutoMapper;
using Mantasflowers.Contracts.User.Response;
using Mantasflowers.Services.Repositories;
using Mantasflowers.Services.Services.Exceptions;
using System;
using System.Threading.Tasks;

namespace Mantasflowers.Services.Services.User
{
    public class UserService : IUserService
    {
        private readonly FirebaseService.FirebaseService _fbService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(FirebaseService.FirebaseService fbService,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _fbService = fbService;
        }

        public async Task<GetUserResponse> GetUserByUidAsync(string uid)
        {
            var user = await _userRepository.GetUserByUidAsync(uid);
            if (user == null)
            {
                throw new FirebaseUidNotFoundException("No user could be found for Uid");
            }
            
            var getUserResponse = _mapper.Map<GetUserResponse>(user);

            return getUserResponse;
        }

        public async Task<GetDetailedUserResponse> GetDetailedUserByUidAsync(string uid,
            string loginEmail,
            bool isLoginEmailVerified)
        {
            var user = await _userRepository.GetDetailedUserByUidAsync(uid);
            if (user == null)
            {
                throw new FirebaseUidNotFoundException("No user could be found for Uid");
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
            var user = await _userRepository.GetDetailedUserByIdAsync(id);
            if (user == null)
            {
                throw new UserNotFoundException("No user could be found for id");
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
            var user = await _userRepository.GetAsync(id);

            return user?.Uid;
        }

        public async Task<PostCreateUserResponse> CreateUserAsync(string uid)
        {
            var user = new Domain.Entities.User
            {
                Uid = uid
            };

            await _userRepository.CreateAsync(user);
            var resposne = _mapper.Map<PostCreateUserResponse>(user);

            return resposne;
        }
    }
}
