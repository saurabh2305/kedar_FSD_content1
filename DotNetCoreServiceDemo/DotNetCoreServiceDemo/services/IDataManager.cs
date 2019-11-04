using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreServiceDemo.services
{
   public interface IDataManager
    {
        string GetData();

        string GetGreeting(string name);
    }
}
