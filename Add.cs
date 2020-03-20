using System;

namespace Calc
{
    /// <summary>
    /// Arithmetic addition.
    /// </summary>
    public class Add : BinaryOperation
    {
        /// <summary>
        /// Adds two values together.
        /// </summary>
        /// <returns></returns>
        public override double Execute()
        {
            return lhs + rhs;
        }
    }
}