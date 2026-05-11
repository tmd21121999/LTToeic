using CoreLTToeic.Application.Interfaces.Pattern;
using CoreLTToeic.Domain.Entities;

namespace CoreLTToeic.Application.Interfaces.IRepository
{
    public interface ITestRepository : IRepository<Test>
    {
        Task<List<Test>> GetAllWithCategoryAsync();
        Task<Test?> GetByIdWithDetailsAsync(long id);
    }
}
