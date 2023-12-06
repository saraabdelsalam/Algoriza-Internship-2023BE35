using Core_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Repository_Layer;
using Service_Layer.Interfaces;
using Service_Layer.Interfaces.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services.Admin
{
    public class DiscountCodeServices: IDiscountCode
    {
        private readonly IUnitOfWork _unitOfWork;

        public DiscountCodeServices(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }


        public async Task AddDiscountCode(DiscountCode discountCode)
        {
            
            await _unitOfWork._discountRepository.AddAsync(discountCode);
            await _unitOfWork.SaveAsync();
           

        }
        public  async Task EditDiscountCode(DiscountCode discountCode)
        {

          
              await _unitOfWork._discountRepository.UpdateAsync(discountCode);
                await _unitOfWork.SaveAsync();
                
     
        }
        public async Task DeleteDiscountCode(int id)
        {
            var code =  _unitOfWork._discountRepository.GetById(id);
           await _unitOfWork._discountRepository.DeleteAsync(code);
            await _unitOfWork.SaveAsync();
        }
        public async Task ChangeStatus(int id)
        {
            var code = _unitOfWork._discountRepository.GetById(id);
            if(code.Activated == true)
            {
                code.Activated= false;
               await _unitOfWork._discountRepository.UpdateAsync(code);
              await  _unitOfWork.SaveAsync();   
            }

        }

     
       
    }
}
