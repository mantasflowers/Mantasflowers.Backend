using System.Threading.Tasks;
using Mantasflowers.Contracts.Errors;
using Mantasflowers.Contracts.Feedback;
using Mantasflowers.Services.Services.Feedback;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mantasflowers.WebApi.Controllers
{
    [ApiController]
    [Route("/feedback")]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateFeedback(CreateFeedbackRequest request)
        {
            await _feedbackService.CreateFeedback(request);

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}