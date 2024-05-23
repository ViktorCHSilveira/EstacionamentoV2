using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions options) : base(options) {  }

        public DbSet<Establishment> Establishment { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }

    }
}
