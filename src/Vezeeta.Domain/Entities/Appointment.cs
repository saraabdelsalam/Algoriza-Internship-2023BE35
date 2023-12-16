using Vezeeta.Domain.Common;
using Vezeeta.Domain.Enums;

namespace Vezeeta.Domain.Entities;

public sealed class Appointment : BaseEntity<int>
{
    public WeekDays Day { get; set; }
    
    public List<Times>? Times { get; set; }
    
    public Doctor Doctor { get; set; }
}
