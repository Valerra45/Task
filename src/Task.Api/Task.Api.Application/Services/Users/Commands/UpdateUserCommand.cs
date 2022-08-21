using MassTransit;
using MassTransit.Transports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Api.Application.Services.TaskTypes.Commands;
using Tasks.Shared.Contracts;

namespace Tasks.Api.Application.Services.Users.Commands
{
    public class UpdateUserCommand : IRequest
    {
        public UserUpdate User { get; }

        public UpdateUserCommand(UserUpdate user)
        {
            User = user;
        }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
        {
            private readonly IPublishEndpoint _publishEndpoint;

            public UpdateUserCommandHandler(IPublishEndpoint publishEndpoint)
            {
                _publishEndpoint = publishEndpoint;
            }

            async Task<Unit> IRequestHandler<UpdateUserCommand, Unit>.Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                await _publishEndpoint.Publish<IUpdateUserContract>(new
                {
                    Email = request.User.Email,
                    Password = request.User.Password,
                    NewPassword = request.User.NewPassword,
                });

                return Unit.Value;
            }
        }
    }
}
