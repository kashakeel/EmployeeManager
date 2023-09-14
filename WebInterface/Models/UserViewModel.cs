using System.ComponentModel.DataAnnotations;

namespace WebInterface.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int IsAdmin { get; set; }
    }
}
