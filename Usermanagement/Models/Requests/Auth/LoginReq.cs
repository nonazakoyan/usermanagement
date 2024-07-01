﻿using System.ComponentModel.DataAnnotations;

namespace Usermanagement.Models.Requests.NewFolder
{
    public class LoginReq
    {
        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
