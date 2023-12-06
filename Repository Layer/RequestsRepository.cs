using Core_Layer.Models;
using Core_Layer.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer
{
    public class RequestsRepository: CommonFunctions<Request>,IRequestRepository
    {
        public RequestsRepository(ApplicationDbContext context):base(context) { }

        public int TotalNumOfRequests()
        {
            return Context.Set<Request>().Count();
        }

        public int TotalNumOfRequests(Expression<Func<Request, bool>> condition)
        {
            return Context.Set<Request>().Count(condition);
        }
    }
}
