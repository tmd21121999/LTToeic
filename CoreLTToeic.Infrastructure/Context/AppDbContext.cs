using CoreLTToeic.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreLTToeic.Infrastructure.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestCategory> TestCategories { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<QuestionGroup> QuestionGroups { get; set; }
        public DbSet<QuestionGroupImage> QuestionGroupImages { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<UserResult> UserResults { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
        public DbSet<ReadingScoreConversion> ReadingScoreConversions { get; set; }
        public DbSet<ListeningScoreConversion> ListeningScoreConversions { get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseSection> CourseSections { get; set; }
        public DbSet<CourseLesson> CourseLessons { get; set; }
        public DbSet<CourseEnrollment> CourseEnrollments { get; set; }
        public DbSet<CourseReview> CourseReviews { get; set; }
        public DbSet<LessonCompletion> LessonCompletions { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        public DbSet<QuizQuestionOption> QuizQuestionOptions { get; set; }
    }
}
