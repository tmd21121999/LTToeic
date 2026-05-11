using CoreLTToeic.Application.Interfaces.IRepository;
using CoreLTToeic.Domain.Entities;
using CoreLTToeic.Infrastructure.Context;
using CoreLTToeic.Infrastructure.Pattern;
using Microsoft.EntityFrameworkCore;

namespace CoreLTToeic.Infrastructure.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private readonly IDbContextFactory<AppDbContext> _factory;

        public QuestionRepository(IDbContextFactory<AppDbContext> factory) : base(factory)
        {
            _factory = factory;
        }

        public async Task<List<Question>> GetByTestIdAsync(long testId)
        {
            using var ctx = await _factory.CreateDbContextAsync();
            return await ctx.Questions
                .Where(q => q.TestId == testId)
                .OrderBy(q => q.OrderNumber)
                .ToListAsync();
        }
    }
}
