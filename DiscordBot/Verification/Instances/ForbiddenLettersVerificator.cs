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
            throw new NotImplementedException();
        }
    }
}
