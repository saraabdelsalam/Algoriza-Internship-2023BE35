using Microsoft.AspNetCore.Identity;

using Vezeeta.Domain.Enums;

namespace Vezeeta.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string? Image { get; set; }

    public string FullName { get; set; }

    public Gender Gender { get; set; }

    public DateTime DateOfBirth { get; set; }
}
