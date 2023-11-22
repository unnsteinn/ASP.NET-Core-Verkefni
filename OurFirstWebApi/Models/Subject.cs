using System.ComponentModel.DataAnnotations;

namespace Verkefni_Entity_framework.Models
{
    public class Subject
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Title { get; set; } = string.Empty;

        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
