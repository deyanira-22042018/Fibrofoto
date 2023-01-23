using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fibrofoto.Models;

namespace Fibrofoto.Data
{
    public class FibrofotoContext : DbContext
    {
        public FibrofotoContext (DbContextOptions<FibrofotoContext> options)
            : base(options)
        {
        }

        public DbSet<Fibrofoto.Models.Retablos> Retablos { get; set; } = default!;

        public DbSet<Fibrofoto.Models.Cliente> Cliente { get; set; }
    }
}
