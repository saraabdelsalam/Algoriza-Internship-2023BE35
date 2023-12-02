using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Interfaces
{
   public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message);
        void LogDebug(string message);
    }
}
