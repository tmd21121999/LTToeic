using CoreLTToeic.Application.Models.EditModels;
using CoreLTToeic.Application.Models.ViewModels;

namespace CoreLTToeic.Application.Interfaces.IService
{
    public interface ICourseService
    {
        Task<List<CourseViewModel>> GetAllAsync();
        Task<CourseViewModel?> GetByIdAsync(long id);
        Task<CourseViewModel> CreateAsync(CourseEditModel model, string? thumbnailPath);
        Task<CourseViewModel> UpdateAsync(long id, CourseEditModel model, string? thumbnailPath);
        Task DeleteAsync(long id);

        Task<CourseSectionViewModel> AddSectionAsync(long courseId, CourseSectionEditModel model);
        Task DeleteSectionAsync(long sectionId);

        Task<CourseLessonViewModel> AddLessonAsync(long sectionId, CourseLessonEditModel model);
        Task DeleteLessonAsync(long lessonId);
    }
}
