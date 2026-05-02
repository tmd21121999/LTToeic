using System.Threading.Tasks;
using CoreLTToeic.Application.Interfaces.Pattern;
using CoreLTToeic.Domain.Entities;

namespace CoreLTToeic.Application.Interfaces.IRepository
{
    public interface IExamRepository : IRepository<Exam>
    {
        Task AddAsync(Exam exam);
    }
}
