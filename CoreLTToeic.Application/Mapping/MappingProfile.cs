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

            CreateMap<QuestionGroup, QuestionGroupViewModel>()
                .ForMember(d => d.Images, o => o.MapFrom(s => s.Images.Select(i => i.Image).ToList()))
                .ForMember(d => d.Questions, o => o.MapFrom(s => s.Questions));
            CreateMap<QuestionGroupEditModel, QuestionGroup>()
                .ForMember(d => d.Images, o => o.Ignore())
                .ForMember(d => d.Questions, o => o.Ignore());

            CreateMap<TestCategory, TestCategoryViewModel>();
        }
    }
}
