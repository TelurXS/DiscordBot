using Newtonsoft.Json;

namespace DiscordBot
{
    public sealed class Config
    {
        public Config(string token, string prefix)
        {
            Token = token;
            Prefix = prefix;
        }

        [JsonProperty("token")]
        public string Token { get; private set; }

        [JsonProperty("prefix")]
        public string Prefix { get; private set; }

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
