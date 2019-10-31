using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(45)]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(45)]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(45)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(255)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string Confirm { get; set; }

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

    }
}