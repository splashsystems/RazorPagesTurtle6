using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesTurtle6.Data
{
    public class RazorPagesTurtle6Context : DbContext
    {
        public RazorPagesTurtle6Context(
            DbContextOptions<RazorPagesTurtle6Context> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesTurtle6.Models.Turtle> Turtle { get; set; }
    }
}
