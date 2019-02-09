using System.Collections.Generic;

namespace DiceRoller
{
    public class TextFormatter
    {
        // TODO: Make a base class to inherit from.
        public static string Format(RollRequest rr, List<int> values)
        {
            int total = 0;
            for (int i = 0; i < values.Count; i++)
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
            if (values.Count == 1 && rr.Dimensions == 20)
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