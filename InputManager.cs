using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Calc
{
    /// <summary>
    /// Class for input parsing.
    /// </summary>
    public static class InputManager
    {
        /*/// <summary>
        /// Dictionary of characters representing primary operations.
        /// </summary>
        /// <typeparam name="char">the representing character</typeparam>
        /// <typeparam name="Operation">the operation each character represents</typeparam>
        /// <returns></returns>
        private static Dictionary<char, Operation> primaryKeyChars = new Dictionary<char, Operation>()
        {
            ['*'] = new Multiply(),
            ['/'] = new Divide(),
        };

        /// <summary>
        /// Dictionary of characters representing secondary operations.
        /// </summary>
        /// <typeparam name="char">the representing character</typeparam>
        /// <typeparam name="Operation">the operation each character represents</typeparam>
        /// <returns></returns>
        private static Dictionary<char, Operation> secondaryKeyChars = new Dictionary<char, Operation>()
        {
            ['+'] = new Add(),
            ['-'] = new Subtract(),
        };*/

        /// <summary>
        /// Parses user input or throws an exceptions if input is invalid.
        /// </summary>
        /// <param name="input">string to parse</param>
        /// <returns>result of calculations</returns>
        public static double ProcessInput(string input)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var expression = new List<ExpressionBlock>();

            string trimmedInput = Regex.Replace(input, @"\s+", "") + '#';
            string currentBlockData = "";

            for (int i = 0; trimmedInput[i] != '#'; i++)
            {
                if (Tiers.TryFindKeyTier(trimmedInput[i], out int tier))
                {
                    if (currentBlockData.Length != 0)
                    {
                        expression.Add(new ExpressionBlock(double.Parse(currentBlockData)));
                        currentBlockData = "";
                    }
                    else
                    {
                        throw new FormatException("Invalid expression format.");
                    }
                    
                    expression.Add(new ExpressionBlock(Tiers.GetOperation(trimmedInput[i], tier), tier));
                    /*if (primaryKeyChars.TryGetValue(trimmedInput[i], out currentOperation))
                    {
                        expression.Add(new ExpressionBlock(currentOperation, true));
                    }
                    else
                    {
                        secondaryKeyChars.TryGetValue(trimmedInput[i], out currentOperation);
                        expression.Add(new ExpressionBlock(currentOperation, false));
                    }*/
                }
                else if (char.IsDigit(trimmedInput[i]) || trimmedInput[i] == '.')
                {
                    currentBlockData += trimmedInput[i];
                }
                else
                {
                    throw new FormatException("Invalid expression format.");
                }
            }

            expression.Add(new ExpressionBlock(double.Parse(currentBlockData)));

            if (expression.Count == 0 || !expression[expression.Count - 1].isNumber)
            {
                throw new FormatException("Invalid expression format.");
            }
            else if (expression.Count == 1)
            {
                return expression[0].value;
            }

            for (int i = Tiers.Count - 1; i >= 0; i--)
            {
                ProcessExpression(expression, i);
            }

            return expression[0].value;
        }

        /// <summary>
        /// Process one continuous string of equally-prioritized operations
        /// </summary>
        /// <param name="expression">expression to process</param>
        private static List<ExpressionBlock> ProcessExpression(List<ExpressionBlock> expression, int tier)
        {
            for (int i = 0; i < expression.Count; i++)
            {
                if (!expression[i].isNumber && (tier == expression[i].tier))
                {
                    ((BinaryOperation)expression[i].operation).Init(expression[i - 1].value, expression[i + 1].value);
                    expression[i - 1] = new ExpressionBlock(expression[i].operation.Execute());
                    expression.RemoveRange(i--, 2);
                }
            }
            return expression;
        }
    }
}