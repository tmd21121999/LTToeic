using CoreLTToeic.Application.Interfaces.IRepository;
using CoreLTToeic.Domain.Entities;
using CoreLTToeic.Infrastructure.Context;
using CoreLTToeic.Infrastructure.Pattern;
using Microsoft.EntityFrameworkCore;

namespace CoreLTToeic.Infrastructure.Repositories
{
    public class PartRepository : Repository<Part>, IPartRepository
    {
        private readonly IDbContextFactory<AppDbContext> _factory;

        public PartRepository(IDbContextFactory<AppDbContext> factory) : base(factory)
        {
            _factory = factory;
        }

        public async Task<List<Part>> GetByTestIdAsync(long testId)
        {
            using var ctx = await _factory.CreateDbContextAsync();
            return await ctx.Parts
                .Include(p => p.Questions)
                .Include(p => p.QuestionGroups)
                .Where(p => p.TestId == testId)
                .OrderBy(p => p.PartNum)
                .ToListAsync();
        }
    }
}
