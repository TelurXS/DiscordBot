using DiscordBot.Inforamtors;
using DiscordBot.Verification;
using DiscordBot.Verification.Components;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using System.Runtime.CompilerServices;
using System.Text;

namespace DiscordBot.Bots.Commands
{
    public class SlashCommands : ApplicationCommandModule
    {
        public IVerificator Verificator { get; set; }
        public IInformator Informator { get; set; }

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
            Informator.Clear();
            Informator.AppendLine($"Verificator type: {Verificator.GetType().Name}");
            Informator.AppendLine($"Verificating text: {text}");

            int result = Verificator.Verificate(text);

            Informator.AppendLine($"Total result: {result}");

            await ctx.CreateResponseAsync(
                InteractionResponseType.ChannelMessageWithSource,
                new DiscordInteractionResponseBuilder().WithContent(
                    Informator.Get()));
        }
    }
}
