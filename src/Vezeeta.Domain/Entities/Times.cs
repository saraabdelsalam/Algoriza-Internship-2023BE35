using Vezeeta.Domain.Common;

namespace Vezeeta.Domain.Entities;

public sealed class Times : BaseEntity<int>
{
    public TimeSpan? Time { get; set; }

    public Appointment Appointment { get; set; }
}

