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
        {
            int value = 0;

            foreach (var word in words)
            {
                foreach (var letter in Config.Keys)
                {
                    if (word.Contains(letter))
                        value += Config[letter];
                }
            }

            return value;
        }
    }
}
