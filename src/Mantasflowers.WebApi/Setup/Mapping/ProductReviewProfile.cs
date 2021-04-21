using AutoMapper;
using Mantasflowers.Contracts.Review.Response;
using Mantasflowers.Domain.Entities;

namespace Mantasflowers.WebApi.Setup.Mapping
{
    public class ProductReviewProfile : Profile
    {
        public ProductReviewProfile()
        {
            CreateMap<ProductReview, GetProductReviewForUserResponse>()
                .ForMember(d => d.Score, opt => opt.MapFrom(s => s.ReviewScore))
                .ForMember(d => d.SubmittedAt, opt => opt.MapFrom(s => s.CreatedOn));
        }
    }
}