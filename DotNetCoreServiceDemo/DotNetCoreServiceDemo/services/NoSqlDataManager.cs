using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreServiceDemo.services
{
    public class NoSqlDataManager:IDataManager
    {
        public string GetData()
        {
            return "NOSQLDATAMANAGER- Hello World ";
        }

        public string GetGreeting(string name)
        {
            return $"NOSQLDATAMANAGER- Hello World {name} ";
        }
    }
}
