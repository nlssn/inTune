using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inTune.Models;
using Microsoft.EntityFrameworkCore;

namespace inTune.Data
{
    public class RecordContext:DbContext
    {
        // Constructor
        public RecordContext(DbContextOptions<RecordContext> options):base(options)
        {

        }

        // Create a DbSet
        public DbSet<Record> Records { get; set; }
    }
}
