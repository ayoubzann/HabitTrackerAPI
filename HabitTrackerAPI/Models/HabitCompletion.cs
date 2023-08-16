using System.ComponentModel.DataAnnotations;

namespace HabitTrackerAPI.Models
{
    public class HabitCompletion
    {
        [Required]
        [Key]
        public int CompletionId { get; set; }
        public int HabitId { get; set; }
        public DateTime CompletionDate { get; set; }

        public Habit? Habit { get; set; }
    }

}
