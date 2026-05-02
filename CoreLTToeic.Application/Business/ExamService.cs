using System;
using System.Threading.Tasks;
using AutoMapper;
using CoreLTToeic.Application.Interfaces.IRepository;
using CoreLTToeic.Application.Interfaces.IService;
using CoreLTToeic.Application.Models.EditModels;
using CoreLTToeic.Application.Models.ViewModels;
using CoreLTToeic.Domain.Entities;

namespace CoreLTToeic.Application.Business
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;
        private readonly IMapper _mapper;

        public ExamService(IExamRepository examRepository, IMapper mapper)
        {
            _examRepository = examRepository ?? throw new ArgumentNullException(nameof(examRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task AddAsync(ExamEditModel model)
        {
            if (model is null) throw new ArgumentNullException(nameof(model));

            var exam = _mapper.Map<Exam>(model);

            await _examRepository.AddAsync(exam);
        }

        public async Task<IEnumerable<ExamViewModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ExamViewModel>>(await _examRepository.GetAllAsync());
        }
    }
}