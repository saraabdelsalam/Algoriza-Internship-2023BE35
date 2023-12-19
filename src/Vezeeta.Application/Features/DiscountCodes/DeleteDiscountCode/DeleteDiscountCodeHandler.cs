
using MediatR;

using Vezeeta.Domain.Contracts;
using Vezeeta.Domain.Entities;

namespace Vezeeta.Application.Features.DiscountCodes.DeleteDiscountCode;
public class DeleteDiscountCodeHandler : IRequestHandler<DeleteDiscountCodeCommand, DiscountCode>
{
    private readonly IDiscountCodeRepository _discountCodeRepository;
    public DeleteDiscountCodeHandler(IDiscountCodeRepository discountCodeRepository)
    {
        _discountCodeRepository = discountCodeRepository;
    }
    public async Task<DiscountCode> Handle(DeleteDiscountCodeCommand request, CancellationToken cancellationToken)
    {

        var discountCode = _discountCodeRepository.GetById(request.Id);
        await _discountCodeRepository.DeleteAsync(discountCode);
        await _discountCodeRepository.SaveAsync();
        return discountCode;




    }
}
