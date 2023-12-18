
using MediatR;

using Vezeeta.Application.Features.DiscountCodes.DTOs;

namespace Vezeeta.Application.Features.DiscountCodes.EditDiscountCode;
public class EditDiscountCodeCommand : IRequest<GetDiscountCodeDto>
{
    public EditDiscountCodeDto editDto { get; set; }
}
