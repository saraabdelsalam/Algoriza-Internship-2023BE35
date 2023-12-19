

using AutoMapper;

using Vezeeta.Application.Features.DiscountCodes.DTOs;
using Vezeeta.Domain.Entities;

namespace Vezeeta.Application.Features.DiscountCodes;
public class DiscountCodeMapper : Profile
{
    public DiscountCodeMapper()
    {

        CreateMap<AddDiscountCodeDto, DiscountCode>()
         .ForMember(dest => dest.Code, src => src.MapFrom(src => src.Code))
         .ForMember(dest => dest.DiscountType, src => src.MapFrom(src => src.DiscountType))
         .ForMember(dest => dest.Value, src => src.MapFrom(src => src.Value))
         .ForMember(dest => dest.RequestsNumber, src => src.MapFrom(src => src.RequestsNumber))
         .ForMember(dest => dest.Activated, src => src.MapFrom(src => src.Activated));


        CreateMap<GetDiscountCodeDto, DiscountCode>()
       .ForMember(dest => dest.Code, src => src.MapFrom(src => src.Code))
       .ForMember(dest => dest.DiscountType, src => src.MapFrom(src => src.DiscountType))
       .ForMember(dest => dest.Value, src => src.MapFrom(src => src.Value))
       .ForMember(dest => dest.RequestsNumber, src => src.MapFrom(src => src.RequestsNumber))
       .ForMember(dest => dest.Activated, src => src.MapFrom(src => src.Activated)).ReverseMap();



    }



}
