using MediatR;

using Vezeeta.Application.Features.Doctors.DTOs;

namespace Vezeeta.Application.Features.Doctors.AddNewDoctor;

public class AddNewDoctorCommand : IRequest<GetDoctorDto>
{
    AddDoctorDto DoctorDto { get; set; }
}
