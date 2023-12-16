using Vezeeta.Domain.Common;
using Vezeeta.Domain.Enums;

namespace Vezeeta.Domain.Entities;

public sealed class Request : BaseEntity<int>
{
    public RequestStatus? Status { get; set; }

    public Times Time { get; set; }
    
    public Doctor Doctor { get; set; }
    
    public ApplicationUser Patient { get; set; }

    public DiscountCode DiscountCode { get; set; }
}

