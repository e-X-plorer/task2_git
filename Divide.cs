using System;

namespace Calc
{
    /// <summary>
    /// Arithmetic division.
    /// </summary>
    public class Divide : BinaryOperation
    {
        /// <summary>
        /// Divides the first value by the second.
        /// </summary>
        /// <returns></returns>
        public override double Execute()
        {
            if (Math.Abs(rhs) < ConstValues.ZERO_EPSILON)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return lhs / rhs;
        }
    }
}