using Core_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Repository
{
    public interface IRequestRepository: ICommonFunctions<Request>
    {
   public int TotalNumOfRequests();
     public int TotalNumOfRequests(Expression<Func<Request, bool>> condition);
    }
}
