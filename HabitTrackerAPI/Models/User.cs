using System.ComponentModel.DataAnnotations;

namespace HabitTrackerAPI.Models
{
    public class User
    {
        [Required]
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public ICollection<Habit>? Habits { get; set; }
    }

}
