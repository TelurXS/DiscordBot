namespace DiscordBot.Verification.Processors
{
    public abstract class VerificationResultProcessor : IProcessor<int, int>
    {
        public virtual int Process(string text, int value)
            => Process(text.Split(), value);

        public abstract int Process(string[] words, int value);
    }
}
