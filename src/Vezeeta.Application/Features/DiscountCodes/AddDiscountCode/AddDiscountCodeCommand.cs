
using MediatR;


using Vezeeta.Application.Features.DiscountCodes.DTOs;

namespace Vezeeta.Application.Features.DiscountCodes.AddDiscountCode
{
    public class AddDiscountCodeCommand : IRequest<GetDiscountCodeDto>
    {
        public AddDiscountCodeDto CodeDto { get; set; }
    }
}

