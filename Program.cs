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
            if (Tiers.CheckValidity())
            {
                Console.WriteLine(ResultManager.ShowResult(Console.ReadLine()));
            }
            else
            {
                Console.WriteLine("Invalid operations preset.");
            }
        }
    }
}
