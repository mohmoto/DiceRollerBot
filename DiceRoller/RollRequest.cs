using System.Text.RegularExpressions;

namespace DiceRoller
{
    public class RollRequest
    {
        public enum OperandType
        {
            Addition,
            Subtraction,
            None
        };

        public OperandType Operand { get; internal set; }

        public int Dimensions { get; internal set; }

        public int Quantum { get; internal set; }

        public int Modifier { get; internal set; }

        private Regex re = new Regex(@"(?<quant>\d*)? *(d(?<die>\d+)){1} *((?<operand>[\+-]) *(?<mod>\d+))?", RegexOptions.IgnoreCase);

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