using Core_Layer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Models
{
    public class Request
    {
        [Key]
        public  int RequestId { get; set; }

        [EnumDataType(typeof(RequestStatus))]
        public RequestStatus Status { get; set; }
       
        //navigation properties
       
       
        public  Times time { get; set; }
     
        public Doctor? Doctor { get; set; }
        public ApplicationUser? Patient { get; set; }
       

    }
}
