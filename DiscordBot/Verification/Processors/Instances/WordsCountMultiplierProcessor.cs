using DiscordBot.Common;
using DiscordBot.Inforamtors;

namespace DiscordBot.Verification.Processors.Instances
{
    public sealed class WordsCountMultiplierProcessor
        : VerificationResultProcessorWithJsonFileConfig<Dictionary<int, float>>
    {
        public WordsCountMultiplierProcessor(Config config, IInformator informator)
            : base(config.Verificators.WordsCountMultiplierConfigPath)
        {
            Informator = informator;
        }

        public IInformator Informator { get; }

        public override int Process(string[] words, int value)
        {
            if (Config.ContainsKey(words.Length)) 
            {
                int processedValue = (int)(value * Config[words.Length]);
                Informator.AppendLine($"Words Count Postprocessing ( Count: {words.Length} From: {value} To: {processedValue} )");
                return processedValue;
            }

            Informator.AppendLine($"Words Count Postprocessing: Value not affected - {value}");
            return value;
        }
    }
}
