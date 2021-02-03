using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inTune.Models
{
    public class Record
    {
        public int RecordId { get; set; }
        public int Artist { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public int NumOfTracks { get; set; }
    }
}
