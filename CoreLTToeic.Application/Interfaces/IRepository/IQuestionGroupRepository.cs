using CoreLTToeic.Application.Interfaces.Pattern;
using CoreLTToeic.Domain.Entities;

namespace CoreLTToeic.Application.Interfaces.IRepository
{
    public interface IQuestionGroupRepository : IRepository<QuestionGroup>
    {
        Task<IEnumerable<QuestionGroup>> GetByTestIdAsync(long testId);
    }
}
