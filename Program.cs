using System;

namespace Calc
{
    public class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Enter your expression below. Please leave spaces between special constants if you are using them.");
            string input = Console.ReadLine();
            Console.WriteLine(ResultManager.ShowResult(input));
        }
    }
}
