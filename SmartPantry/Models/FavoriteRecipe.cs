using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPantry.Models
{
    public class FavoriteRecipe
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
    }
}
