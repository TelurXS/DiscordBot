
using DetectLanguage;
using DiscordBot.Common;
using DiscordBot.Inforamtors;
using DiscordBot.Verification.Components;

namespace DiscordBot.Verification.Instances
{
    public sealed class ForbiddenLanguageVerificator
        : VerificatorWithJsonFileConfig<Dictionary<string, int>>
    {
        public ForbiddenLanguageVerificator(Config config, IInformator informator)
            : base(config.Verificators.ForbiddenLanguageConfigPath)
        {
            LanguageClient = new DetectLanguageClient(config.DetectLanguage.Key);
            Informator = informator;
        }

        public DetectLanguageClient LanguageClient { get; private set; }
        public IInformator Informator { get; }

        public override int Verificate(string[] words)
            => Verificate(string.Join(' ', words));

        public override int Verificate(string text)
        {
            int value = 0;

            var results = LanguageClient.DetectAsync(text).Result;
            var result = results.MaxBy(x => x.confidence);

            if (result is null)
            {
                Informator.AppendLine("Language verification result: Not confident");
                return value;
            }
               
            if (Config.Keys.Contains(result.language))
            {
                value += Config[result.language];
                Informator.AppendLine($"Language verification result: {result.language} - {value}");
            }
                
            return value;
        }
    }
}
