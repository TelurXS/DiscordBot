using Newtonsoft.Json;

namespace DiscordBot.Verification.Components
{
    public abstract class VerificatorWithJsonFileConfig<T> : VerificatorWithFileConfig<T>
    {
        public VerificatorWithJsonFileConfig(string path) : base(path)
        {
        }

        public override T Parse(string data)
        {
            return JsonConvert.DeserializeObject<T>(data)!;
        }
    }
}
