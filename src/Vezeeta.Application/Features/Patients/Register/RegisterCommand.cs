using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using Vezeeta.Application.Features.Patients.DTOs;

namespace Vezeeta.Application.Features.Patients.Register;
public class RegisterCommand : IRequest<GetRegisteredPatientDto>
{
    public PatientRegisterDto _registrationDto {  get; set; }
}
