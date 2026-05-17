using CoreLTToeic.Application.Interfaces.Pattern;
using CoreLTToeic.Application.Models.EditModels;
using CoreLTToeic.Application.Models.ViewModels;
using CoreLTToeic.Domain.Entities;

namespace CoreLTToeic.Application.Interfaces.IRepository
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<List<CourseViewModel>> GetAllWithSectionsAsync();
        Task<CourseViewModel?> GetByIdWithSectionsAsync(long id);

        Task<CourseSectionViewModel> AddSectionAsync(long courseId, CourseSectionEditModel model);
        Task DeleteSectionAsync(long sectionId);

        Task<CourseLessonViewModel> AddLessonAsync(long sectionId, CourseLessonEditModel model);
        Task DeleteLessonAsync(long lessonId);
    }
}
