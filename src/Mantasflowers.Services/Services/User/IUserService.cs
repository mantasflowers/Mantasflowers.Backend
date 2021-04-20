using Mantasflowers.Contracts.User.Response;
using System;
using System.Threading.Tasks;

namespace Mantasflowers.Services.Services.User
{
    public interface IUserService
    {
        Task<GetUserResponse> GetUserByUidAsync(string uid);

        Task<GetDetailedUserResponse> GetDetailedUserByUidAsync(string uid,
            string loginEmail, bool isLoginEmailVerified);

        Task<GetDetailedUserResponse> GetDetailedUserByGuidAsync(Guid id);

        Task<string> GetUserUidByGuidAsync(Guid id);

        Task<PostCreateUserResponse> CreateUserAsync(string uid);
    }
}
