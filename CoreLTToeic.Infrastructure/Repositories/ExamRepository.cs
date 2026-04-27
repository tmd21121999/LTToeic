using System;
using System.Threading.Tasks;
using CoreLTToeic.Domain.Entities;
using CoreLTToeic.Infrastructure.Context;
using CoreLTToeic.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoreLTToeic.Infrastructure.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly AppDbContext _context;
        public ExamRepository(IDbContextFactory<AppDbContext> factory)
        {
            _context = factory.CreateDbContext();
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

            }
        }
    }
}
