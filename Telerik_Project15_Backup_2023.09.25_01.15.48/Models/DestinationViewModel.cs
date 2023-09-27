using System;
using System.ComponentModel.DataAnnotations;

namespace Telerik_Project15.Models
{
    public class DestinationViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal? Rating { get; set; }
    }
}