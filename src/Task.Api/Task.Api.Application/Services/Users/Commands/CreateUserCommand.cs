using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Core.Abstractions;
using Tasks.Shared.Contracts;

namespace Tasks.Api.Application.Services.Users.Commands
{
    public class CreateUserCommand : IRequest
    {
        public CreateOrEditUser User { get; }

        public CreateUserCommand(CreateOrEditUser user)
        {
            User = user;
        }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public CreateUserCommandHandler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _publishEndpoint.Publish<IUserContract>(new
            {
                Name = request.User.Name,
                Email = request.User.Email,
                Password = request.User.Password,
                Role = request.User.Role,
            });

            return Unit.Value;
        }
    }
}
