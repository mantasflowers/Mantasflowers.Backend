using AutoMapper;
using Mantasflowers.Contracts.Review.Response;
using Mantasflowers.Domain.Entities;

namespace Mantasflowers.WebApi.Setup.Mapping
{
    public class ProductReviewProfile : Profile
    {
        public ProductReviewProfile()
        {
            CreateMap<ProductReview, GetProductReviewsResponse>()
                .ForMember(d => d.UserFirstName, opt => opt.MapFrom(s => s.User.FirstName))
                .ForMember(d => d.Date, opt => opt.MapFrom(s => s.UpdatedOn));
        }
    }
}