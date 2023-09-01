

namespace DiscordBot.Verification.Components
{
    public class VerificatorMiddleware : Verificator
    {
        public VerificatorMiddleware(IVerificator next)
        {

        }

        public override int Verificate(string[] words)
        {
            throw new NotImplementedException();
        }
    }
}
