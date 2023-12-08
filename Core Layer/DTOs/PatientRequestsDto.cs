using Core_Layer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.DTOs
{
   public class PatientRequestsDto
    {
        public string ImagePath;
        public string DoctorName;
        public string SpecializationName;
        public string Day;
        public string Time;
        public int price;
        public string discoundCodeName;
        public int discoundValue;
        public DiscountType DiscountType;
        public string RequestStatus;
    }
}
