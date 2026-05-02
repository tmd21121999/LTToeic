using AutoMapper;
using CoreLTToeic.Application.Models.EditModels;
using CoreLTToeic.Application.Models.ViewModels;
using CoreLTToeic.Domain.Entities;

namespace CoreLTToeic.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Exam, ExamViewModel>().ReverseMap();
            CreateMap<Exam, ExamEditModel>().ReverseMap();
        }
    }
}
