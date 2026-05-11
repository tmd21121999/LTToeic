using CoreLTToeic.Application.Interfaces.Pattern;
using CoreLTToeic.Domain.Entities;

namespace CoreLTToeic.Application.Interfaces.IRepository
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Task<List<Question>> GetByTestIdAsync(long testId);
    }
}
