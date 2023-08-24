﻿using Microsoft.AspNetCore.Identity;

namespace eLibrary.Models.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
