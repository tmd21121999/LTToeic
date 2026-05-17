using AutoMapper;
using CoreLTToeic.Application.Interfaces.IRepository;
using CoreLTToeic.Application.Interfaces.IService;
using CoreLTToeic.Application.Models.EditModels;
using CoreLTToeic.Application.Models.ViewModels;
using CoreLTToeic.Domain.Entities;

namespace CoreLTToeic.Application.Business
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepo;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepo, IMapper mapper)
        {
            _courseRepo = courseRepo;
            _mapper = mapper;
        }

        public async Task<List<CourseViewModel>> GetAllAsync()
            => await _courseRepo.GetAllWithSectionsAsync();

        public async Task<CourseViewModel?> GetByIdAsync(long id)
            => await _courseRepo.GetByIdWithSectionsAsync(id);

        public async Task<CourseViewModel> CreateAsync(CourseEditModel model, string? thumbnailPath)
        {
            var entity = _mapper.Map<Course>(model);
            entity.ThumbnailUrl = thumbnailPath;
            entity.CreatedAt = DateTime.UtcNow;
            _courseRepo.Add(entity);
            await _courseRepo.SaveChangesAsync();
            return (await _courseRepo.GetByIdWithSectionsAsync(entity.Id))!;
        }

        public async Task<CourseViewModel> UpdateAsync(long id, CourseEditModel model, string? thumbnailPath)
        {
            var all = await _courseRepo.GetAllBySearchAsync(c => c.Id == id);
            var entity = all.FirstOrDefault() ?? throw new KeyNotFoundException($"Không tìm thấy khóa học #{id}");
            _mapper.Map(model, entity);
            if (thumbnailPath != null)
                entity.ThumbnailUrl = thumbnailPath;
            _courseRepo.Update(entity);
            await _courseRepo.SaveChangesAsync();
            return (await _courseRepo.GetByIdWithSectionsAsync(id))!;
        }

        public async Task DeleteAsync(long id)
        {
            var all = await _courseRepo.GetAllBySearchAsync(c => c.Id == id);
            var entity = all.FirstOrDefault() ?? throw new KeyNotFoundException($"Không tìm thấy khóa học #{id}");
            _courseRepo.Remove(entity);
            await _courseRepo.SaveChangesAsync();
        }

        public Task<CourseSectionViewModel> AddSectionAsync(long courseId, CourseSectionEditModel model)
            => _courseRepo.AddSectionAsync(courseId, model);

        public Task DeleteSectionAsync(long sectionId)
            => _courseRepo.DeleteSectionAsync(sectionId);

        public Task<CourseLessonViewModel> AddLessonAsync(long sectionId, CourseLessonEditModel model)
            => _courseRepo.AddLessonAsync(sectionId, model);

        public Task DeleteLessonAsync(long lessonId)
            => _courseRepo.DeleteLessonAsync(lessonId);
    }
}
