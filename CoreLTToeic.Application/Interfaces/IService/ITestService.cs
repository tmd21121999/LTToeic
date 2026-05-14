using CoreLTToeic.Application.Models.EditModels;
using CoreLTToeic.Application.Models.ViewModels;

namespace CoreLTToeic.Application.Interfaces.IService
{
    public interface ITestService
    {
        Task<IEnumerable<TestViewModel>> GetAllAsync();
        Task<TestViewModel?> GetByIdAsync(long id);
        Task<long> AddAsync(TestEditModel model);
        Task UpdateAsync(TestEditModel model);
        Task DeleteAsync(long id);

        Task<IEnumerable<QuestionViewModel>> GetQuestionsAsync(long testId);
        Task<long> AddQuestionAsync(QuestionEditModel model);
        Task UpdateQuestionAsync(QuestionEditModel model);
        Task DeleteQuestionAsync(long questionId);

        Task<IEnumerable<QuestionGroupViewModel>> GetQuestionGroupsAsync(long testId);
        Task<long> AddQuestionGroupAsync(QuestionGroupEditModel model);
        Task UpdateQuestionGroupAsync(QuestionGroupEditModel model);
        Task DeleteQuestionGroupAsync(long groupId);

        Task<IEnumerable<TestCategoryViewModel>> GetCategoriesAsync();
    }
}
