﻿using Microsoft.AspNetCore.Identity;

namespace BlazorCrudDotNet8.Shared.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Pic { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
