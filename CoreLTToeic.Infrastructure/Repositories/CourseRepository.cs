using AutoMapper;
using CoreLTToeic.Application.Interfaces.IRepository;
using CoreLTToeic.Application.Models.EditModels;
using CoreLTToeic.Application.Models.ViewModels;
using CoreLTToeic.Domain.Entities;
using CoreLTToeic.Infrastructure.Context;
using CoreLTToeic.Infrastructure.Pattern;
using Microsoft.EntityFrameworkCore;

namespace CoreLTToeic.Infrastructure.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly IDbContextFactory<AppDbContext> _factory;
        private readonly IMapper _mapper;

        public CourseRepository(IDbContextFactory<AppDbContext> factory, IMapper mapper) : base(factory)
        {
            _factory = factory;
            _mapper = mapper;
        }

        public async Task<List<CourseViewModel>> GetAllWithSectionsAsync()
        {
            using var ctx = await _factory.CreateDbContextAsync();
            var courses = await ctx.Courses
                .Include(c => c.Sections).ThenInclude(s => s.Lessons)
                .OrderByDescending(c => c.Id)
                .ToListAsync();
            return _mapper.Map<List<CourseViewModel>>(courses);
        }

        public async Task<CourseViewModel?> GetByIdWithSectionsAsync(long id)
        {
            using var ctx = await _factory.CreateDbContextAsync();
            var course = await ctx.Courses
                .Include(c => c.Sections).ThenInclude(s => s.Lessons)
                .FirstOrDefaultAsync(c => c.Id == id);
            return course == null ? null : _mapper.Map<CourseViewModel>(course);
        }

        public async Task<CourseSectionViewModel> AddSectionAsync(long courseId, CourseSectionEditModel model)
        {
            using var ctx = await _factory.CreateDbContextAsync();
            var section = _mapper.Map<CourseSection>(model);
            section.CourseId = courseId;
            ctx.CourseSections.Add(section);
            await ctx.SaveChangesAsync();
            return _mapper.Map<CourseSectionViewModel>(section);
        }

        public async Task DeleteSectionAsync(long sectionId)
        {
            using var ctx = await _factory.CreateDbContextAsync();
            var section = await ctx.CourseSections.FindAsync(sectionId);
            if (section != null)
            {
                ctx.CourseSections.Remove(section);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task<CourseLessonViewModel> AddLessonAsync(long sectionId, CourseLessonEditModel model)
        {
            using var ctx = await _factory.CreateDbContextAsync();
            var lesson = _mapper.Map<CourseLesson>(model);
            lesson.SectionId = sectionId;
            ctx.CourseLessons.Add(lesson);
            await ctx.SaveChangesAsync();
            return _mapper.Map<CourseLessonViewModel>(lesson);
        }

        public async Task DeleteLessonAsync(long lessonId)
        {
            using var ctx = await _factory.CreateDbContextAsync();
            var lesson = await ctx.CourseLessons.FindAsync(lessonId);
            if (lesson != null)
            {
                ctx.CourseLessons.Remove(lesson);
                await ctx.SaveChangesAsync();
            }
        }
    }
}
