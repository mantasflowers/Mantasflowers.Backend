using AutoMapper;
using Mantasflowers.Contracts.Feedback;
using Mantasflowers.Domain.Entities;

namespace Mantasflowers.WebApi.Setup.Mapping
{
    public class FeedbackProfile : Profile
    {
        public FeedbackProfile()
        {
            CreateMap<CreateFeedbackRequest, Feedback>();;
        }
    }
}
