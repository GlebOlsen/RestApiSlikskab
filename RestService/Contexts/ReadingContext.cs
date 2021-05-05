using Microsoft.EntityFrameworkCore;
using RestService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestService.Contexts
{
    public class ReadingContext : DbContext
    {
        public ReadingContext(DbContextOptions<ReadingContext> options) : base(options) { }
        public DbSet<Reading> Readings { get; set; }
    }
}
