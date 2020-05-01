using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPantry.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Threshold { get; set; }
        public int PantryId { get; set; }
        public Pantry Pantry { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
