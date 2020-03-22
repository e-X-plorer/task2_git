using System;

namespace Calc
{
    /// <summary>
    /// Power operation.
    /// </summary>
    public class Power : BinaryOperation
    {
        /// <summary>
        /// Raises first value to the power of second value.
        /// </summary>
        /// <returns></returns>
        public override double Execute()
        {
            return Math.Pow(lhs, rhs);
        }
    }
}