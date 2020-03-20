using System;

namespace Calc
{
    /// <summary>
    /// Arithmetic multiplication.
    /// </summary>
    public class Multiply : BinaryOperation
    {
        /// <summary>
        /// Multiplies one value by another.
        /// </summary>
        /// <returns></returns>
        public override double Execute()
        {
            return lhs * rhs;
        }
    }
}