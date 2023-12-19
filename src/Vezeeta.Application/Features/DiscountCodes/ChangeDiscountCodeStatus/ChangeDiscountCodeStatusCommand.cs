
using MediatR;

using Vezeeta.Domain.Entities;

namespace Vezeeta.Application.Features.DiscountCodes.ChangeDiscountCodeStatus;
public class ChangeDiscountCodeStatusCommand : IRequest<DiscountCode>
{
    public int Id { get; set; }
}
