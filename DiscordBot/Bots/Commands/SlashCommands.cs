using DiscordBot.Verification;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace DiscordBot.Bots.Commands
{
    public class SlashCommands : ApplicationCommandModule
    {
        public IVerificator Verificator { get; set; }

        [SlashCommand("ping", "Checks the bot state")]
        public async Task PingCommand(InteractionContext ctx)
        {
            await ctx.CreateResponseAsync(
                InteractionResponseType.ChannelMessageWithSource,
                new DiscordInteractionResponseBuilder().WithContent($"Active!"));
        }

        [SlashCommand("verify", "Evaluate text")]
        public async Task VerifyCommand(InteractionContext ctx, [Option("Text", "Text to evaluate")] string text)
        {
            await ctx.CreateResponseAsync(
                InteractionResponseType.ChannelMessageWithSource,
                new DiscordInteractionResponseBuilder().WithContent(
                    $"Verification result - {Verificator.Verificate(text)}"));
        }
    }
}
