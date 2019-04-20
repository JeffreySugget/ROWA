using System.ComponentModel.DataAnnotations;

namespace rowa.repository.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public UserRole UserRole { get; set; }
    }
}
