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
            CreateMap<Test, TestViewModel>()
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.TestCategory != null ? s.TestCategory.Name : null))
                .ForMember(d => d.AttemptCount, o => o.MapFrom(s => s.UserResults.Count));
            CreateMap<TestEditModel, Test>();

            CreateMap<Question, QuestionViewModel>();
            CreateMap<QuestionEditModel, Question>();

            CreateMap<TestCategory, TestCategoryViewModel>();
        }
    }
}
