using MassTransit;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Shared.Contracts;

namespace Tasks.Identity.Aplication.Consumers
{
    public class CreateUserConsumer : IConsumer<IUserContract>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public CreateUserConsumer(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task Consume(ConsumeContext<IUserContract> ctx)
        {
            var user = new IdentityUser
            {
                UserName = ctx.Message.Name,
                Email    = ctx.Message.Email, 
            };

            var result = await _userManager.CreateAsync(user, ctx.Message.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, ctx.Message.Role);
            }
        }
    }
}
