using Newtonsoft.Json;

namespace DiscordBot.Common
{
    public sealed class Config
    {
        [JsonProperty(nameof(DiscordToken))]
        public string DiscordToken { get; private set; }

        [JsonProperty(nameof(DetectLanguageKey))]
        public string DetectLanguageKey { get; private set; }

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
}
