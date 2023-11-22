using OurFirstWebApi.Models;
using OurFirstWebApi.Models.DTO;
using Verkefni_Entity_framework.Models;

namespace OurFirstWebApi.Data.Interface
{
    public interface IRepository
    {
        Task<List<StudentDTO>> GetAllStudentsAsync();
        Task<StudentDTO> GetStudentByIdAsync(int id);
        Task<List<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(int id);
        Task CreateStudentAsync(Student student);
        Task CreateCourseAsync(Course course);
        Task<Course> UpdateCourseAsync(int id, Course course);
        Task<Student> UpdateStudentAsync(int id, Student student);
        Task<bool> DeleteStudentAsync(int id);
        Task<bool> DeleteCourseAsync(int id);

        Task<List<Teacher>> GetAllTeachersAsync();
        Task<Teacher> GetTeacherByIdAsync(int id);
        Task CreateTeacherAsync(Teacher teacher);
        Task<Teacher> UpdateTeacherAsync(int id, Teacher teacher);
        Task<bool> DeleteTeacherAsync(int id);

        Task<List<Mark>> GetAllMarksAsync();
        Task<Mark> GetMarkByIdAsync(int id);
        Task CreateMarkAsync(Mark mark);
        Task<Mark> UpdateMarkAsync(int id, Mark mark);
        Task<bool> DeleteMarkAsync(int id);

        Task<List<Subject>> GetAllSubjectsAsync();
        Task<Subject> GetSubjectByIdAsync(int id);
        Task CreateSubjectAsync(Subject subject);
        Task<Subject> UpdateSubjectAsync(int id, Subject subject);
        Task<bool> DeleteSubjectAsync(int id);

        Task<List<Group>> GetAllGroupsAsync();
        Task<Group> GetGroupByIdAsync(int id);
        Task CreateGroupAsync(Group group);
        Task<Group> UpdateGroupAsync(int id, Group group);
        Task<bool> DeleteGroupAsync(int id);
    }
}
