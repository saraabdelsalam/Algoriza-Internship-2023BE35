
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Domain.Common;
using Vezeeta.Domain.Enums;

namespace Vezeeta.Domain.Entities
{
    public class DiscountCode: BaseEntity<int>
    {
       
       
        public string code { get; set; }

        public DiscountType discountType { get; set; }

      
        public int value { get; set; }
        public bool? Activated { get; set; }
      
        public int RequestsNumber { get; set; }

    }
}
