using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inTune.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Record> RecordsInGenre { get; set; }

    }
}
