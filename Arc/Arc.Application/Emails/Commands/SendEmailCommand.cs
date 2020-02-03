using Arc.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arc.Application.Emails.Commands
{
    public class SendEmailCommand : IRequest
    {
        private readonly string Recipient;
        private readonly string Body;

        public SendEmailCommand(string recipient, string body)
        {
            Recipient = recipient;
            Body = body;
        }

        public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand>
        {
            private readonly IMailService mailService;

            public SendEmailCommandHandler(IMailService mailService)
            {
                this.mailService = mailService;
            }

            public async Task<Unit> Handle(SendEmailCommand request, CancellationToken cancellationToken)
            {
                await mailService.SendEmail(request.Recipient, request.Body);

                return Unit.Value;
            }
        }
    }
}
