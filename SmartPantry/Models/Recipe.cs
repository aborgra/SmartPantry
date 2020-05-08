using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SmartPantry.Models
{
    public class Response
    {
        [JsonPropertyName("hits")]
        public List<MetaData> Hits { get; set; }
    }

    public class MetaData
    {
        [JsonPropertyName("bought")]
        public bool Bought { get; set; }
        [JsonPropertyName("bookmarked")]
        public bool Bookmarked { get; set; }

        [JsonPropertyName("recipe")]
        public Recipe Recipe { get; set; }
    }

    public class Recipe
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }
        [JsonPropertyName("image")]
        public string Image { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("ingredients")]
        public List<Ingredient> Ingredients { get; set; }
        
        [JsonPropertyName("calories")]
        public double Calories { get; set; }
        [JsonPropertyName("totalTime")]
        public decimal TotalTime { get; set; }
        [JsonPropertyName("totalNutrients")]
        public TotalNutrient TotalNutrients { get; set; }
    }

    public class Ingredient
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("weight")]
        public decimal Weight { get; set; }
    }

    public class TotalNutrient
    {
        [JsonPropertyName("Fat")]
        public Fat Fat { get; set; }
        [JsonPropertyName("CHOCDF")]
        [DisplayFormat(DataFormatString = "{0:#.#}")]

        public Carbs Carbs { get; set; }
        [JsonPropertyName("FIBTG")]

        public Fiber Fiber { get; set; }
        [JsonPropertyName("SUGAR")]

        public Sugar Sugar { get; set; }
        [JsonPropertyName("PROCNT")]

        public Protein Protein { get; set; }
        [JsonPropertyName("CHOLE")]

        public Cholesterol Cholesterol { get; set; }
        [JsonPropertyName("NA")]

        public Sodium Sodium { get; set; }
    }

    public class Nutrient
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }
        [JsonPropertyName("quantity")]
        [DisplayFormat(DataFormatString = "{0:#.#}")]

        public double Quantity { get; set; }
        [JsonPropertyName("unit")]
        public string Unit { get; set; }
    }

    public class Fat : Nutrient { }
    public class Carbs : Nutrient { }
    public class Fiber : Nutrient { }
    public class Sugar : Nutrient { }
    public class Protein : Nutrient { }
    public class Cholesterol : Nutrient { }
    public class Sodium : Nutrient { }
}
