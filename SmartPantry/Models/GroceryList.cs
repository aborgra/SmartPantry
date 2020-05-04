using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPantry.Models
{
    public class GroceryList
    {
        public int Id { get; set; }
        public int? PantryId { get; set; }
        public Pantry Pantry { get; set; }
    }
}
