using Core_Layer.Models;
using Core_Layer.Repository;
using Microsoft.AspNetCore.Builder;
using Repository_Layer;
using Service_Layer.Interfaces.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //define each repository here
        public IDiscountCodeRepository _discountRepository { get; }
        public ISpecializationRepo _specializationRepo { get; }
        public IAppUserRepository _userRepository { get; }
        public IDoctorRepository _doctorRepository { get; }
        public IAppointmentRepository _appointmentRepository { get; }
        public ITimesRepository _timesRepository { get; }
        public IRequestRepository _requestRepository { get; }
        public IPatientRepository _patientRepository { get; }
        Task SaveAsync();
    }
}
