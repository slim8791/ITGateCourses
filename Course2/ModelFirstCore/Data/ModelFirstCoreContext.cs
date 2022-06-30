using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelFirstCore.Models;

namespace ModelFirstCore.Data
{
    public class ModelFirstCoreContext : DbContext
    {
        public ModelFirstCoreContext (DbContextOptions<ModelFirstCoreContext> options)
            : base(options)
        {
        }

        public DbSet<ModelFirstCore.Models.Personnel>? Personnel { get; set; }
    }
}
