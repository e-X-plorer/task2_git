using System;
using System.Collections.Generic;

namespace Calc
{
    /// <summary>
    /// Specifies operations and tiers to which they belong.
    /// </summary>
    public static class Tiers
    {
        /// <summary>
        /// List of Dictionaries which assing operations to certain characters.
        /// </summary>
        /// <returns></returns>
        private static List<Dictionary<char, Operation>> tiers = new List<Dictionary<char, Operation>>()
        {
            new Dictionary<char, Operation>()
            {
                ['+'] = new Add(),
                ['-'] = new Subtract()
            },
            new Dictionary<char, Operation>
            {
                ['*'] = new Multiply(),
                ['/'] = new Divide()                
            },
            new Dictionary<char, Operation>()
            {
                ['^'] = new Power()
            }
        };


        /// <summary>
        /// How many tiers the calculator currently supports.
        /// </summary>
        public static int Count => tiers.Count;

        /// <summary>
        /// Get Operation object assigned to certain key character.
        /// </summary>
        /// <param name="key">key to find</param>
        /// <param name="tier">tier to look through</param>
        /// <returns>Operation or null if given key does not exist in given tier</returns>
        public static Operation GetOperation(char key, int tier)
        {
            return tiers[tier].GetValueOrDefault(key);
        }

        /// <summary>
        /// Try to get tier to which given key character belongs.
        /// </summary>
        /// <param name="key">key to find</param>
        /// <param name="tier">variable to which the result will be assigned</param>
        /// <returns>whether given key was found in any of the tiers</returns>
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