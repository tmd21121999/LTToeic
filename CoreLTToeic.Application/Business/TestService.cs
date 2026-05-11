using AutoMapper;
using CoreLTToeic.Application.Interfaces.IRepository;
using CoreLTToeic.Application.Interfaces.IService;
using CoreLTToeic.Application.Models.EditModels;
using CoreLTToeic.Application.Models.ViewModels;
using CoreLTToeic.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreLTToeic.Application.Business
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepo;
        private readonly IQuestionRepository _questionRepo;
        private readonly ITestCategoryRepository _categoryRepo;
        private readonly IMapper _mapper;

        public TestService(ITestRepository testRepo, IQuestionRepository questionRepo,
            ITestCategoryRepository categoryRepo, IMapper mapper)
        {
            _testRepo = testRepo;
            _questionRepo = questionRepo;
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TestViewModel>> GetAllAsync()
        {
            var tests = await _testRepo.GetAllWithCategoryAsync();
            return _mapper.Map<IEnumerable<TestViewModel>>(tests);
        }

        public async Task<TestViewModel?> GetByIdAsync(long id)
        {
            var test = await _testRepo.GetByIdWithDetailsAsync(id);
            return test == null ? null : _mapper.Map<TestViewModel>(test);
        }

        public async Task<long> AddAsync(TestEditModel model)
        {
            var entity = _mapper.Map<Test>(model);
            _testRepo.Add(entity);
            await _testRepo.SaveChangesAsync();
            return entity.Id;
        }

        public async Task UpdateAsync(TestEditModel model)
        {
            var entity = _mapper.Map<Test>(model);
            _testRepo.Update(entity);
            await _testRepo.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await _testRepo.Find(t => t.Id == id).FirstOrDefaultAsync();
            if (entity != null)
            {
                _testRepo.Remove(entity);
                await _testRepo.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<QuestionViewModel>> GetQuestionsAsync(long testId)
        {
            var questions = await _questionRepo.GetByTestIdAsync(testId);
            return _mapper.Map<IEnumerable<QuestionViewModel>>(questions);
        }

        public async Task<long> AddQuestionAsync(QuestionEditModel model)
        {
            var entity = _mapper.Map<Question>(model);
            _questionRepo.Add(entity);
            await _questionRepo.SaveChangesAsync();

            var test = await _testRepo.Find(t => t.Id == model.TestId).FirstOrDefaultAsync();
            if (test != null)
            {
                test.TotalQuestions = (await _questionRepo.GetByTestIdAsync(model.TestId)).Count;
                _testRepo.Update(test);
                await _testRepo.SaveChangesAsync();
            }

            return entity.Id;
        }

        public async Task UpdateQuestionAsync(QuestionEditModel model)
        {
            var entity = await _questionRepo.Find(x=>x.Id == model.Id).FirstOrDefaultAsync();
            _mapper.Map(model, entity);
            await _questionRepo.SaveChangesAsync();
        }

        public async Task DeleteQuestionAsync(long questionId)
        {
            var entity = await _questionRepo.Find(q => q.Id == questionId).FirstOrDefaultAsync();
            if (entity != null)
            {
                long testId = entity.TestId ?? 0;
                _questionRepo.Remove(entity);
                await _questionRepo.SaveChangesAsync();

                if (testId > 0)
                {
                    var test = await _testRepo.Find(t => t.Id == testId).FirstOrDefaultAsync();
                    if (test != null)
                    {
                        test.TotalQuestions = (await _questionRepo.GetByTestIdAsync(testId)).Count;
                        _testRepo.Update(test);
                        await _testRepo.SaveChangesAsync();
                    }
                }
            }
        }

        public async Task<IEnumerable<TestCategoryViewModel>> GetCategoriesAsync()
        {
            var cats = await _categoryRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<TestCategoryViewModel>>(cats);
        }
    }
}
