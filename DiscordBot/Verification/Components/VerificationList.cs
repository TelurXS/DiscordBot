namespace DiscordBot.Verification.Components
{
    public sealed class VerificationList : Verificator
    {
        public VerificationList(IEnumerable<IVerificator> verificators)
        {
            Verificators = verificators;
        }

        public IEnumerable<IVerificator> Verificators { get; }

        public override int Verificate(string[] words)
        {
            return Verificators.Sum(verificator =>
                verificator.Verificate(words)); ;
        }
    }
}
