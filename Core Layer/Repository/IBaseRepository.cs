using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Generic_Repo
{
    public interface IBaseRepository< T> where T : class
{
      //method overloading
        T GetById(int id);
        T GetById(string id);





}
}
