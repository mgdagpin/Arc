using Arc.Application.Common.Interfaces;
using Arc.Application.Emails.Commands;
using Arc.Application.Employees.Queries;
using Arc.Domain.Entities;
using Arc.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arc.Application.Employees.Commands
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public Gender Gender { get; set; }


        public CreateEmployeeCommand(EmployeeVM employee)
        {
            FirstName = employee.FirstName;
            MiddleName = employee.MiddleName;
            LastName = employee.LastName;
            EmailAddress = employee.EmailAddress;
            Gender = employee.Gender;
        }

        public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
        {
            private readonly ITestUserDbContext dbContext;
            private readonly IMediator mediator;
            private readonly ICurrentUser currentUser;

            public CreateEmployeeCommandHandler(ITestUserDbContext dbContext, IMediator mediator, ICurrentUser currentUser)
            {
                this.dbContext = dbContext;
                this.mediator = mediator;
                this.currentUser = currentUser;
            }

            public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
                Employee _newUser = new Employee
                {
                    FirstName = request.FirstName,
                    MiddleName = request.MiddleName,
                    LastName = request.LastName,
                    Gender = request.Gender,
                    EmailAddress = request.EmailAddress,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = currentUser.ID
                };

                dbContext.Employees.Add(_newUser);
                await dbContext.SaveChangesAsync(cancellationToken);

                var _emailCmd = new SendEmailCommand(_newUser.EmailAddress, "Welcome to the clean architecture club!");
                await mediator.Send(_emailCmd);

                return _newUser.ID;
            }
        }
    }
}
