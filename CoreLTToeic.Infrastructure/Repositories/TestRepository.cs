using CoreLTToeic.Application.Interfaces.IRepository;
using CoreLTToeic.Domain.Entities;
using CoreLTToeic.Infrastructure.Context;
using CoreLTToeic.Infrastructure.Pattern;
using Microsoft.EntityFrameworkCore;

namespace CoreLTToeic.Infrastructure.Repositories
{
    public class TestRepository : Repository<Test>, ITestRepository
    {
        private readonly IDbContextFactory<AppDbContext> _factory;

        public TestRepository(IDbContextFactory<AppDbContext> factory) : base(factory)
        {
            _factory = factory;
        }

        public async Task<List<Test>> GetAllWithCategoryAsync()
        {
            using var ctx = await _factory.CreateDbContextAsync();
            return await ctx.Tests
                .Include(t => t.TestCategory)
                .OrderByDescending(t => t.Id)
                .ToListAsync();
        }

        public async Task<Test?> GetByIdWithDetailsAsync(long id)
        {
            using var ctx = await _factory.CreateDbContextAsync();
            return await ctx.Tests
                .Include(t => t.TestCategory)
                .Include(t => t.Parts)
                .Include(t => t.QuestionGroups).ThenInclude(g => g.Images)
                .Include(t => t.Questions)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
