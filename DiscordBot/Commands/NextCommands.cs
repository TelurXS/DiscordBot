using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace DiscordBot.Commands
{
    public class NextCommands : BaseCommandModule
    {
        [Command("greet")]
        public async Task GreetCommand(CommandContext ctx)
        {
            await ctx.RespondAsync("Greetings! Thank you for executing me!");
        }
    }
}
