

using Newtonsoft.Json;

namespace DiscordBot.Verification.Processors
{
    public abstract class VerificationResultProcessorWithJsonFileConfig<T> :
        VerificationResultProcessorWithFileConfig<T>
    {
        protected VerificationResultProcessorWithJsonFileConfig(string path) 
            : base(path)
        {
        }

        public override T Parse(string data)
        {
            return JsonConvert.DeserializeObject<T>(data)!;
        }
    }
}
