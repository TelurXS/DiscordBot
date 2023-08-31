using DiscordBot.Common;
using DiscordBot.Bots;
using DiscordBot.Verification;
using DiscordBot.Verification.Components;
using DiscordBot.Verification.Instances;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddSingleton(Config.Load("Configuration.json"));

services.AddSingleton<Bot>();

services.AddSingleton<IVerificator>(
    new VerificationList(new List<IVerificator>()
    {
        new ForbiddenLettersVerificator("./Settings/ForbiddenLetters.json"),
        new ForbiddenWordsVerificator("./Settings/ForbiddenWords.json"),
    }
));

services.AddSingleton<IServiceCollection>(services);

var provider = services.BuildServiceProvider();

var bot = provider.GetRequiredService<Bot>();
await bot.Run();