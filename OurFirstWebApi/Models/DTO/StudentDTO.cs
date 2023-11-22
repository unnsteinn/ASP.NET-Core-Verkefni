using System.ComponentModel.DataAnnotations;

namespace OurFirstWebApi.Models.DTO
{
    public class StudentDTO
    {
        public StudentDTO() 
        {
           Courses = new List<CourseDTO>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        
        public string LastName { get; set; } = string.Empty;

        public List<CourseDTO> Courses { get; set; } 
    }

}
