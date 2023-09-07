using Newtonsoft.Json;

namespace DiscordBot.Common
{
    public sealed class Config
    {
        [JsonProperty(nameof(Discord))]
        public DiscordConfig Discord { get; private set; }

        [JsonProperty(nameof(DetectLanguage))]
        public DetectLanguageConfig DetectLanguage { get; private set; }

        [JsonProperty(nameof(Verificators))]
        public VerificatorsConfig Verificators { get; private set; }

        public void Save(string path)
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        public static Config Load(string path)
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Config>(json)!;
        }
    }

    public sealed class DiscordConfig
    {
        [JsonProperty(nameof(Token))]
        public string Token { get; private set; }
    }

    public sealed class DetectLanguageConfig
    {
        [JsonProperty(nameof(Key))]
        public string Key { get; private set; }
    }

    public sealed class VerificatorsConfig
    {
        [JsonProperty(nameof(ForbiddenLettersConfigPath))]
        public string ForbiddenLettersConfigPath { get; private set; }

        [JsonProperty(nameof(ForbiddenWordsConfigPath))]
        public string ForbiddenWordsConfigPath { get; private set; }

        [JsonProperty(nameof(ForbiddenLanguageConfigPath))]
        public string ForbiddenLanguageConfigPath { get; private set; }

        [JsonProperty(nameof(WordsCountMultiplierConfigPath))]
        public string WordsCountMultiplierConfigPath { get; private set; }
        
        [JsonProperty(nameof(PriorityLanguage))]
        public string PriorityLanguage { get; private set; }

        [JsonProperty(nameof(EvaluationLimit))]
        public int EvaluationLimit { get; private set; }
    }
}
