using DiscordBot.Common;
using DiscordBot.Inforamtors;
using DiscordBot.Verification.Components;

namespace DiscordBot.Verification.Instances
{
    public sealed class ForbiddenLettersVerificator : 
        VerificatorWithJsonFileConfig<Dictionary<char, int>>
    {
        public ForbiddenLettersVerificator(Config config, IInformator informator)
            : base(config.Verificators.ForbiddenLettersConfigPath)
        {
            Informator = informator;
        }

        public IInformator Informator { get; }

        public override int Verificate(string[] words) 
            => Verificate(string.Join(' ', words));

        public override int Verificate(string text)
        {
            int value = 0;

            foreach (var letter in Config.Keys)
            {
                if (text.Contains(letter))
                {
                    value += Config[letter];
                    Informator.AppendLine($"Letter verification: Contains {letter} - {Config[letter]}");
                }                   
            }

            return value;
        }
    }
}
