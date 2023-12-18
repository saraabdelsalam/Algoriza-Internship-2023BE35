
using MediatR;

using Vezeeta.Domain.Entities;

namespace Vezeeta.Application.Features.DiscountCodes.DeleteDiscountCode;
public class DeleteDiscountCodeCommand : IRequest<DiscountCode>
{
    public int Id { get; set; }
}
