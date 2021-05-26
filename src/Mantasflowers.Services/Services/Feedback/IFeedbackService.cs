using System.Threading.Tasks;
using Mantasflowers.Contracts.Feedback;

namespace Mantasflowers.Services.Services.Feedback
{
    public interface IFeedbackService
    {
        Task CreateFeedback(CreateFeedbackRequest request);
    }
}