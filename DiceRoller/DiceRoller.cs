using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DiceRoller
{
    /// <summary>
    /// Rolls the dice.
    /// </summary>
    public class Roller
    {
        /// <summary>
        /// Rolls the dice given using a random number generator.
        /// </summary>
        /// <param name="quantum">The number of dice to roll.</param>
        /// <param name="dimensions">The dimensions of the dice to roll.</param>
        /// <param name="sort">Whether the result should be sorted from greatest to least.</param>
        /// <returns>An array of die rolls produced by the RNG.</returns>
        public static int[] Roll(int quantum,  int dimensions, bool sort = false)
        {
            Debug.Assert(quantum > 0, "quantum must be greater than 0");
            Debug.Assert(dimensions > 0, "dimension must be greater than 0");

            // Might switch to Crypto if we find the Radom function to be unsuitable.
            // using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            // {
            //     byte[] rno = new byte[1];
            //     rg.GetBytes(rno);
            //     int randomvalue = BitConverter.ToInt32(rno, 0);
            // }
            Random random = new Random();
            List<int> result = new List<int>();

            for (int i = 0; i < quantum; i++)
            {
                result.Add(random.Next(1, dimensions + 1));
            }

            if (sort)
            {
                result.Sort();
            }

            return result.ToArray();
        }
    }
}