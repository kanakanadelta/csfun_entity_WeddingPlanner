using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public string WeddingId { get; set; }

        [Required]
        [Display(Name = "Wedder One")]
        public string WedderOne { get; set; }

        
        [Required]
        [Display(Name = "Wedder Two")]
        public User WedderTwo { get; set; }

        [Display(Name = "Wedding Date")]
        public DateTime WeddingDate { get; set; }

        [Required]
        [Display(Name = "Wedding Address")]
        public string WeddingAddress { get; set; }

        List<User> Guests { get; set; }

        public Wedding()
        {
            Guests = new List<User>();
        }

    }
}