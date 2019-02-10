using System;
using System.Collections.Generic;

namespace DiceRoller
{
    /// <summary>
    /// Handles incoming messages.
    /// </summary>
    public class BotMessageHandler
    {
        /// <summary>
        /// String to emit when help is requested.
        /// </summary>
        private static readonly string HelpString =
            "You can type simply 'd20' to roll a 20 sided die.<br>" +
            "You can also tell me how many dice you want to roll like: '3d6'<br>" +
            "That tells me to roll 3 individual 6 sided die and I will tell you the total.<br>" +
            "Additionally, you can type any modifiers at the end such as '3d6+5<br>" +
            "This tells me to add 5 to the total dice roll.<br>" +
            "DM says you're gonna die, now roll a d6!";

        /// <summary>
        /// Main point of entry for message handling.
        /// </summary>
        /// <param name="message">User typed text.</param>
        /// <returns>The response from any of the handlers.</returns>
        public static string HandleMessage(string message)
        {
            string responseMessage = string.Empty;
            string trimmedMessage = message.Trim();
            if (trimmedMessage.StartsWith("echo", StringComparison.OrdinalIgnoreCase))
            {
                responseMessage = HandleEchoRequest(message);
            }
            else if (trimmedMessage.StartsWith("help", StringComparison.OrdinalIgnoreCase))
            {
                responseMessage = HelpString;
            }
            else
            {
                responseMessage = HandleRollRequest(message);
            }

            return responseMessage;
        }

        /// <summary>
        /// This is method used for format testing. This will simply echo the input to test
        /// any markup handling by the client app.
        /// </summary>
        /// <param name="message">The user typed text.</param>
        /// <returns>The user typed text removing the echo + space prefix.</returns>
        private static string HandleEchoRequest(string message)
        {
            string responseMessage = message.Remove(
                    0,
                    message.IndexOf("echo", StringComparison.OrdinalIgnoreCase) + 4).TrimStart();
            return responseMessage;
        }

        /// <summary>
        /// The default handler for dice rolls.
        /// </summary>
        /// <param name="message">The user typed text.</param>
        /// <returns>The result of the roll formatted in either HTML or plain text.</returns>
        private static string HandleRollRequest(string message)
        {
            string responseMessage = string.Empty;
            var rr = new RollRequest();
            if (!rr.Parse(message))
            {
                responseMessage = ErrorMessages.GetErrorMessage(message);
            }
            else
            {
                int[] rolls = Roller.Roll(rr.Quantum, rr.Dimensions);
                responseMessage = HtmlFormatter.Format(rr, rolls);
                if (responseMessage == null)
                {
                    responseMessage = TextFormatter.Format(rr, rolls);
                }
            }

            return responseMessage;
        }
    }
}
