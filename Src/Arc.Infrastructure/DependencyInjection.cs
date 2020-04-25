using Arc.Infrastructure.Identities;
using Autofac;

namespace Arc.Infrastructure
{
    public static class DependencyInjection
    {
        public static ContainerBuilder AddInfrastructure(this ContainerBuilder container)
        {
            container.RegisterType<ArcDbContext>()
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