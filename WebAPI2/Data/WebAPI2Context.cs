using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI2.Models;

namespace WebAPI2.Data
{
    public class WebAPI2Context : DbContext
    {
        public WebAPI2Context (DbContextOptions<WebAPI2Context> options)
            : base(options)
        {
        }

        public DbSet<WebAPI2.Models.Employee> Employee { get; set; } = default!;

        public DbSet<WebAPI2.Models.Department> Department { get; set; }
    }
}
