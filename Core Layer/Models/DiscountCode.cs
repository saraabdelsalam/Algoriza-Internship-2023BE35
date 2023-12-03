using Core_Layer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Models
{
   public class DiscountCode
    {
        public int id {  get; set; }
        [Required(ErrorMessage = "Code is required.")]
        public string code { get; set; }

        [Required(ErrorMessage = "Discount Type is required.")]
        [EnumDataType(typeof(DiscountType))]
       public DiscountType discountType { get; set; }

        [Required(ErrorMessage = "Discount Value is required.")]
        public int value { get; set; }
        public bool? Activated { get; set; }
        [Required(ErrorMessage = "Minimum Requests is required.")]
        [Range(0, int.MaxValue)]
        public int RequestsNumber { get; set; }
        public List<Request>? Requests { get; set; }
    }
}
