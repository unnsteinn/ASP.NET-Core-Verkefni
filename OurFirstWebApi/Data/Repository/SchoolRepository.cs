using Microsoft.EntityFrameworkCore;
using OurFirstWebApi.Data.Interface;
using OurFirstWebApi.Models;
using OurFirstWebApi.Models.DTO;
using Verkefni_Entity_framework.Models;

namespace OurFirstWebApi.Data.Repository
{
    public class SchoolRepository : IRepository
    {
        private readonly SchoolDbContext _dbContext;

        public SchoolRepository(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateCourseAsync(Course course)
        {
            using (var db = _dbContext)
            {
                db.Courses.Add(course);
                await db.SaveChangesAsync();
            }
        }

        public async Task CreateStudentAsync(Student student)
        {
            using (var db = _dbContext)
            {
                db.Students.Add(student);
                await db.SaveChangesAsync();
            }
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            using (var db = _dbContext)
            {
                var courseToDelete = await db.Courses.FirstOrDefaultAsync(c => c.Id == id);

                if (courseToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.Courses.Remove(courseToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            using (var db = _dbContext)
            {
                var studentToDelete = await db.Students.FirstOrDefaultAsync(s => s.Id == id);

                if (studentToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.Students.Remove(studentToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            using (var db = _dbContext)
            {
                return await db.Courses.ToListAsync();
            }
        }

        public async Task<List<StudentDTO>> GetAllStudentsAsync()
        {
            using (var db = _dbContext)
            {
                var students = await db.Students.Include(c => c.Courses).ToListAsync();
                return students.Select(s => new StudentDTO
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Courses = s.Courses.Select(c => new CourseDTO
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Students = null
                    }).ToList()
                }).ToList();
            }
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            using (var db = _dbContext)
            {
                return await db.Courses.Include(s => s.Students).FirstOrDefaultAsync(x => x.Id == id);
            }
        }

        public async Task<StudentDTO> GetStudentByIdAsync(int id)
        {
            using (var db = _dbContext)
            {
                var student = await db.Students.Include(c => c.Courses).FirstOrDefaultAsync(x => x.Id == id);
                return new StudentDTO
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Courses = student.Courses.Select(c => new CourseDTO
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Students = null
                    }).ToList()
                };
            }
        }

        public async Task<Course> UpdateCourseAsync(int id, Course course)
        {
            using (var db = _dbContext)
            {
                var courseToUpdate = await db.Courses.FirstOrDefaultAsync(x => x.Id == id);

                if (courseToUpdate == null)
                {
                    return null;
                }

                courseToUpdate.Name = course.Name;

                await db.SaveChangesAsync();

                return courseToUpdate;
            }
        }

        public async Task<Student> UpdateStudentAsync(int id, Student student)
        {
            using (var db = _dbContext)
            {
                var studentToUpdate = await db.Students.FirstOrDefaultAsync(x => x.Id == id);

                if (studentToUpdate == null)
                {
                    return null;
                }

                studentToUpdate.FirstName = student.FirstName;
                studentToUpdate.LastName = student.LastName;
                studentToUpdate.SSID = student.SSID;

                await db.SaveChangesAsync();

                return studentToUpdate;
            }
        }

        public async Task<List<Teacher>> GetAllTeachersAsync()
        {
            using (var db = _dbContext)
            {
                return await db.Teachers.ToListAsync();
            }
        }

        public async Task<Teacher> GetTeacherByIdAsync(int id)
        {
            using (var db = _dbContext)
            {
                return await db.Teachers.FindAsync(id);
            }
        }

        public async Task CreateTeacherAsync(Teacher teacher)
        {
            using (var db = _dbContext)
            {
                db.Teachers.Add(teacher);
                await db.SaveChangesAsync();
            }
        }

        public async Task<Teacher> UpdateTeacherAsync(int id, Teacher teacher)
        {
            using (var db = _dbContext)
            {
                var teacherToUpdate = await db.Teachers.FindAsync(id);

                if (teacherToUpdate == null)
                {
                    return null;
                }

                teacherToUpdate.FirstName = teacher.FirstName;
                teacherToUpdate.LastName = teacher.LastName;

                await db.SaveChangesAsync();

                return teacherToUpdate;
            }
        }

        public async Task<bool> DeleteTeacherAsync(int id)
        {
            using (var db = _dbContext)
            {
                var teacherToDelete = await db.Teachers.FindAsync(id);

                if (teacherToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.Teachers.Remove(teacherToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }

        public async Task<List<Mark>> GetAllMarksAsync()
        {
            using (var db = _dbContext)
            {
                return await db.Marks.ToListAsync();
            }
        }

        public async Task<Mark> GetMarkByIdAsync(int id)
        {
            using (var db = _dbContext)
            {
                return await db.Marks.FindAsync(id);
            }
        }

        public async Task CreateMarkAsync(Mark mark)
        {
            using (var db = _dbContext)
            {
                db.Marks.Add(mark);
                await db.SaveChangesAsync();
            }
        }

        public async Task<Mark> UpdateMarkAsync(int id, Mark mark)
        {
            using (var db = _dbContext)
            {
                var markToUpdate = await db.Marks.FindAsync(id);

                if (markToUpdate == null)
                {
                    return null;
                }

                markToUpdate.StudentId = mark.StudentId;
                markToUpdate.SubjectId = mark.SubjectId;
                markToUpdate.Date = mark.Date;
                markToUpdate.Grade = mark.Grade;

                await db.SaveChangesAsync();

                return markToUpdate;
            }
        }

        public async Task<bool> DeleteMarkAsync(int id)
        {
            using (var db = _dbContext)
            {
                var markToDelete = await db.Marks.FindAsync(id);

                if (markToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.Marks.Remove(markToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }

        public async Task<List<Subject>> GetAllSubjectsAsync()
        {
            using (var db = _dbContext)
            {
                return await db.Subjects.ToListAsync();
            }
        }

        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            using (var db = _dbContext)
            {
                return await db.Subjects.FindAsync(id);
            }
        }

        public async Task CreateSubjectAsync(Subject subject)
        {
            using (var db = _dbContext)
            {
                db.Subjects.Add(subject);
                await db.SaveChangesAsync();
            }
        }

        public async Task<Subject> UpdateSubjectAsync(int id, Subject subject)
        {
            using (var db = _dbContext)
            {
                var subjectToUpdate = await db.Subjects.FindAsync(id);

                if (subjectToUpdate == null)
                {
                    return null;
                }

                subjectToUpdate.Title = subject.Title;

                await db.SaveChangesAsync();

                return subjectToUpdate;
            }
        }

        public async Task<bool> DeleteSubjectAsync(int id)
        {
            using (var db = _dbContext)
            {
                var subjectToDelete = await db.Subjects.FindAsync(id);

                if (subjectToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.Subjects.Remove(subjectToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }

        public async Task<List<Group>> GetAllGroupsAsync()
        {
            using (var db = _dbContext)
            {
                return await db.Groups.ToListAsync();
            }
        }

        public async Task<Group> GetGroupByIdAsync(int id)
        {
            using (var db = _dbContext)
            {
                return await db.Groups.FindAsync(id);
            }
        }

        public async Task CreateGroupAsync(Group group)
        {
            using (var db = _dbContext)
            {
                db.Groups.Add(group);
                await db.SaveChangesAsync();
            }
        }

        public async Task<Group> UpdateGroupAsync(int id, Group group)
        {
            using (var db = _dbContext)
            {
                var groupToUpdate = await db.Groups.FindAsync(id);

                if (groupToUpdate == null)
                {
                    return null;
                }

                groupToUpdate.Name = group.Name;

                await db.SaveChangesAsync();

                return groupToUpdate;
            }
        }

        public async Task<bool> DeleteGroupAsync(int id)
        {
            using (var db = _dbContext)
            {
                var groupToDelete = await db.Groups.FindAsync(id);

                if (groupToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.Groups.Remove(groupToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }
    }
}
