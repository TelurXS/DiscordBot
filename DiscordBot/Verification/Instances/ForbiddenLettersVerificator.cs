using DiscordBot.Verification.Components;

namespace DiscordBot.Verification.Instances
{
    public sealed class ForbiddenLettersVerificator : 
        VerificatorWithJsonFileConfig<Dictionary<char, int>>
    {
        public ForbiddenLettersVerificator(string path) : base(path)
        {
        }

        public override int Verificate(string[] words) 
            => Verificate(string.Join(' ', words));

        public override int Verificate(string text)
        {
            int value = 0;

            foreach (var letter in Config.Keys)
            {
                if (text.Contains(letter))
                    value += Config[letter];
            }

            return value;
        }
    }
}
