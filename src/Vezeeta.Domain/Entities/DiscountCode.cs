
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Domain.Enums;

namespace Vezeeta.Domain.Entities
{
    public class DiscountCode
    {
        public int id { get; set; }
       
        public string code { get; set; }

        public DiscountType discountType { get; set; }

      
        public int value { get; set; }
        public bool? Activated { get; set; }
      
        public int RequestsNumber { get; set; }

    }
}
