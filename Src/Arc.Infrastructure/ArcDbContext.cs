using Arc.Application.Common.Interfaces;
using Arc.Domain.Entities;
using System.Data.Entity;

namespace Arc.Infrastructure
{
    public class ArcDbContext : DbContext, IArcDbContext
    {
        public ArcDbContext()
            : base("name=ArcUserDbContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ArcDbContext>());
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
