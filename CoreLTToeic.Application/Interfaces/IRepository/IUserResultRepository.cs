using CoreLTToeic.Application.Interfaces.Pattern;
using CoreLTToeic.Domain.Entities;

namespace CoreLTToeic.Application.Interfaces.IRepository
{
    public interface IUserResultRepository : IRepository<UserResult>
    {
        Task<List<UserResult>> GetByUserIdAsync(string userId);
        Task<UserResult?> GetByIdWithAnswersAsync(long id);
    }
}
