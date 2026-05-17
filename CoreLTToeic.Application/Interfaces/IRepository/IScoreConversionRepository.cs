using System.Threading.Tasks;

namespace CoreLTToeic.Application.Interfaces.IRepository;

public interface IScoreConversionRepository
{
    Task<int> GetListeningScoreAsync(int correctCount);
    Task<int> GetReadingScoreAsync(int correctCount);
}
