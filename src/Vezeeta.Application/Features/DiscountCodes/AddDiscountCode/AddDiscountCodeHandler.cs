
using AutoMapper;

using MediatR;

using Vezeeta.Application.Features.DiscountCodes.DTOs;
using Vezeeta.Domain.Contracts;
using Vezeeta.Domain.Entities;

namespace Vezeeta.Application.Features.DiscountCodes.AddDiscountCode;
public class AddDiscountCodeHandler : IRequestHandler<AddDiscountCodeCommand, GetDiscountCodeDto>
{
    private readonly IDiscountCodeRepository _discountCodeRepository;
    private readonly IMapper _mapper;
    public AddDiscountCodeHandler(IDiscountCodeRepository discountCodeRepository, IMapper mapper)
    {
        _discountCodeRepository = discountCodeRepository;
        _mapper = mapper;

    }
    public async Task<GetDiscountCodeDto> Handle(AddDiscountCodeCommand request, CancellationToken cancellationToken)
    {
        var newDiscountCode = _mapper.Map<DiscountCode>(request.CodeDto);

        await _discountCodeRepository.AddAsync(newDiscountCode);
        await _discountCodeRepository.SaveAsync();
        return _mapper.Map<GetDiscountCodeDto>(newDiscountCode);

    }
}
