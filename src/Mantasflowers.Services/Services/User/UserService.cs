using AutoMapper;
using Mantasflowers.Contracts.User.Request;
using Mantasflowers.Contracts.User.Response;
using Mantasflowers.Services.DataAccess;
using Mantasflowers.Services.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

        public async Task<PostCreateUserResponse> CreateUserAsync(string email, string password)
        {
            var firebaseUser = await _fbService.CreateUserAsync(email, password);

            if (string.IsNullOrWhiteSpace(firebaseUser.Uid))
            {
                throw new FirebaseUidNotFoundException("Firebase did not return Uid after creating user");
            }

            var user = new Domain.Entities.User
            {
                Uid = firebaseUser.Uid
            };

            try
            {
                await _unitOfWork.UserRepository.CreateAsync(user);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                await _fbService.DeleteUserByUidAsync(firebaseUser.Uid);
                throw new FailedToAddDatabaseResourceException("Failed to create user");
            }

            var resposne = _mapper.Map<PostCreateUserResponse>(user,
                o => o.AfterMap((source, destination) =>
                {
                    destination.LoginEmail = firebaseUser.Email;
                }));

            return resposne;
        }

        public async Task DeleteUserAsync(string uid)
        {
            var user = await _unitOfWork.UserRepository.GetUserGraphByUidAsync(uid);

            if (user == null)
            {
                throw new FirebaseUidNotFoundException($"No database user matching the {nameof(uid)} could be found");
            }

            await _fbService.DeleteUserByUidAsync(uid);

            // These entities aren't linked for automatic cascading. Need to delete by hand.
            var ordersToDelete = user.UserOrders.Select(x => x.Order);
            var shipmentsToDelete = ordersToDelete.Select(x => x.Shipment);
            var paymentsToDelete = ordersToDelete.Select(x => x.Payment);

            _unitOfWork.OrderRepository.DeleteRange(ordersToDelete);
            _unitOfWork.ShipmentRepository.DeleteRange(shipmentsToDelete);
            _unitOfWork.PaymentRepository.DeleteRange(paymentsToDelete);
            _unitOfWork.UserRepository.Delete(user);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<UpdateUserResponse> UpdateUserAsync(string uid, UpdateUserRequest request)
        {
            var user = await _unitOfWork.UserRepository.GetDetailedUserByUidAsync(uid);

            if (user == null)
            {
                throw new FirebaseUidNotFoundException($"No database user matching the {nameof(uid)} could be found");
            }

            _mapper.Map(request, user);

            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.UserRepository.SaveChangesAsync();

            var response = _mapper.Map<UpdateUserResponse>(user);

            return response;
        }
    }
}
