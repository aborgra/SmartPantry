using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPantry.Models
{
    public class GroceryList
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int PantryId { get; set; }
        public Pantry Pantry { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public int  CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
