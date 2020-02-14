using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stomatology.IoC
{
    public static class Bootstrapper
    {
        public static void Bootstrap(ContainerBuilder builder)
        {
            DAL.IoC.Bootstrapper.Bootstrap(builder);
        }
    }
}
