using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    /// <summary>
    /// Class <c>User</c> models a User 
    /// </summary>
    public class User
    {
        public int Id { get; set; } 

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int IsAdmin { get; set; } //For Authorization - Pending
    }
}
