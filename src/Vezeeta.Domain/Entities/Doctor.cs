namespace Vezeeta.Domain.Entities;

public sealed class Doctor : ApplicationUser
{
    public int? Price { get; set; }

    public ApplicationUser? User { get; set; }

    public Specialization? Specialization { get; set; }
}
