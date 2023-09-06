
namespace DiscordBot.Verification.Processors
{
    public interface IProcessor<T, R>
    {
        public R Process(string text, T value);
        public R Process(string[] words, T value);
    }
}
