using System.ComponentModel.DataAnnotations;

namespace OurFirstWebApi.Models
{
    public class Student

    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        public string SSID { get; set; } = string.Empty;

        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
