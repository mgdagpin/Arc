using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Arc.Application
{
    public static class DependencyInjection
    {
        public static ContainerBuilder AddApplication(this ContainerBuilder container)
        {
            container.AddMediatR(Assembly.GetExecutingAssembly());

            return container;
        }
    }
}
