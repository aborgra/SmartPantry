using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPantry.Models
{
    public class ApplicationUser:IdentityUser
    {
        public ApplicationUser()
        {
        }

        public string Name { get; set; }
        public int PantryId { get; set; }
    }
}
