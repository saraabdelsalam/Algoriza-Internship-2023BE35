using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using Vezeeta.Application.Features.Patients.DTOs;
using Vezeeta.Domain.Entities;

namespace Vezeeta.Application.Features.Patients;
public class PatientMapper : Profile
{
    public PatientMapper() 
    {
        CreateMap<PatientRegisterDto, ApplicationUser>()
               .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => HashPassord(src.Password)))
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => Guid.NewGuid().ToString()))
               .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone))
               .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
               .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
               .ForMember(dest => dest.Image, opt => opt.MapFrom(src => SaveImage(src.Image)))
               .ReverseMap();

        CreateMap<GetRegisteredPatientDto, ApplicationUser>()
       .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
       .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
       .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => HashPassord(src.Password)))
        .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => Guid.NewGuid().ToString()))
       .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone))
       .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
       .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
       .ForMember(dest => dest.Image, opt => opt.MapFrom(src => SaveImage(src.Image)))
       .ReverseMap();
    }
    private string HashPassord(string password)
    {
        return new PasswordHasher<ApplicationUser>().HashPassword(null, password);
    }

    private string SaveImage(IFormFile? image)
    {
        if (image == null)
            return null;
        string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Images");
        if (!Directory.Exists(directoryPath))
        {
            // Directory doesn't exist, create it
            Directory.CreateDirectory(directoryPath);
        }
        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
        string filePath = Path.Combine(directoryPath, fileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            image.CopyTo(fileStream);
        }

        return filePath;

    }
}
