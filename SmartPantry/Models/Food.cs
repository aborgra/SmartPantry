using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPantry.Models
{
    public class Food
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name of Item")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Quantity")]


        public int Quantity { get; set; }
        [Required]
        [Display(Name = "Low Quantity Alert Amount")]

        public bool IsThreshold { get; set; }
        public int Threshold { get; set; }
        public int? PantryId { get; set; }
        public Pantry Pantry { get; set; }
        [Display(Name = "Category")]

        public int CategoryId { get; set; }
        [Display(Name = "Category")]

        public Category Category { get; set; }
    }
}
