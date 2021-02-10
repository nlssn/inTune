using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inTune.Models;
using Microsoft.EntityFrameworkCore;

namespace inTune.Data
{
    public class inTuneContext:DbContext
    {
        // Constructor
        public inTuneContext(DbContextOptions<inTuneContext> options):base(options)
        {

        }

        // Create a DbSet
        public DbSet<Record> Records { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
