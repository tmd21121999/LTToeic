using CoreLTToeic.Application.Models.EditModels;
using CoreLTToeic.Application.Models.ViewModels;
using CoreLTToeic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLTToeic.Application.Interfaces.IService
{
    public interface IExamService
    {
        Task AddAsync(ExamEditModel exam);
        Task<IEnumerable<ExamViewModel>> GetAllAsync();
    }
}
