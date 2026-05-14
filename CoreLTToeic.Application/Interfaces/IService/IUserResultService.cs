using CoreLTToeic.Application.Models.EditModels;
using CoreLTToeic.Application.Models.ViewModels;

namespace CoreLTToeic.Application.Interfaces.IService;

public interface IUserResultService
{
    Task<long> SubmitTestAsync(UserResultEditModel model, int completionTimeSeconds);
    Task<UserResultViewModel?> GetResultAsync(long resultId);
    Task<IEnumerable<UserResultViewModel>> GetByUserIdAsync(string userId);
}
