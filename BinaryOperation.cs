using System;

namespace Calc
{
    public abstract class BinaryOperation : Operation
    {
        /// <summary>
        /// Left operand.
        /// </summary>
        protected double lhs;
        /// <summary>
        /// Right operand.
        /// </summary>
        protected double rhs;

        public BinaryOperation()
        {
            isBinary = true;
        }

        /// <summary>
        /// Initialize operands.
        /// </summary>
        /// <param name="leftValue">left operand</param>
        /// <param name="rightValue">right operand</param>
        public void Init(double leftValue, double rightValue)
        {
            lhs = leftValue;
            rhs = rightValue;
        }
    }
}