using DiscordBot.Verification.Processors;

namespace DiscordBot.Verification.Components
{
    public sealed class PostProcessingVerificator : Verificator, IProcessor<int, int>
    {
        public PostProcessingVerificator(VerificationList verificators, List<IProcessor<int, int>> processors)
        {
            Verificators = verificators;
            Processors = processors;
        }

        public PostProcessingVerificator()
        {
            Verificators = new VerificationList();
            Processors = new List<IProcessor<int, int>>();
        }

        public VerificationList Verificators { get; private set; }
        public List<IProcessor<int, int>> Processors { get; private set; }

        public override int Verificate(string[] words)
        {
            int value = Verificators.Verificate(words);

            value = Process(words, value);

            return value;
        }

        public int Process(string text, int value)
            => Process(text.Split(), value);

        public int Process(string[] words, int value)
        {
            foreach (var processor in Processors)
                value = processor.Process(words, value);

            return value;
        }

        public PostProcessingVerificator Add(IVerificator verificator) 
        {
            Verificators.Add(verificator);
            return this;
        }

        public PostProcessingVerificator Add(IProcessor<int, int> processor)
        {
            Processors.Add(processor);
            return this;
        }
    }
}
