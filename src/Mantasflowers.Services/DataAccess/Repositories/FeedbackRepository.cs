using Mantasflowers.Domain.Entities;
using Mantasflowers.Persistence;

namespace Mantasflowers.Services.DataAccess.Repositories
{
    public class FeedbackRepository : BaseRepository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(DatabaseContext dbContext)
            : base(dbContext) { }
    }
}
