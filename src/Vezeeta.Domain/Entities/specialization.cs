using Vezeeta.Domain.Common;

namespace Vezeeta.Domain.Entities;

public sealed class Specialization : BaseEntity<int>
{
    public string SpecializationName { get; set; }
}
