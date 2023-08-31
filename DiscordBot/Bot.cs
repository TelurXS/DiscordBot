using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.SlashCommands;
using Microsoft.Extensions.Logging;
using DiscordBot.Commands;

namespace DiscordBot
{
    public sealed class Bot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension NextExtension { get; private set; }
        public SlashCommandsExtension SlashExtension { get; private set; }

        public Bot(Config config)
        {
            var configuration = new DiscordConfiguration()
            {
                Token = config.Token,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.All,
                MinimumLogLevel = LogLevel.Debug,
                AutoReconnect = true,
            };

            var commandsNextConfiguration = new CommandsNextConfiguration()
            {
                StringPrefixes = new[] { config.Prefix }
            };

            var slashCommandsConfiguration = new SlashCommandsConfiguration()
            {

            };

            Client = new DiscordClient(configuration);
            NextExtension = Client.UseCommandsNext(commandsNextConfiguration);
            SlashExtension = Client.UseSlashCommands(slashCommandsConfiguration);

            NextExtension.RegisterCommands<NextCommands>();
            SlashExtension.RegisterCommands<SlashCommands>();

            Client.MessageCreated += (client, args) => Task.CompletedTask;
        }

        public async Task Run()
        {
            await Client.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
