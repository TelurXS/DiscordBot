
namespace DiscordBot.Verification.Components
{
    public abstract class VerificatorWithFileConfig<T> : Verificator
    {
        public VerificatorWithFileConfig(string path)
        {
            if (File.Exists(path) is false)
                throw new ArgumentException($"Config file for {GetType().FullName} is not exist.");

            string data = File.ReadAllText(path);

            Config = Parse(data);
        }

        public T Config { get; protected set; }

        public abstract T Parse(string data);
    }
}
