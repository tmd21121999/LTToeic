using CoreLTToeic.Application.Interfaces.Pattern;
using CoreLTToeic.Domain.Entities;

namespace CoreLTToeic.Application.Interfaces.IRepository
{
    public interface IPartRepository : IRepository<Part>
    {
        Task<List<Part>> GetByTestIdAsync(long testId);
    }
}
