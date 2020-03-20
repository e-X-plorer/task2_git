using System;

namespace Calc
{
    /// <summary>
    /// Class for displaying the calculation results properly.
    /// </summary>
    static class ResultManager
    {
        /// <summary>
        /// Invokes ProcessInput method to parse user input properly and then shows result or error message.
        /// </summary>
        /// <param name="stringToProcess">input string from a user</param>
        /// <returns>result of parsing of a string</returns>
        public static string ShowResult(string stringToProcess)
        {
            try
            {
                return InputManager.ProcessInput(stringToProcess).ToString();
            }
            catch (FormatException)
            {
                return "Invalid expression format.";
            }
            catch (DivideByZeroException)
            {
                return "Cannot divide by zero.";
            }
        }
    }
}