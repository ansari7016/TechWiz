using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechWizProject.Models;

namespace TechWizProject.Data
{
    public class TechWizProjectContext : DbContext
    {
        public TechWizProjectContext (DbContextOptions<TechWizProjectContext> options)
            : base(options)
        {
        }

        public DbSet<UserType> UserType { get; set; }
        public DbSet<Register> Registers { get; set; }
    }
}
