using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Domain.Common;

namespace Vezeeta.Domain.Entities
{
    public class Specialization: BaseEntity<int>
    {
       

   
        public string SpecializationName { get; set; }



    }
}
