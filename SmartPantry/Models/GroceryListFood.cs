using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPantry.Models
{
    public class GroceryListFood
    {
        public int Id { get; set; }
        public int? GroceryListId { get; set; }
        public GroceryList GroceryList { get; set; }
        public int? FoodId { get; set; }
        public Food Food { get; set; }
        public int Quantity { get; set; }
    }
}
