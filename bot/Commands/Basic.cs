using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity.Extensions;
using main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bot.Commands
{
    public class Basic : BaseCommandModule
    {
        [Command("wait")]
        public async Task TestCommand2(CommandContext ctx)
        {
            var interactivity = Program.Client.GetInteractivity();

            var retrievedmessage = await interactivity.WaitForMessageAsync(message => message.Content == "Jailbird");
            if (retrievedmessage.Result.Content == "Jailbird")
            {
                await ctx.Channel.SendMessageAsync($"{ctx.User.Username}, Hello Jailbird");
            }
        }
    }
}
