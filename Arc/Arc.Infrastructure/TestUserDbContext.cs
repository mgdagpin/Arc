using Arc.Application.Common.Interfaces;
using Arc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arc.Infrastructure
{
    public class TestUserDbContext : DbContext, ITestUserDbContext
    {
        public TestUserDbContext()
            : base("name=ArcUserDbContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<TestUserDbContext>());
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
