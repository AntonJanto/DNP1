using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FamilyAPI.Models.Authentication
{
    public class User
    {
        [Key, Required]
        [MinLength(2), MaxLength(64)]
        public string Username { get; set; }

        [Required]
        [MinLength(5), MaxLength(32)]
        public string Password { get; set; }
        public int Permissions { get; set; } = 0;
    }
}
