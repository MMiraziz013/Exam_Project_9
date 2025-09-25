using Clean.Application.Abstractions;
using Clean.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<DataContext>(opt => opt.UseNpgsql(connectionString));
        services.AddScoped<IDataContext>(provider => provider.GetRequiredService<DataContext>());

        services.AddTransient<IStudentRepository, StudentRepository>();
        services.AddTransient<ITeacherRepository, TeacherRepository>();
        services.AddTransient<IClassroomRepository, ClassroomRepository>();
        services.AddTransient<IAttendanceRepository, AttendanceRepository>();
        services.AddTransient<ISubjectRepository, SubjectRepository>();
        services.AddTransient<IStudentGroupRepository, StudentGroupRepository>();
        services.AddTransient<IStudentGroupMemberRepository, StudentGroupMemberRepository>();
        services.AddTransient<IExamRepository, ExamRepository>();
        services.AddTransient<IExamResultRepository, ExamResultRepository>();
        services.AddTransient<ITimetableRepository, TimetableRepository>();
        services.AddTransient<IStudentIssueRepository, StudentIssueRepository>();
        services.AddTransient<ILessonRepository, LessonRepository>();
        return services;
    }
}