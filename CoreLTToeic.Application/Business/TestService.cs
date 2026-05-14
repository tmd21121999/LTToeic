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
        private readonly IQuestionGroupRepository _groupRepo;
        private readonly ITestCategoryRepository _categoryRepo;
        private readonly IMapper _mapper;

        public TestService(ITestRepository testRepo, IQuestionRepository questionRepo,
            IQuestionGroupRepository groupRepo, ITestCategoryRepository categoryRepo, IMapper mapper)
        {
            _testRepo = testRepo;
            _questionRepo = questionRepo;
            _groupRepo = groupRepo;
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
            await UpdateTestQuestionCount(model.TestId);
            return entity.Id;
        }

        public async Task UpdateQuestionAsync(QuestionEditModel model)
        {
            var entity = await _questionRepo.Find(x => x.Id == model.Id).FirstOrDefaultAsync();
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
                if (testId > 0) await UpdateTestQuestionCount(testId);
            }
        }

        public async Task<IEnumerable<QuestionGroupViewModel>> GetQuestionGroupsAsync(long testId)
        {
            var groups = await _groupRepo.GetByTestIdAsync(testId);
            return _mapper.Map<IEnumerable<QuestionGroupViewModel>>(groups);
        }

        public async Task<long> AddQuestionGroupAsync(QuestionGroupEditModel model)
        {
            var group = _mapper.Map<QuestionGroup>(model);
            group.TestId = model.TestId;

            foreach (var imgPath in model.Images)
                group.Images.Add(new QuestionGroupImage { Image = imgPath });

            _groupRepo.Add(group);
            await _groupRepo.SaveChangesAsync();

            foreach (var child in model.ChildQuestions)
            {
                child.TestId = model.TestId;
                child.QuestionGroupId = group.Id;
                var q = _mapper.Map<Question>(child);
                _questionRepo.Add(q);
            }
            await _questionRepo.SaveChangesAsync();
            await UpdateTestQuestionCount(model.TestId);

            return group.Id;
        }

        public async Task UpdateQuestionGroupAsync(QuestionGroupEditModel model)
        {
            var group = await _groupRepo.Find(g => g.Id == model.Id).FirstOrDefaultAsync();
            if (group == null) return;

            _mapper.Map(model, group);
            _groupRepo.Update(group);
            await _groupRepo.SaveChangesAsync();

            // Sync child questions: update existing, add new ones
            var existingChildren = await _questionRepo.Find(q => q.QuestionGroupId == model.Id).ToListAsync();
            var updatedIds = model.ChildQuestions.Where(c => c.Id > 0).Select(c => c.Id).ToHashSet();

            foreach (var old in existingChildren.Where(e => !updatedIds.Contains(e.Id)))
            {
                _questionRepo.Remove(old);
            }

            foreach (var child in model.ChildQuestions)
            {
                child.TestId = model.TestId;
                child.QuestionGroupId = model.Id;
                if (child.Id > 0)
                {
                    var existing = existingChildren.FirstOrDefault(e => e.Id == child.Id);
                    if (existing != null) _mapper.Map(child, existing);
                }
                else
                {
                    _questionRepo.Add(_mapper.Map<Question>(child));
                }
            }
            await _questionRepo.SaveChangesAsync();
            await UpdateTestQuestionCount(model.TestId);
        }

        public async Task DeleteQuestionGroupAsync(long groupId)
        {
            var group = await _groupRepo.Find(g => g.Id == groupId).FirstOrDefaultAsync();
            if (group == null) return;

            long testId = group.TestId ?? 0;

            var children = await _questionRepo.Find(q => q.QuestionGroupId == groupId).ToListAsync();
            foreach (var child in children) _questionRepo.Remove(child);
            await _questionRepo.SaveChangesAsync();

            _groupRepo.Remove(group);
            await _groupRepo.SaveChangesAsync();

            if (testId > 0) await UpdateTestQuestionCount(testId);
        }

        public async Task<IEnumerable<TestCategoryViewModel>> GetCategoriesAsync()
        {
            var cats = await _categoryRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<TestCategoryViewModel>>(cats);
        }

        private async Task UpdateTestQuestionCount(long testId)
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
