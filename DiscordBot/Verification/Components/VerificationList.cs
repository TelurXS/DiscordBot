using System.Collections;

namespace DiscordBot.Verification.Components
{
    public sealed class VerificationList : Verificator, IEnumerable<IVerificator>
    {
        public VerificationList(IEnumerable<IVerificator> verificators)
        {
            Verificators = verificators;
        }

        public VerificationList()
        {
            Verificators = new List<IVerificator>();
        }

        public IEnumerable<IVerificator> Verificators { get; private set; }

        public override int Verificate(string[] words)
        {
            return Verificators.Sum(verificator =>
                verificator.Verificate(words));
        }

        public void Add(IVerificator verificator)
        {
            Verificators = Verificators.Append(verificator);
        }

        public IEnumerator<IVerificator> GetEnumerator()
            => Verificators.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
