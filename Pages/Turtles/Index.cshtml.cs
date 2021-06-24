using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTurtle6.Data;
using RazorPagesTurtle6.Models;

namespace RazorPagesTurtle6.Pages.Turtles
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesTurtle6.Data.RazorPagesTurtle6Context _context;

        public IndexModel(RazorPagesTurtle6.Data.RazorPagesTurtle6Context context)
        {
            _context = context;
        }

        public IList<Turtle> Turtle { get;set; }

        public async Task OnGetAsync()
        {
            Turtle = await _context.Turtle.ToListAsync();
        }
    }
}
