using System.ComponentModel.DataAnnotations;

namespace rowa.repository.Entities
{
    public class UserRole
    {
        public int Id { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
