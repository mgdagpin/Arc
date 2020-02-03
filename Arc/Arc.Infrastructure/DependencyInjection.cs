using Arc.Infrastructure.Identities;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arc.Infrastructure
{
    public static class DependencyInjection
    {
        public static ContainerBuilder AddInfrastructure(this ContainerBuilder container)
        {
            container.RegisterType<TestUserDbContext>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            container.RegisterType<CurrentUser>()
                .AsImplementedInterfaces()
                .InstancePerRequest();

            container.RegisterType<AzureMailService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            return container;
        }
    }    
}