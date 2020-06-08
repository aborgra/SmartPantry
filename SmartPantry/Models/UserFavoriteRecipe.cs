using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPantry.Models
{
    public class UserFavoriteRecipe
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int FavoriteRecipeId { get; set; }
        public FavoriteRecipe FavoriteRecipe { get; set; }
    }
}
