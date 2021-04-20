using AutoMapper;
using Mantasflowers.Contracts.User.Response;
using Mantasflowers.Domain.Entities;

namespace Mantasflowers.WebApi.Setup.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, GetUserResponse>()
                .ForMember(d => d.RegisteredAt, opt => opt.MapFrom(s => s.CreatedOn));

            CreateMap<UserAddress, GetUserAddressResponse>();
            CreateMap<UserContactInfo, GetUserContactDetailsResponse>();
            CreateMap<User, GetDetailedUserResponse>()
                .ForMember(d => d.RegisteredAt, opt => opt.MapFrom(s => s.CreatedOn))
                .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Address))
                .ForMember(d => d.ContactDetails, opt => opt.MapFrom(s => s.UserContactInfo));

            CreateMap<User, PostCreateUserResponse>();
        }
    }
}
