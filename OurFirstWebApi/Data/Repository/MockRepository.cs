using OurFirstWebApi.Data.Interface;
using OurFirstWebApi.Models;
using OurFirstWebApi.Models.DTO;
using Verkefni_Entity_framework.Models;

namespace OurFirstWebApi.Data.Repository
{
    public class MockRepository : IRepository
    {

        List<StudentDTO> Students = new List<StudentDTO>()
            {
                new StudentDTO() { Id = 1, FirstName = "Mock-Hjörtur", LastName = "Pálmi" },
                new StudentDTO() { Id = 2, FirstName = "Mock-Adam", LastName = "Hart" },
                new StudentDTO() { Id = 3, FirstName = "Mock-John", LastName = "Doe" }
            };

        List<Course> Courses = new List<Course>()
        {
            new Course() { Id = 1, Name = "Mock-Forritun"},
            new Course() { Id = 2, Name = "Mock-Hönnun"},
            new Course() { Id = 3, Name = "Mock-Gagnagrunnar"},
        };
        public MockRepository()
        {

        }

        public async Task<List<StudentDTO>> GetAllStudentsAsync()
        {
            return Students;
        }

        public StudentDTO GetStudentById(int id)
        {
            return Students.FirstOrDefault(x => x.Id == id);
        }

        public List<Course> GetAllCourses()
        {
            return Courses;

        }

        public Course GetCourseById(int id)
        {
            return Courses.FirstOrDefault(x => x.Id == id);
        }

        public void CreateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void CreateCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public Course UpdateCourse(int id, Course course)
        {
            throw new NotImplementedException();
        }

        public Student UpdateStudent(int id, Student student)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteCourse(int id)
        {
            throw new NotImplementedException();
        }




        public Task<StudentDTO> GetStudentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Course>> GetAllCoursesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetCourseByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task CreateStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }

        public Task CreateCourseAsync(Course course)
        {
            throw new NotImplementedException();
        }

        public Task<Course> UpdateCourseAsync(int id, Course course)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateStudentAsync(int id, Student student)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStudentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCourseAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Teacher>> GetAllTeachersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Teacher> GetTeacherByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public Task<Teacher> UpdateTeacherAsync(int id, Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTeacherAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Mark>> GetAllMarksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Mark> GetMarkByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateMark(Mark mark)
        {
            throw new NotImplementedException();
        }

        public Task<Mark> UpdateMarkAsync(int id, Mark mark)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMarkAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Subject>> GetAllSubjectsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Subject> GetSubjectByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateSubject(Subject subject)
        {
            throw new NotImplementedException();
        }

        public Task<Subject> UpdateSubjectAsync(int id, Subject subject)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSubjectAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task CreateTeacherAsync(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public Task CreateMarkAsync(Mark mark)
        {
            throw new NotImplementedException();
        }

        public Task CreateSubjectAsync(Subject subject)
        {
            throw new NotImplementedException();
        }

        public Task<List<Group>> GetAllGroupsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Group> GetGroupByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task CreateGroupAsync(Group group)
        {
            throw new NotImplementedException();
        }

        public Task<Group> UpdateGroupAsync(int id, Group group)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGroupAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
