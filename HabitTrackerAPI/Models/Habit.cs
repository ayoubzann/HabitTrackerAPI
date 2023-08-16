using System.ComponentModel.DataAnnotations;

namespace HabitTrackerAPI.Models
{
    public class Habit
    {
        [Required]
        [Key]
        public int HabitId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required]
        public User User { get; set; }
        public ICollection<HabitCompletion>? HabitCompletions { get; set; }
    }

}
