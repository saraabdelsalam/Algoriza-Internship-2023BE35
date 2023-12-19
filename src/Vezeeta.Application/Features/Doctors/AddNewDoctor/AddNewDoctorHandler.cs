

using AutoMapper;

using MediatR;

using Vezeeta.Application.Features.Doctors.DTOs;
using Vezeeta.Domain.Contracts;

namespace Vezeeta.Application.Features.Doctors.AddNewDoctor;
public class AddNewDoctorHandler : IRequestHandler<AddNewDoctorCommand, GetDoctorDto>
{
    private readonly IAppUserRepository _userRepository;
    private readonly IMapper _mapper;
    public AddNewDoctorHandler(IAppUserRepository userRepository, IMapper mapper)
    { 
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public Task<GetDoctorDto> Handle(AddNewDoctorCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
