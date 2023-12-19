

using AutoMapper;

using MediatR;

using Vezeeta.Application.Features.DiscountCodes.DTOs;
using Vezeeta.Domain.Contracts;

namespace Vezeeta.Application.Features.DiscountCodes.EditDiscountCode;
public class EditDiscountCodeHandler : IRequestHandler<EditDiscountCodeCommand, GetDiscountCodeDto>
{
    private readonly IDiscountCodeRepository _discountCodeRepository;
    private readonly IMapper _mapper;
    public EditDiscountCodeHandler(IDiscountCodeRepository discountCodeRepository, IMapper mapper)
    {
        _discountCodeRepository = discountCodeRepository;
        _mapper = mapper;
    }

    public async Task<GetDiscountCodeDto> Handle(EditDiscountCodeCommand request, CancellationToken cancellationToken)
    {
        var discountCode = _discountCodeRepository.GetById(request.editDto.Id);

        if (discountCode is null)
        {
            return null;
        }

        _mapper.Map(request.editDto, discountCode);
        await _discountCodeRepository.UpdateAsync(discountCode);
        await _discountCodeRepository.SaveAsync();

        return _mapper.Map<GetDiscountCodeDto>(discountCode);
    }
}
