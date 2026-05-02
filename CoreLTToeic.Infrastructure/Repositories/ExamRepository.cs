using CoreLTToeic.Application.Interfaces.IRepository;
using CoreLTToeic.Domain.Entities;
using CoreLTToeic.Infrastructure.Context;
using CoreLTToeic.Infrastructure.Pattern;
using Microsoft.EntityFrameworkCore;

namespace CoreLTToeic.Infrastructure.Repositories
{
    public class ExamRepository : Repository<Exam>, IExamRepository
    {
        public ExamRepository(IDbContextFactory<AppDbContext> factory) : base(factory)
        {
        }

        public async Task AddAsync(Exam exam)
        {
            try
            {
                if (exam is null)
                {
                    throw new ArgumentNullException(nameof(exam));
                }

                await _context.Exams.AddAsync(exam);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Exam>> GetAllAsync()
        {
            try
            {
                return await _context.Exams.ToListAsync();
            }
            catch (Exception)
            {
                return new List<Exam>();
            }
        }
    }
}
