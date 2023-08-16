using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HabitTrackerAPI.Data;
using HabitTrackerAPI.Models;

namespace HabitTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitCompletionsController : ControllerBase
    {
        private readonly HabitDbContext _context;

        public HabitCompletionsController(HabitDbContext context)
        {
            _context = context;
        }

        // GET: api/HabitCompletions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HabitCompletion>>> GetHabitCompletions()
        {
          if (_context.HabitCompletions == null)
          {
              return NotFound();
          }
            return await _context.HabitCompletions.ToListAsync();
        }

        // GET: api/HabitCompletions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HabitCompletion>> GetHabitCompletion(int id)
        {
          if (_context.HabitCompletions == null)
          {
              return NotFound();
          }
            var habitCompletion = await _context.HabitCompletions.FindAsync(id);

            if (habitCompletion == null)
            {
                return NotFound();
            }

            return habitCompletion;
        }

        // PUT: api/HabitCompletions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHabitCompletion(int id, HabitCompletion habitCompletion)
        {
            if (id != habitCompletion.CompletionId)
            {
                return BadRequest();
            }

            _context.Entry(habitCompletion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabitCompletionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HabitCompletions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HabitCompletion>> PostHabitCompletion(HabitCompletion habitCompletion)
        {
          if (_context.HabitCompletions == null)
          {
              return Problem("Entity set 'HabitDbContext.HabitCompletions'  is null.");
          }
            _context.HabitCompletions.Add(habitCompletion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHabitCompletion", new { id = habitCompletion.CompletionId }, habitCompletion);
        }

        // DELETE: api/HabitCompletions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabitCompletion(int id)
        {
            if (_context.HabitCompletions == null)
            {
                return NotFound();
            }
            var habitCompletion = await _context.HabitCompletions.FindAsync(id);
            if (habitCompletion == null)
            {
                return NotFound();
            }

            _context.HabitCompletions.Remove(habitCompletion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HabitCompletionExists(int id)
        {
            return (_context.HabitCompletions?.Any(e => e.CompletionId == id)).GetValueOrDefault();
        }
    }
}
