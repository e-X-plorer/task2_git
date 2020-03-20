using System;
using System.Collections.Generic;

namespace Calc
{
    public static class Tiers
    {
        private static List<Dictionary<char, Operation>> tiers = new List<Dictionary<char, Operation>>()
        {
            new Dictionary<char, Operation>()
            {
                ['+'] = new Add(),
                ['-'] = new Subtract(),
            },
            new Dictionary<char, Operation>
            {
                ['*'] = new Multiply(),
                ['/'] = new Divide(),                
            },
            new Dictionary<char, Operation>()
            {
            }
        };

        public static int Count => tiers.Count;

        public static Operation GetOperation(char key, int tier)
        {
            return tiers[tier].GetValueOrDefault(key);
        }

        public static bool TryFindKeyTier(char key, out int tier)
        {
            for (int i = 0; i < tiers.Count; i++)
            {
                if (tiers[i].ContainsKey(key))
                {
                    tier = i;
                    return true;
                }
            }
            tier = -1;
            return false;
        }
    }
}