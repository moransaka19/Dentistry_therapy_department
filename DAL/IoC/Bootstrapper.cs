using Autofac;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DAL.IoC
{
	public static class Bootstrapper
	{
		public static void Bootstrap(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
				.Where(x => x.Name.EndsWith("Repository"))
				.AsImplementedInterfaces()
				.WithParameter(
					(paramInfo, _) => paramInfo.Name == "connectionString",
					(_, context) => context.Resolve<IConfiguration>().GetConnectionString("DefaultConnection"));
		}
	}
}
