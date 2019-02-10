using System.Collections.Generic;

namespace DiceRoller
{
    /// <summary>
    /// Handles plain text formatting of RollRequests.
    /// </summary>
    public class TextFormatter
    {
        // TODO: Make a base class to inherit from.

        /// <summary>
        /// Formats a RollRequest and the resulting rolls into a human readable string.
        /// </summary>
        /// <param name="rr">The RollRequest object to format.</param>
        /// <param name="values">The result of the dice rolls.</param>
        /// <returns>The formatted string.</returns>
        public static string Format(RollRequest rr, int[] values)
        {
            int total = 0;
            for (int i = 0; i < values.Length; i++)
            {
                total += values[i];
            }

            string mod = string.Empty;
            if (rr.Operand != RollRequest.OperandType.None)
            {
                if (rr.Operand == RollRequest.OperandType.Addition)
                {
                    mod += " + ";
                    total += rr.Modifier;
                }
                else if (rr.Operand == RollRequest.OperandType.Subtraction)
                {
                    mod += " - ";
                    total -= rr.Modifier;
                }

                mod += rr.Modifier.ToString();
            }

            // Rolling a single D20
            string flavorText = string.Empty;
            if (values.Length == 1 && rr.Dimensions == 20)
            {
                if (values[0] == 1)
                {
                    flavorText = " Critical Fail!!!";
                }
                else if (values[0] == 20)
                {
                    flavorText = " Critz for dayzzz!!";
                }
            }

            return string.Concat("(", string.Join(" + ", values), ")", mod, " = " + total + flavorText);
        }
    }
}