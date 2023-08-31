
namespace DiscordBot.Verification
{
    public interface IVerificator
    {
        /// <summary>
        /// Verify text.
        /// </summary>
        /// <param name="text">The text to check.</param>
        /// <returns>
        /// Evaluation of the text
        /// </returns>
        int Verificate(string text);

        /// <summary>
        /// Verify text.
        /// </summary>
        /// <param name="words">A array of words to check.</param>
        /// <returns>
        /// Evaluation of the text
        /// </returns>
        int Verificate(string[] words);
    }
}
