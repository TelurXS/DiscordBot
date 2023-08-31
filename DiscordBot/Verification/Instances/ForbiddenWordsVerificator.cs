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
            int value = 0;

            foreach (var word in words) 
            {
                if(Config.ContainsKey(word))
                    value += Config[word];
            }

            return value;
        }
    }
}
