using DiscordBot.Common;
using DiscordBot.Inforamtors;
using DiscordBot.Verification.Components;

namespace DiscordBot.Verification.Instances
{
    public class ForbiddenWordsVerificator 
        : VerificatorWithJsonFileConfig<Dictionary<string, int>>
    {
        public ForbiddenWordsVerificator(Config config, IInformator informator)
            : base(config.Verificators.ForbiddenWordsConfigPath)
        {
            Informator = informator;
        }

        public IInformator Informator { get; }

        public override int Verificate(string[] words)
        {
            int value = 0;

            foreach (var word in words) 
            {
                var lower = word.ToLower();

                if (Config.ContainsKey(lower)) 
                {
                    value += Config[lower];
                    Informator.AppendLine($"Words verification: Containing word {word} - {Config[lower]}");
                }      
            }

            return value;
        }
    }
}
