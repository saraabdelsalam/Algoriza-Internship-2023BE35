
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Domain.Common;
using Vezeeta.Domain.Enums;

namespace Vezeeta.Domain.Entities
{
    public class Request: BaseEntity<int>
    {

      
        public RequestStatus? Status { get; set; }

       
        public Times Time { get; set; }
        public Doctor Doctor { get; set; }
        public ApplicationUser Patient {  get; set; }

        public DiscountCode DiscountCode { get; set; }


    }
}
