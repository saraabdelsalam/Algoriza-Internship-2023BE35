

using MediatR;

using Vezeeta.Domain.Contracts;
using Vezeeta.Domain.Entities;

namespace Vezeeta.Application.Features.DiscountCodes.ChangeDiscountCodeStatus;
public class ChangeDiscountCodeStatusHandler : IRequestHandler<ChangeDiscountCodeStatusCommand, DiscountCode>
{
    private readonly IDiscountCodeRepository _discountCodeRepository;
    public ChangeDiscountCodeStatusHandler(IDiscountCodeRepository discountCodeRepository)
    {
        _discountCodeRepository = discountCodeRepository;
    }

    public async Task<DiscountCode> Handle(ChangeDiscountCodeStatusCommand request, CancellationToken cancellationToken)
    {
        var discountCode = _discountCodeRepository.GetById(request.Id);
        if (discountCode == null)
        {
            return null;
        }
        if (discountCode.Activated == true)
        {
            discountCode.Activated = false;
            await _discountCodeRepository.UpdateAsync(discountCode);
            await _discountCodeRepository.SaveAsync();
        }
        return discountCode;
    }
}
