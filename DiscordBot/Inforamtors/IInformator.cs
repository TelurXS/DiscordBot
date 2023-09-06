namespace DiscordBot.Inforamtors
{
    public interface IInformator
    {
        IInformator Append(string text);
        IInformator AppendLine(string text);
        IInformator Clear();
        string Get();
    }
}
