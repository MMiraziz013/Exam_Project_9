using Clean.Application.Abstractions;
using Clean.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IStudentService, StudentService>();
        services.AddTransient<ITeacherService, TeacherService>();
        services.AddTransient<IClassroomService, ClassroomService>();
        services.AddTransient<IAttendanceService, AttendanceService>();
        services.AddTransient<ISubjectService, SubjectService>();
        services.AddTransient<IStudentGroupService, StudentGroupService>();
        services.AddTransient<IStudentGroupMemberService, StudentGroupMemberService>();
        services.AddTransient<IExamService, ExamService>();
        services.AddTransient<IExamResultService, ExamResultService>();
        services.AddTransient<ITimetableService, TimetableService>();
        services.AddTransient<IStudentIssueService, StudentIssueService>();
        services.AddTransient<ILessonService, LessonService>();
        return services;
    }
}