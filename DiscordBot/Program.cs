using Microsoft.Extensions.DependencyInjection;
using DiscordBot.Common;
using DiscordBot.Bots;
using DiscordBot.Verification;
using DiscordBot.Verification.Components;
using DiscordBot.Verification.Instances;
using DiscordBot.Verification.Processors.Instances;
using DiscordBot.Inforamtors;

var services = new ServiceCollection();

var config = Config.Load("Configuration.json");

services.AddSingleton(config);
services.AddSingleton<Bot>();
services.AddSingleton<IInformator>(new StringBuilderInformator());

services.AddSingleton<ForbiddenLettersVerificator>();
services.AddSingleton<ForbiddenWordsVerificator>();
services.AddSingleton<ForbiddenLanguageVerificator>();
services.AddSingleton<WordsCountMultiplierProcessor>();

var verificator = new PostProcessingVerificator();

services.AddSingleton(verificator);
services.AddSingleton<IVerificator>(verificator);

var provider = services.BuildServiceProvider();

provider.GetRequiredService<PostProcessingVerificator>()
    .Add(provider.GetRequiredService<ForbiddenLettersVerificator>())
    .Add(provider.GetRequiredService<ForbiddenWordsVerificator>())
    .Add(provider.GetRequiredService<ForbiddenLanguageVerificator>())
    .Add(provider.GetRequiredService<WordsCountMultiplierProcessor>());

var bot = provider.GetRequiredService<Bot>();
await bot.Run();