using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CIT218FinalApp.Models
{
    public class Review
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int RollercoasterId { get; set; }

        [Required]
        public string ReviewTitle { get; set; }

        public string Content { get; set; }

        public int Rating { get; set; }

    }
}