﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DNP_FamilyOverview1.Models.Authentication
{
    public class User
    {
        public User() { }
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
        [JsonPropertyName("username")]
        [Required]
        [MinLength(2), MaxLength(64)]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        [Required]
        [MinLength(5), MaxLength(32)]
        public string Password { get; set; }

        [JsonPropertyName("permissions")]
        public int Permissions { get; set; } = 0;
    }
}
