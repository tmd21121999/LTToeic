using System.Threading.Tasks;
using CoreLTToeic.Domain.Entities;

namespace CoreLTToeic.Application.Interfaces
{
    public interface IExamRepository
    {
        Task AddAsync(Exam exam);
    }
}
