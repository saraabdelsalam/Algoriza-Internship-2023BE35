using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Vezeeta.Application.Features.Patients.DTOs;
using Vezeeta.Domain.Contracts;
using Vezeeta.Domain.Entities;
using Vezeeta.Domain.Enums;

namespace Vezeeta.Application.Features.Patients.Register;
public class RegisterHandler : IRequestHandler<RegisterCommand, GetRegisteredPatientDto>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;
    public RegisterHandler(IPatientRepository patientRepository, IMapper mapper) 
    { 
        _patientRepository = patientRepository;
        _mapper = mapper;
    
    }
    public async Task<GetRegisteredPatientDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var newUser = _mapper.Map<ApplicationUser>(request._registrationDto);
        await _patientRepository.AddUser(newUser);
        await _patientRepository.AssignRole(newUser, UserRoles.Patient.ToString());
        await _patientRepository.AddSignInCookie(newUser, request._registrationDto.RememberMe);
        await _patientRepository.SaveAsync();
        return _mapper.Map<GetRegisteredPatientDto>(newUser);

    }
}
