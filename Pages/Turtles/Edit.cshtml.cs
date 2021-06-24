using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesTurtle6.Data;
using RazorPagesTurtle6.Models;

namespace RazorPagesTurtle6.Pages.Turtles
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesTurtle6.Data.RazorPagesTurtle6Context _context;

        public EditModel(RazorPagesTurtle6.Data.RazorPagesTurtle6Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Turtle Turtle { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Turtle = await _context.Turtle.FirstOrDefaultAsync(m => m.ID == id);

            if (Turtle == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Turtle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurtleExists(Turtle.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TurtleExists(int id)
        {
            return _context.Turtle.Any(e => e.ID == id);
        }
    }
}
