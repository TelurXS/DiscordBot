using DSharpPlus.Entities;
using DSharpPlus;
using DSharpPlus.SlashCommands;
using DiscordBot.Verification;
using DiscordBot.Verification.Instances;

namespace DiscordBot.Commands
{
    public class SlashCommands : ApplicationCommandModule
    {
        [SlashCommand("ping", "Checks the bot state")]
        public async Task PingCommand(InteractionContext ctx)
        {
            await ctx.CreateResponseAsync(
                InteractionResponseType.ChannelMessageWithSource,
                new DiscordInteractionResponseBuilder().WithContent("Active!"));
        }

        [SlashCommand("verify", "Check the text for prohibited language")]
        public async Task VerifyCommand(InteractionContext ctx, 
            [Option("text", "text to check)")] string? text) 
        {
            if (text is null)
            {
                await ctx.CreateResponseAsync(
                    InteractionResponseType.ChannelMessageWithSource,
                    new DiscordInteractionResponseBuilder().WithContent("Input text to verify!"));

                return;
            }

            var verificator = new ForbiddenWordsVerificator("../../../Settings/ForbiddenWords.json");

            await ctx.Channel.SendMessageAsync($"Input text: \"{text}\", Forbidden letters: {verificator}");

            if (verificator.Verificate(text) > 0)
            {
                await ctx.CreateResponseAsync(
                    InteractionResponseType.ChannelMessageWithSource,
                    new DiscordInteractionResponseBuilder().WithContent("Text is valid!"));
            }
            else
            {
                await ctx.CreateResponseAsync(
                    InteractionResponseType.ChannelMessageWithSource,
                    new DiscordInteractionResponseBuilder().WithContent("Text is invalid!"));
            }
        }
    }
}
