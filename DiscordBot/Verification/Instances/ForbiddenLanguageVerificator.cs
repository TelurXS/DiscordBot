
using DetectLanguage;
using DiscordBot.Common;
using DiscordBot.Verification.Components;

namespace DiscordBot.Verification.Instances
{
    public sealed class ForbiddenLanguageVerificator
        : VerificatorWithJsonFileConfig<Dictionary<string, int>>
    {
        public ForbiddenLanguageVerificator(string path, string key) : base(path)
        {
            LanguageClient = new DetectLanguageClient(key);
        }

        public DetectLanguageClient LanguageClient { get; private set; }

        public override int Verificate(string[] words)
            => Verificate(string.Join(' ', words));

        public override int Verificate(string text)
        {
            int value = 0;

            var results = LanguageClient.DetectAsync(text).Result;
            var result = results.MaxBy(x => x.confidence);

            if (result is null)
                return value;

            if (Config.Keys.Contains(result.language))
                value += Config[result.language];

            return value;
        }
    }
}
