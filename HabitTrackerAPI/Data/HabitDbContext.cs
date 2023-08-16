using HabitTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HabitTrackerAPI.Data
{

    public class HabitDbContext : DbContext
    {
        public HabitDbContext(DbContextOptions<HabitDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<HabitCompletion> HabitCompletions { get; set; }
    }

}
