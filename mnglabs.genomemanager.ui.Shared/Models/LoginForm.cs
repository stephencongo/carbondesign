﻿using System.ComponentModel.DataAnnotations;

namespace mnglabs.genomemanager.ui.Shared.Models
{
    public class LoginForm
    {
        [Required]
        [StringLength(8, ErrorMessage = "Name length can't be more than 8.")]
        public string Username { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
        public string Password { get; set; }
    }
}