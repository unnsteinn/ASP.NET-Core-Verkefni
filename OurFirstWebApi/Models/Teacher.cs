using System.ComponentModel.DataAnnotations;

namespace Verkefni_Entity_framework.Models
{
    public class Teacher
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(255)]
        public string LastName { get; set; } = string.Empty;

        public List<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
