using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId { get; set; }

        public User Planner { get; set; }

        [Required]
        [Display(Name = "Wedder One")]
        public string WedderOne { get; set; }

        
        [Required]
        [Display(Name = "Wedder Two")]
        public string WedderTwo { get; set; }

        [Display(Name = "Wedding Date")]
        [Startup.MyDate(ErrorMessage ="Invalid date")]
        [DataType(DataType.Date)]
        public DateTime WeddingDate { get; set; }

        [Required]
        [Display(Name = "Wedding Address")]
        public string WeddingAddress { get; set; }

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public List<Association> Associations { get; set; }


        public Wedding()
        {
            Associations = new List<Association>();
        }

    }
}