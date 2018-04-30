using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CIT218FinalApp.Models
{
    public class Rollercoaster
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }

        public int Height { get; set; }

        public int Speed { get; set; }
        
        public string Location { get; set; }
    }
}