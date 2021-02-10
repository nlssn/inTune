using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using inTune.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace inTune.ViewModels
{
    public class AddRecordViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(120, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 120 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year is required")]
        public string Year { get; set; }

        public int NumOfTracks { get; set; }

        [Required(ErrorMessage = "Artist is required")]
        public int ArtistId { get; set; }

        public List<SelectListItem> Artists { get; set; }

        public AddRecordViewModel(List<Artist> artists)
        {
            this.Artists = new List<SelectListItem>();

            foreach (var artist in artists)
            {
                Artists.Add(
                    new SelectListItem
                    {
                        Value = artist.Id.ToString(),
                        Text = artist.Name
                    }
                );
            }
        }

        public AddRecordViewModel()
        {
        }
    }
}
