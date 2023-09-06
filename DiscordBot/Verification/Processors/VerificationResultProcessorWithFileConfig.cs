
namespace DiscordBot.Verification.Processors
{
    public abstract class VerificationResultProcessorWithFileConfig<T> : VerificationResultProcessor
    {
        public VerificationResultProcessorWithFileConfig(string path)
        {
            if (File.Exists(path) is false)
                throw new ArgumentException($"Config file for {GetType().FullName} is not exist in path {path}.");

            string data = File.ReadAllText(path);

            Config = Parse(data);
        }

        public T Config { get; protected set; }

        public abstract T Parse(string data);
    }
}
