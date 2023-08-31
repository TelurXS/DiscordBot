

namespace DiscordBot.Verification
{
    public abstract class Verificator : IVerificator
    {
        public abstract int Verificate(string[] words);

        public virtual int Verificate(string text)
                => Verificate(text.Split());
    }
}
