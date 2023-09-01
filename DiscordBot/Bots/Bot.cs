using DiscordBot.Bots.Commands;
using DiscordBot.Common;
using DiscordBot.Verification;
using DSharpPlus;
using DSharpPlus.SlashCommands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DiscordBot.Bots
{
    public sealed class Bot
    {
        public Bot(Config config, IVerificator verificator)
        {
            Verificator = verificator;

            var configuration = new DiscordConfiguration()
            {
                Token = config.DiscordToken,
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
                    .BuildServiceProvider()
            };

            SlashExtension = Client.UseSlashCommands(commandsConfiguration);
            SlashExtension.RegisterCommands<SlashCommands>();

            Client.MessageCreated += (client, args) => Task.CompletedTask;
        }

        public IVerificator Verificator { get; }
        public DiscordClient Client { get; private set; }
        public SlashCommandsExtension SlashExtension { get; private set; }

        public async Task Run()
        {
            await Client.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
