using Laba6.Data;
using Laba6.Models;
using Laba6.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Laba6.Controllers
{
    [Route("api/{controller}")]
    public class DisciplineController : ControllerBase
    {
        private Context _context { get; set; }

        public DisciplineController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Produces("application/json")]
        
        public async Task<ActionResult<DisciplineView>> Index()
        {
            var disciplines = await _context.Disciplines.ToListAsync();
            var specializations = await _context.Specializations.ToListAsync();
            var views = from d in disciplines
                        join s in specializations
                        on d.SpecializationId equals s.Id
                        select new DisciplineView()
                        {
                            Id = d.Id,
                            Name = d.Name,
                            Hours = d.Hours,
                            ReportType = d.ReportType,
                            Specialization = s.Name,
                            SpecializationId = s.Id
                        };
            return Ok(views);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Discipline discipline)
        {
            if (ModelState != null)
            {
                _context.Add(discipline);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Discipline discipline)
        {
            if (ModelState != null)
            {
                _context.Update(discipline);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var discipline = await _context.Disciplines
                .FirstOrDefaultAsync(d => d.Id == id);
            if (discipline == null)
            {
                return NotFound();
            }

            _context.Disciplines.Remove(discipline);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("Disciplines")]
        [Produces("application/json")]
        public IEnumerable<Discipline> GetDisciplines()
        {
            return _context.Disciplines.ToList();
        }

        [HttpGet("specializations")]
        [Produces("application/json")]
        public IEnumerable<Specialization> GetSpecializations()
        {
            return _context.Specializations.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Discipline discipline = _context.Disciplines.FirstOrDefault(d => d.Id == id);
            return new ObjectResult(discipline);
        }
    }
}
