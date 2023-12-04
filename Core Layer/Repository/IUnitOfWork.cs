﻿using Core_Layer.Models;
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
    public interface IUnitOfWork: IDisposable
    {
        //define each repository here
        public ICRUD<DiscountCode> _discount {  get; }
        public ISpecializationRepo _specializationRepo { get; }
        public IAppUserRepository _userRepository {  get; }
        public IDoctorRepository _doctorRepository { get; }
        
        Task SaveAsync();
    }
}
