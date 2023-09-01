using DiscordBot.Common;
using DiscordBot.Bots;
using DiscordBot.Verification;
using DiscordBot.Verification.Components;
using DiscordBot.Verification.Instances;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

var config = Config.Load("Configuration.json");

services.AddSingleton(config);
services.AddSingleton<Bot>();

services.AddSingleton<IVerificator>(
    new VerificationList()
    {
        new ForbiddenLettersVerificator("./Settings/ForbiddenLetters.json"),
        new ForbiddenWordsVerificator("./Settings/ForbiddenWords.json"),
        new ForbiddenLanguageVerificator("./Settings/ForbiddenLanguages.json", config.DetectLanguageKey)
    }
);

var provider = services.BuildServiceProvider();

var bot = provider.GetRequiredService<Bot>();
await bot.Run();