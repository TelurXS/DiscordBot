using DiscordBot.Bots.Commands;
using DiscordBot.Common;
using DiscordBot.Inforamtors;
using DiscordBot.Verification;
using DSharpPlus;
using DSharpPlus.SlashCommands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DiscordBot.Bots
{
    public sealed class Bot
    {
        public Bot(Config config, IVerificator verificator, IInformator informator)
        {
            Verificator = verificator;
            EvaluationLimit = config.Verificators.EvaluationLimit;

            var configuration = new DiscordConfiguration()
            {
                Token = config.Discord.Token,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.All,
                MinimumLogLevel = LogLevel.Debug,
                AutoReconnect = true,
            };

            Client = new DiscordClient(configuration);

            var commandsConfiguration = new SlashCommandsConfiguration()
            {
                Services = new ServiceCollection()
                    .AddSingleton(verificator)
                    .AddSingleton(informator)
                    .BuildServiceProvider()
            };

            SlashExtension = Client.UseSlashCommands(commandsConfiguration);
            SlashExtension.RegisterCommands<SlashCommands>();

            Client.MessageCreated += async (client, args) =>
            {
                int value = Verificator.Verificate(args.Message.Content);

                if (value >= EvaluationLimit)
                {
                    Console.WriteLine($"[{args.Message.Author.Username}]: ${args.Message.Content} - Deleted ({value})");
                    await args.Message.DeleteAsync();
                }
            };
        }

        public IVerificator Verificator { get; }
        public DiscordClient Client { get; private set; }
        public SlashCommandsExtension SlashExtension { get; private set; }
        public int EvaluationLimit { get; private set; }

        public async Task Run()
        {
            await Client.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
