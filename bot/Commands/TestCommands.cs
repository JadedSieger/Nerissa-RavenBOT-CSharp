using bot.other;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bot.Commands
{
    public class TestCommands : BaseCommandModule
    {
        [Command("Test")]
        public async Task TestCommand1(CommandContext ctx, DiscordMember member)
        {
            await ctx.Channel.SendMessageAsync($"Hello {member.Mention}, hope you have a good day today!");
        }
        [Command("Avatar")]
        public async Task AvatarCommand(CommandContext ctx, DiscordMember member)
        {
            var avatarmessage = new DiscordEmbedBuilder
          {
              Title = $"{member.Mention}'s Avatar:",
              Description = $"User Avatar: {ctx.User.AvatarUrl}" + "\n" + $"Username: {ctx.User.Username}"
          };
          await ctx.Channel.SendMessageAsync(embed: avatarmessage);
            /*   var message = new DiscordMessageBuilder()
                .AddEmbed(new DiscordEmbedBuilder()
                .WithTitle($"{member.Mention}'s Avatar and Information:")
                .WithDescription($"User Avatar: {ctx.User.AvatarUrl}")
                .WithColor(DiscordColor.Blue)
                );*/
        }
        [Command("CardGame")]
        public async Task CardGame(CommandContext ctx)
        {
            var usercard = new CardSystem();

            var usercardem = new DiscordEmbedBuilder
            {
                Title = $"{ctx.User.Username}'s Card is:",
                Description = $"{usercard.selectedCard}",
                Color = DiscordColor.Aquamarine
            };

            await ctx.Channel.SendMessageAsync(embed: usercardem);

            var botCard = new CardSystem();

            var botcardem = new DiscordEmbedBuilder
            {
                Title = $"{ctx.Client.CurrentUser.Username}'s Card is: ",
                Description = $"{botCard.selectedCard}",
                Color = DiscordColor.Orange
            };

            await ctx.Channel.SendMessageAsync(embed: botcardem); 
            
            if(usercard.selectedNum > botCard.selectedNum)
            {
                //User wins
                var winmsg_user = new DiscordEmbedBuilder
                {
                    Title = "The results are: ",
                    Description = $"# {ctx.User.Username} wins!",
                    Color = DiscordColor.Green
                };
                await ctx.Channel.SendMessageAsync(embed: winmsg_user);
            } else
            {
                //bot wins
                var winmsg_bot = new DiscordEmbedBuilder {
                    Title = "The results are: ",
                    Description = $"{ctx.Client.CurrentUser.Username} wins!",
                    Color = DiscordColor.Red
                };
                await ctx.Channel.SendMessageAsync(embed: winmsg_bot);
            }
        }
    }
}
