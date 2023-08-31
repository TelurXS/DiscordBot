using DiscordBot;
using DiscordBot.Verification;
using DiscordBot.Verification.Components;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

//var services = new ServiceCollection();
//
//services.AddSingleton(Config.Load("../../../Settings/Config.json"));
//services.AddSingleton<Bot>();
//
//services.AddSingleton<IVerificator>(
//    new VerificationList(new List<IVerificator>()
//    {
//
//    }));
//
//var provider = services.BuildServiceProvider();
//
//var bot = provider.GetRequiredService<Bot>();
//await bot.Run();

Console.WriteLine(JsonConvert.SerializeObject(new Dictionary<char, int>() 
{
    { 'c', 1 },
    { 'v', 1 },
    { 'a', 1 },
}, Formatting.Indented));
