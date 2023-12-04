using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Enums
{

   public enum Days
    {
        Saturday,
        Sunday, 
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
    }
  public  enum Gender { Male, Female,}
     public enum DiscountType
    {
        percentage,
        value,
    }

    public enum RequestStatus
    {
        Pending,
        Completed,
        Cancelled
    }
    public enum UserRole { 
   
    Doctor,
    Patient ,
        Admin
    }


}
