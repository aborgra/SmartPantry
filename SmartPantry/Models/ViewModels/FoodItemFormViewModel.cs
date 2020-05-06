﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPantry.Models.ViewModels
{
    public class FoodItemFormViewModel
    {
        public int FoodId { get; set; }
        public string FoodItemName { get; set; }
        public int Quantity { get; set; }
        public bool IsThreshold { get; set; }
        public int Threshold { get; set; }
        public List<SelectListItem> CategoryOptions { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int UserId { get; set; }
        public int PantryId { get; set; }
        public bool ShowDialog { get; set; }
    }
}
