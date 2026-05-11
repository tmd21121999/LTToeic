using CoreLTToeic.Application.Interfaces.IRepository;
using CoreLTToeic.Domain.Entities;
using CoreLTToeic.Infrastructure.Context;
using CoreLTToeic.Infrastructure.Pattern;
using Microsoft.EntityFrameworkCore;

namespace CoreLTToeic.Infrastructure.Repositories
{
    public class TestCategoryRepository : Repository<TestCategory>, ITestCategoryRepository
    {
        public TestCategoryRepository(IDbContextFactory<AppDbContext> factory) : base(factory) { }
    }
}
