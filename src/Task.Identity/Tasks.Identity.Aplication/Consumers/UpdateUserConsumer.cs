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
    public class UpdateUserConsumer : IConsumer<IUpdateUserContract>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UpdateUserConsumer(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task Consume(ConsumeContext<IUpdateUserContract> ctx)
        {
            var user = await _userManager.FindByEmailAsync(ctx.Message.Email);

            await _userManager.ChangePasswordAsync(user, ctx.Message.Password, ctx.Message.NewPassword);
        }
    }
}
