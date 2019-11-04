using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreServiceDemo.services
{
    public class SqlDataManager: IDataManager
    {
        public string GetData()
        {
            return "SQLDATAMANAGER- Hello World ";
        }

        public string GetGreeting(string name)
        {
           return $"SQLDATAMANAGER- Hello World {name} ";
        }

        
    }
}
