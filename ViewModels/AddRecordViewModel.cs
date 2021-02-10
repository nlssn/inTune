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
        public int Id { get; set; }

        [Required(ErrorMessage = "Artist is required")]
        public string Artist { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(120, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 120 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year is required")]
        public string Year { get; set; }

        public int NumOfTracks { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        public List<SelectListItem> Genres { get; set; }

        public AddRecordViewModel(List<Genre> genres)
        {
            this.Genres = new List<SelectListItem>();

            foreach (var genre in genres)
            {
                Genres.Add(
                    new SelectListItem
                    {
                        Value = genre.Id.ToString(),
                        Text = genre.Name
                    }
                );
            }
        }

        public AddRecordViewModel()
        {
        }
    }
}
