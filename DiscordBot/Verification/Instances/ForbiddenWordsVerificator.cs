using DiscordBot.Verification.Components;

namespace DiscordBot.Verification.Instances
{
    public class ForbiddenWordsVerificator 
        : VerificatorWithJsonFileConfig<Dictionary<string, int>>
    {
        public ForbiddenWordsVerificator(string path) : base(path)
        {
        }

        public override int Verificate(string[] words)
        {
            throw new NotImplementedException();
        }
    }
}
