using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DiceRoller
{
    public class BotMessageHandler
    {
        private static readonly string HelpString =
            "You can type simply 'd20' to roll a 20 sided die.\n " +
            "You can also tell me how many dice you want to roll like: '3d6'\n" +
            "That tells me to roll 3 individual 6 sided die and I will tell you the total.\n" +
            "Additionally, you can type any modifiers at the end such as '3d6+5\n" +
            "This tells me to add 5 to the total dice roll.\n" +
            "DM says you're gonna die, now roll a d6!";

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

        private static string HandleEchoRequest(string message)
        {
            string responseMessage = message.Remove(
                    0,
                    message.IndexOf("echo", StringComparison.OrdinalIgnoreCase) + 4).TrimStart();
            return responseMessage;
        }

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
                List<int> rolls = Roller.Roll(rr.Quantum, rr.Dimensions);
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
