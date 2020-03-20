using System;

namespace Calc
{
    /// <summary>
    /// Arithmetic subtraction.
    /// </summary>
    public class Subtract : BinaryOperation
    {
        /// <summary>
        /// Subtracts the second value from the first.
        /// </summary>
        /// <returns></returns>
        public override double Execute()
        {
            return lhs - rhs;
        }
    }
}