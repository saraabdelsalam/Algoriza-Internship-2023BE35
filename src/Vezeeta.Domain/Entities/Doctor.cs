using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezeeta.Domain.Entities
{
    public class Doctor:ApplicationUser
    {
       
        public int? Price { get; set; }

       
        public ApplicationUser? User { get; set; }

        public Specialization? Specialization { get; set; }


    }
}
