using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inTune.Models
{
    public class Record
    {
        public int Id { get; set; }
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public int NumOfTracks { get; set; }

        public Record(string title, string year, int numOfTracks)
        {
            this.Title = title;
            this.Year = year;
            this.NumOfTracks = numOfTracks;
        }

        public Record()
        {
        }
    }
}
