using Autofac;
using ShellLoginSample.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShellLoginSample.Service
{
    public static class DIContainer
    {
        private static IContainer _container;

        public static IAuthentication AuthenticationService { get { return _container.Resolve<IAuthentication>(); } }
        //public static IServiceB ServiceB { get { return _container.Resolve<IServiceB>(); } }

        public static void Initialize()
        {
            if (_container == null)
            {
                var builder = new ContainerBuilder();
                builder.RegisterType<Authentication>().As<IAuthentication>().SingleInstance();
                //builder.RegisterType<ServiceB>().As<IServiceB>().SingleInstance();
                _container = builder.Build();
            }
        }
    }
}
