using System.ComponentModel.DataAnnotations;

namespace Verkefni_Entity_framework.Models
{
    public class Group
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;
    }
}
