using AutoMapper;
using CoreLTToeic.Application.Models.EditModels;
using CoreLTToeic.Application.Models.ViewModels;
using CoreLTToeic.Domain.Entities;
using CoreLTToeic.Domain.Enums;
using System.Linq;

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
                .ForMember(d => d.Questions, o => o.MapFrom(s => s.Questions))
                .ForMember(d => d.PartNum, o => o.MapFrom(s => s.Part != null ? (ToeicLRPart?)s.Part.PartNum : null));
            CreateMap<QuestionGroupEditModel, QuestionGroup>()
                .ForMember(d => d.Images, o => o.Ignore())
                .ForMember(d => d.Questions, o => o.Ignore());

            CreateMap<Part, PartViewModel>()
                .ForMember(d => d.QuestionCount, o => o.MapFrom(s => s.Questions.Count))
                .ForMember(d => d.QuestionGroupCount, o => o.MapFrom(s => s.QuestionGroups.Count));
            CreateMap<PartEditModel, Part>();

            CreateMap<TestCategory, TestCategoryViewModel>();

            CreateMap<UserAnswer, UserAnswerViewModel>()
                .ForMember(d => d.CorrectAnswer, o => o.MapFrom(s => s.Question != null ? s.Question.CorrectAnswer : null));

            CreateMap<UserResult, UserResultViewModel>()
                .ForMember(d => d.TestTitle, o => o.MapFrom(s => s.Test != null ? s.Test.Title : string.Empty))
                .ForMember(d => d.Answers, o => o.MapFrom(s => s.UserAnswers));

            CreateMap<CourseLesson, CourseLessonViewModel>();
            CreateMap<CourseLessonEditModel, CourseLesson>();

            CreateMap<CourseSection, CourseSectionViewModel>()
                .ForMember(d => d.LessonCount, o => o.MapFrom(s => s.Lessons.Count))
                .ForMember(d => d.Lessons, o => o.MapFrom(s => s.Lessons.OrderBy(l => l.OrderIndex)));
            CreateMap<CourseSectionEditModel, CourseSection>();

            CreateMap<Course, CourseViewModel>()
                .ForMember(d => d.SectionCount, o => o.MapFrom(s => s.Sections.Count))
                .ForMember(d => d.Sections, o => o.MapFrom(s => s.Sections.OrderBy(sec => sec.OrderIndex)));
            CreateMap<CourseEditModel, Course>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.CreatedAt, o => o.Ignore())
                .ForMember(d => d.UpdatedAt, o => o.Ignore())
                .ForMember(d => d.Sections, o => o.Ignore())
                .ForMember(d => d.Enrollments, o => o.Ignore())
                .ForMember(d => d.Reviews, o => o.Ignore())
                .ForMember(d => d.ThumbnailUrl, o => o.Ignore());
        }
    }
}
