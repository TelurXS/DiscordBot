using Newtonsoft.Json.Linq;
using System.Text;

namespace DiscordBot.Inforamtors
{
    public class StringBuilderInformator : IInformator
    {
        public StringBuilderInformator()
        {
            Builder = new StringBuilder();
        }

        private StringBuilder Builder { get; set; }

        public IInformator Append(string text)
        {
            Builder.Append(text);
            return this;
        }

        public IInformator AppendLine(string text)
        {
            Builder.AppendLine(text);
            return this;
        }

        public IInformator Clear()
        {
            Builder.Clear();
            return this;
        }

        public string Get()
        {
            return Builder.ToString();  
        }
    }
}
