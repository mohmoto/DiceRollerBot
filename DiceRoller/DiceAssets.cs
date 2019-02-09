using System.Collections.Generic;

namespace DiceRoller
{
    public class DiceAssets
    {
        private static readonly string BaseUri = "Assets/Dice";

        private static Dictionary<int, Dictionary<int, string>> assetLookup = new Dictionary<int, Dictionary<int, string>>()
        {
            {
                4, new Dictionary<int, string>()
                {
                    { 1, "d4-1.png" },
                    { 2, "d4-2.png" },
                    { 3, "d4-3.png" },
                    { 4, "d4-4.png" },
                }
            },
            {
                6, new Dictionary<int, string>()
                {
                    {1, "d6-1.png" },
                    {2, "d6-2.png" },
                    {3, "d6-3.png" },
                    {4, "d6-4.png" },
                    {5, "d6-5.png" },
                    {6, "d6-6.png" },
                }
            },
            {
                8, new Dictionary<int, string>()
                {
                    {1, "d8-1.png" },
                    {2, "d8-2.png" },
                    {3, "d8-3.png" },
                    {4, "d8-4.png" },
                    {5, "d8-5.png" },
                    {6, "d8-6.png" },
                    {7, "d8-7.png" },
                    {8, "d8-8.png" },
                }
            },
            {
                10, new Dictionary<int, string>()
                {
                    {1, "d10-1.png" },
                    {2, "d10-2.png" },
                    {3, "d10-3.png" },
                    {4, "d10-4.png" },
                    {5, "d10-5.png" },
                    {6, "d10-6.png" },
                    {7, "d10-7.png" },
                    {8, "d10-8.png" },
                    {9, "d10-9.png" },
                    {10, "d10-10.png" },
                }
            },
            {
                12, new Dictionary<int, string>()
                {
                    {1, "d12-1.png" },
                    {2, "d12-2.png" },
                    {3, "d12-3.png" },
                    {4, "d12-4.png" },
                    {5, "d12-5.png" },
                    {6, "d12-6.png" },
                    {7, "d12-7.png" },
                    {8, "d12-8.png" },
                    {9, "d12-9.png" },
                    {10, "d12-10.png" },
                    {11, "d12-11.png" },
                    {12, "d12-12.png" },
                }
            },
            {
                20, new Dictionary<int, string>()
                {
                    {1, "d20-1.png" },
                    {2, "d20-2.png" },
                    {3, "d20-3.png" },
                    {4, "d20-4.png" },
                    {5, "d20-5.png" },
                    {6, "d20-6.png" },
                    {7, "d20-7.png" },
                    {8, "d20-8.png" },
                    {9, "d20-9.png" },
                    {10, "d20-10.png" },
                    {11, "d20-11.png" },
                    {12, "d20-12.png" },
                    {13, "d20-13.png" },
                    {14, "d20-14.png" },
                    {15, "d20-15.png" },
                    {16, "d20-16.png" },
                    {17, "d20-17.png" },
                    {18, "d20-18.png" },
                    {19, "d20-19.png" },
                    {20, "d20-20-red.png" },
                }
            },
            {
                100, new Dictionary<int, string>()
                {
                    {10, "d100-10.png" },
                    {20, "d100-20.png" },
                    {30, "d100-30.png" },
                    {40, "d100-40.png" },
                    {50, "d100-50.png" },
                    {60, "d100-60.png" },
                    {70, "d100-70.png" },
                    {80, "d100-80.png" },
                    {90, "d100-90.png" },
                    {100, "d100-100.png" },
                }
            },
        };


        public static string GetUriForRoll(int dimensions, int value)
        {
            string path = null;
            if (assetLookup.ContainsKey(dimensions))
            {
                if (assetLookup[dimensions].ContainsKey(value))
                {
                    string fileName = assetLookup[dimensions][value];
                    path = string.Concat(BaseUri, "/", fileName);
                }
            }

            return path;
        }
    }
}
