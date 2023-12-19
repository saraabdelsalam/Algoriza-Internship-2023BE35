using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace Vezeeta.Application.Features.Patients.DTOs;
public class PatientRegisterDto
{
    public IFormFile? Image { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public int Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool RememberMe { get; set; }

}
