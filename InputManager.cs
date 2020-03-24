using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Text;
using CalculatorSpecialCharacters;

namespace Calc
{
    /// <summary>
    /// Class for input parsing.
    /// </summary>
    public static class InputManager
    {
        /// <summary>
        /// Parses user input or throws an exceptions if input is invalid.
        /// </summary>
        /// <param name="input">string to parse</param>
        /// <returns>parsingResult of calculations</returns>
        public static double ProcessInput(string input)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var expression = new List<ExpressionBlock>();

            string trimmedInput = Constants.SubstituteConstants(Regex.Replace(input, @"\s+", "") + '#');
            StringBuilder currentBlockData = new StringBuilder();

            double parsingResult;

            for (int i = 0; trimmedInput[i] != '#'; i++)
            {
                if (Tiers.TryFindKeyTier(trimmedInput[i], out int tier))
                {
                    if (currentBlockData.Length != 0)
                    {
                        if (!double.TryParse(currentBlockData.ToString(), out parsingResult))
                        {
                            throw new CalculatorExceptions.ParsingException("Invalid number format spotted.");
                        }
                        expression.Add(new ExpressionBlock(parsingResult));
                        currentBlockData.Clear();
                    }
                    else
                    {
                        throw new CalculatorExceptions.InvalidExpressionException("Invalid expression format.");
                    }
                    
                    expression.Add(new ExpressionBlock(Tiers.GetOperation(trimmedInput[i], tier), tier));
                }
                else if (char.IsDigit(trimmedInput[i]) || trimmedInput[i] == '.')
                {
                    currentBlockData.Append(trimmedInput[i]);
                }
                else
                {
                    throw new CalculatorExceptions.InvalidExpressionException("Unknown character found in expression.");
                }
            }

            if (currentBlockData.Length == 0)
            {
                throw new CalculatorExceptions.InvalidExpressionException("Invalid expression format.");
            }
            if (!double.TryParse(currentBlockData.ToString(), out parsingResult))
            {
                throw new CalculatorExceptions.ParsingException("Invalid number format spotted.");
            }
            expression.Add(new ExpressionBlock(parsingResult));

            if (expression.Count == 0 || !expression[expression.Count - 1].isNumber)
            {
                throw new CalculatorExceptions.InvalidExpressionException("Invalid expression format.");
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
        /// <param name="tier">tier to process</param>
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