using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace DiceRoller
{
    public class HtmlFormatter
    {
        private static readonly string HtmlRootElement = "<div style='{0}'>{1}</div>";
        private static readonly string RootElementStyle = "text-align: middle; line-height:50px; font-size: 20px;";
        private static readonly string HtmlImgElement = "<img width=50  height=50 src='{0}' alt='{1}' />";
        private static readonly string HtmlDiceSeperator = " + ";
        private static readonly string HtmlDicePrefix = "( ";
        private static readonly string HtmlDicePostfix = " ) ";
        private static readonly Uri WwwBaseUri = new Uri("https://teamsdiceroller-8dc5.azurewebsites.net");

        /// <summary>
        /// Returns a formatted HTML string (without surounding markup) that represents a dice roll with
        /// picture assets.
        /// </summary>
        /// <param name="rr">The RollRequest to generate from.</param>
        /// <param name="values">The list of values which represent dice rolls.</param>
        /// <returns>An HTML string or null if the assets were not found.</returns>
        public static string Format(RollRequest rr, List<int> values)
        {
            List<string> assetImgElements = new List<string>();
            int total = 0;
            for (int i = 0; i < values.Count; i++)
            {
                string assetUri = DiceAssets.GetUriForRoll(rr.Dimensions, values[i]);
                if (assetUri != null)
                {
                    Uri result;
                    if (!Uri.TryCreate(WwwBaseUri, assetUri, out result))
                    {
                        return null;
                    }
                    else
                    {
                        assetImgElements.Add(string.Format(HtmlImgElement, result.ToString(), values[i]));
                    }
                }
                else
                {
                    return null;
                }

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
            // TODO: It would be fun to randomize these.
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

            // TODO: Consider removing prefix and postfix for single die rolls.
            string content = string.Concat(
                HtmlDicePrefix,
                string.Join(HtmlDiceSeperator, assetImgElements),
                HtmlDicePostfix,
                mod,
                " = ",
                total,
                flavorText);

            return string.Format(
                HtmlRootElement,
                RootElementStyle,
                content);
        }

    }
}
