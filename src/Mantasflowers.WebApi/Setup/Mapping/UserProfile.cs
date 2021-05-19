using System;
using AutoMapper;
using Mantasflowers.Contracts.User.Request;
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

            CreateMap<UpdateUserAddressRequest, UserAddress>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UpdateUserContactInfoRequest, UserContactInfo>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UpdateUserRequest, User>()
                .ForMember(d => d.RowVersion, opt => opt.Ignore())
                .ForAllOtherMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UserAddress, UpdateUserAddressResponse>();
            CreateMap<UserContactInfo, UpdateUserContactInfoResponse>();
            CreateMap<User, UpdateUserResponse>();
        }
    }
}
