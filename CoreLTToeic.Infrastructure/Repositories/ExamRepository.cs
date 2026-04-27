using CoreLTToeic.Application.Interfaces;
using CoreLTToeic.Domain.Entities;
using CoreLTToeic.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLTToeic.Infrastructure.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly AppDbContext _context;
        public ExamRepository(IDbContextFactory<AppDbContext> factory) 
        {
            _context = factory.CreateDbContext();
        }

        public Task AddAsync(Exam exam)
        {
            throw new NotImplementedException();
        }
    }
}
