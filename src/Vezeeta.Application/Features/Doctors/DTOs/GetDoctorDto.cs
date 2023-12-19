using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Application.Features.Doctors.DTOs;
public class GetDoctorDto : AddDoctorDto
{
    public string Id { get; set; }
    public int? price { get; set; }
}
