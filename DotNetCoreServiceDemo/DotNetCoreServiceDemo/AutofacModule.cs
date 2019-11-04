using Autofac;
using DotNetCoreServiceDemo.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreServiceDemo
{
    public class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlDataManager>().As<IDataManager>().SingleInstance();
        }
    }
}
