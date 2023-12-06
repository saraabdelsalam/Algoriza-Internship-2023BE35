using Core_Layer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Models
{
    public class Request
    {
      

        public  int Id { get; set; }

        [EnumDataType(typeof(RequestStatus))]
        public RequestStatus? Status { get; set; }

        [ForeignKey("FK_Requests_Times_TimeId")]
        public int? TimeId { get; set; }

        [ForeignKey("FK_Requests_Doctors_DoctorId")]
        public string? DoctorId { get; set; }

        [ForeignKey("FK_Requests_AspNetUsers_PatientId")]
        public string? PatientId { get; set; }

        [ForeignKey("FK_Requests_DiscountCode_DiscountCodeId")]
      
        public int? DiscountCodeId { get; set; }
    

    }
}
