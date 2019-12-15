using Autofac;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dentistry.IoC
{
	public static class Bootstrapper
	{
		public static void Bootstrap(ContainerBuilder builder)
		{
			DAL.IoC.Bootstrapper.Bootstrap(builder);
		}
	}
}
