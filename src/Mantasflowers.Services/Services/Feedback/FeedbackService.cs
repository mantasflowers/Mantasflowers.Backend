using System.Threading.Tasks;
using AutoMapper;
using Mantasflowers.Contracts.Feedback;
using Mantasflowers.Services.DataAccess;

namespace Mantasflowers.Services.Services.Feedback
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FeedbackService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateFeedback(CreateFeedbackRequest request)
        {
            var feedback = _mapper.Map<Domain.Entities.Feedback>(request);

            await _unitOfWork.FeedbackRepository.CreateAsync(feedback);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}