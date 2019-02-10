using System.Text.RegularExpressions;

namespace DiceRoller
{
    /// <summary>
    /// Represents a users request to roll some dice.
    /// </summary>
    public class RollRequest
    {
        /// <summary>
        /// The regular expression used to parse the user text into a RollResult.
        /// </summary>
        private Regex re = new Regex(@"(?<quant>\d*)? *(d(?<die>\d+)){1} *((?<operand>[\+-]) *(?<mod>\d+))?", RegexOptions.IgnoreCase);

        /// <summary>
        /// Modifier operand at the end of a roll to math out.
        /// </summary>
        public enum OperandType
        {
            /// <summary>
            /// Add the modifier to the result.
            /// </summary>
            Addition,

            /// <summary>
            /// Subtract the modifier to the result.
            /// </summary>
            Subtraction,

            /// <summary>
            /// Indicates there is no modifier.
            /// </summary>
            None,
        }

        /// <summary>
        /// Gets whether a value should be added, subtracted or nothing from the die roll.
        /// </summary>
        public OperandType Operand { get; internal set; }

        /// <summary>
        /// Gets the number of die sides for this RollRequest.
        /// </summary>
        public int Dimensions { get; internal set; }

        /// <summary>
        /// Gets the number of dice to roll.
        /// </summary>
        public int Quantum { get; internal set; }

        /// <summary>
        /// Gets the value to add or subtract from the result of the die roll.
        /// </summary>
        public int Modifier { get; internal set; }

        /// <summary>
        /// Handles parsing the user text into a RollResult object.
        /// </summary>
        /// <param name="value">The user text to parse.</param>
        /// <returns>True if the parse succeeded. False if the parse failed.</returns>
        public bool Parse(string value)
        {
            Match match = re.Match(value);
            if (match.Success)
            {
                Quantum = 1;
                if (match.Groups["quant"].Length > 0)
                {
                    Quantum = int.Parse(match.Groups["quant"].Value);
                }

                Dimensions = int.Parse(match.Groups["die"].Value);
                Operand = OperandType.None;
                if (match.Groups["operand"].Length > 0)
                {
                    string op = match.Groups["operand"].Value;
                    if (op.Equals("-"))
                    {
                        Operand = OperandType.Subtraction;
                    }
                    else
                    {
                        Operand = OperandType.Addition;
                    }

                    Modifier = int.Parse(match.Groups["mod"].Value);
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}