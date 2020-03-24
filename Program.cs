using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace Calc
{
    public class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        static void Main()
        {
            string input = CalculatorSpecialCharacters.Constants.SubstituteConstants(Console.ReadLine());
            Console.WriteLine(ResultManager.ShowResult(input));
        }
    }
}
