using Vezeeta.Domain.Common;
using Vezeeta.Domain.Enums;

namespace Vezeeta.Domain.Entities;

public sealed class DiscountCode : BaseEntity<int>
{
    public string Code { get; set; }

    public DiscountType DiscountType { get; set; }

    public int Value { get; set; }
    
    public bool? Activated { get; set; }

    public int RequestsNumber { get; set; }
}
