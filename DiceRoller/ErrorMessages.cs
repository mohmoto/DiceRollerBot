using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiceRoller
{
    public class ErrorMessages
    {
        private static readonly string HelpText = "Sorry I don't know what you mean. Type 'help' for help.";
        private static string[] errorMessages =
        {
            "You rolled a critical 1! Or maybe I did... Nope it was you.",
            "LOLZ L 2 RoLl NeWbs!!!!11one",
            "I'm sorry, I can't do that Dave.",
            "I'm experiencing a PEBKAC error. (Problem exists between keyboard and chair).",
            "You have died of dysentary.",
            "Reply hazy. Try again later. Sorry, different bot!",
            "The Elders of the Internet are unhappy with you right now.",
            "GAME OVER MAN! GAME OVER!!!!",
            "Oh no! You split the party!",
            "Never cross the streams! It would be bad.",
            "Do you kiss your mother with that mouth?",
        };

        /// <summary>
        /// Get a random error message from the error message table.
        /// </summary>
        /// <param name="input">The input from the user to echo back.</param>
        /// <returns>A randomly selected string from the erorr string table and the input if provided.</returns>
        public static string GetErrorMessage(string input = "")
        {
            Random rand = new Random();
            int i = rand.Next(0, errorMessages.Length);
            if (input != null)
            {
                return string.Concat(errorMessages[i], " ", HelpText);
            }
            else
            {
                return errorMessages[i];
            }

        }
    }
}
