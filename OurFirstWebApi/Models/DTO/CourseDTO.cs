using System.ComponentModel.DataAnnotations;

namespace OurFirstWebApi.Models.DTO
{
    public class CourseDTO
    {
        public CourseDTO() 
        {
            Students = new List<Student>();
        }
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;
        public List<Student> Students { get; set; }
    }
}
