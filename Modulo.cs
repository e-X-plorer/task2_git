using System;

namespace Calc
{
    /// <summary>
    /// Modulo operation.
    /// </summary>
    public class Modulo : BinaryOperation
    {
        /// <summary>
        /// Find remainder from division.
        /// </summary>
        /// <returns></returns>
        public override double Execute()
        {
            double result = lhs;
            while (result - rhs > 0)
            {
                result -= rhs;
            }
            return rhs;
        }
    }
}